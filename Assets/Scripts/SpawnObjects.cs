using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private Transform[] _spawnObjects;
    private int _numberOfSpawn = 0;

    private void Start()
    {
        _spawnObjects = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnObjects[i] = transform.GetChild(i);
        }
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        Instantiate(_enemy, _spawnObjects[_numberOfSpawn].position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        if(++_numberOfSpawn == _spawnObjects.Length)
        {
            _numberOfSpawn = 0;
        }
        StartCoroutine(Spawn());
    }
}
