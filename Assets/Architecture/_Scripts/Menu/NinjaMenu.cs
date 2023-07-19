using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NinjaMenu : MonoBehaviour
{
    [SerializeField] private GameObject _ninjaCSSPrefab;
    [SerializeField][Range(0, 1)] private float minCuttingVelocity;
    private float _velocity;
    private GameObject _currentNinjaCSS;
    private bool _isCut = false;
    private Rigidbody2D _rb;
    private Camera _cam;
    private Vector2 _startPos;
    private Vector2 _endPos;
    private CircleCollider2D _circleCollider;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _cam = Camera.main;
    }

    // Update is called once per frame
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
        if (collision.tag == "FruitButtonStart")
        {
            SpawnPoints.Destroy(collision.gameObject);
            StartCoroutine(Waiting());
        }
        if (collision.tag == "FruitButtonAchievements")
        {
            SpawnPoints.Destroy(collision.gameObject);
        }
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainGameScene");
    }
}
