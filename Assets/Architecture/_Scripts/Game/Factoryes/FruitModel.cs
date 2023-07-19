using UnityEngine;

public class FruitModel : MonoBehaviour
{
    [SerializeField] private GameObject _fruitSlicedPrefab;
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(transform.up * Random.Range(9f,16f), ForceMode2D.Impulse);
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ninja")
        {
            Instantiate(_fruitSlicedPrefab, transform.position, transform.rotation);
        }
    }
}
