using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NinjaModel : MonoBehaviour
{
    [SerializeField] private GameObject _ninjaCSSPrefab;
    [SerializeField] [Range(0,1)] private float minCuttingVelocity;
    [SerializeField] private Text _scoreMax;
    [SerializeField] private Text _scoreCurrent;
    private int _scoreLast;
    private int _scoreCountMax;
    private GameObject _currentNinjaCSS;
    private int _count;
    private Vector2 _startPos;
    private Vector2 _endPos;
    private bool _isCut = false;
    private float _velocity;
    private Rigidbody2D _rb;
    private Camera _cam;
    private CircleCollider2D _circleCollider;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _cam = Camera.main;
        _count = 0;
        var _scoreCountMax = PlayerPrefs.GetInt("_scoreCountMax", 0);
        _scoreMax.text = _scoreCountMax.ToString();
        _scoreLast = _scoreCountMax;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            StartCutting();
            _isCut = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
            _isCut = false;
        }
        UpdateCut();
        _scoreCurrent.text = _count.ToString();
    }
    void UpdateCut()
    {
        _endPos = _cam.ScreenToWorldPoint(Input.mousePosition);
        _rb.position = _endPos;
        _velocity = (_endPos - _startPos).magnitude;
        if (_velocity > minCuttingVelocity && _isCut) _circleCollider.enabled = true;
        else _circleCollider.enabled = false;
        _startPos = _endPos;
    }
    void StartCutting()
    {
        _currentNinjaCSS = Instantiate(_ninjaCSSPrefab, transform);
        _circleCollider.enabled = false;
    }
    void StopCutting()
    {
        _currentNinjaCSS.transform.SetParent(null);
        Destroy(_currentNinjaCSS, 0.3f);
        _circleCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fruit")
        {
            SpawnPoints.Destroy(collision.gameObject);
            _count++;
            if (_scoreLast < _count)
            {
                _scoreMax.text = _count.ToString();
            }
        }
        if (collision.tag == "Bomb")
        {
            SpawnPoints.Destroy(collision.gameObject);
            

            if (_scoreLast < _count)
            {
                PlayerPrefs.SetInt("_scoreCountMax", _count);
            }
            SceneManager.LoadScene("Menu");
        }
    }
}
