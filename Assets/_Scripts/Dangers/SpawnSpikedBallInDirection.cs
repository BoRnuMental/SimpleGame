using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnSpikedBallInDirection : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float[] range = new float[2];

    private float _spawnFrequency;
    void Start()
    {
        _spawnFrequency = Random.Range(range[0], range[1]);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnFrequency);
            Instantiate(_prefab, transform.position, new Quaternion());
        }
    }
}
