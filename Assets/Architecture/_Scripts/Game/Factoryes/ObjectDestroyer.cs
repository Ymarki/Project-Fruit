using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    void Start()
    {
        Destroy(_object, 4f);
    }

}
