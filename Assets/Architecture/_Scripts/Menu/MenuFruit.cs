using UnityEngine;

public class MenuFruit : MonoBehaviour
{
    [SerializeField] private GameObject _fruitSlicedPrefab;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ninja")
        {
            Instantiate(_fruitSlicedPrefab, transform.position, transform.rotation);
        }
    }
}
