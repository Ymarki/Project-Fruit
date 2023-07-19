using System.Collections;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private GameObject _fruitPrefab;
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    private int _spawnFruitCount;
    private bool _isSpawning = true;

    private void Start()
    {
        _spawnFruitCount = Random.Range(6,10);
        StartCoroutine(SpawnFruits());
        StartCoroutine(SpawnBombs());
    }
    IEnumerator SpawnFruits()
    {
        while (_isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
            int spawnIndex = Random.Range(0, _spawnPoints.Length);
            Transform _spawnPoint = _spawnPoints[spawnIndex];
            Instantiate(_fruitPrefab, _spawnPoint.position, _spawnPoint.rotation);
        }
    }
    IEnumerator SpawnBombs()
    {
        while (_isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
            int spawnIndex = Random.Range(0, _spawnPoints.Length);
            Transform _spawnPoint = _spawnPoints[spawnIndex];
            if (_spawnFruitCount <= 0)
            {
                Instantiate(_bombPrefab, _spawnPoint.position, _spawnPoint.rotation);
                _spawnFruitCount = Random.Range(6, 10);
            }
            else _spawnFruitCount--;
        }
    }
}
