using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombModel : MonoBehaviour
{
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(transform.up * Random.Range(9f, 16f), ForceMode2D.Impulse);
    }
}
