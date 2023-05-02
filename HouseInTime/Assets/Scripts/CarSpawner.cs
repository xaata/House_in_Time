using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    private Car[] _cars;
    [SerializeField]
    private Transform[] _spawnPoints;

    [SerializeField]
    private Transform _carsParent;
    void Start()
    {
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        while (true)
        {        
            Instantiate(_cars[Random.Range(0, 3)], _spawnPoints[0].GetChild(Random.Range(0, _spawnPoints[0].childCount)).position, Quaternion.identity, _carsParent);
            Instantiate(_cars[Random.Range(0, 3)], _spawnPoints[0].GetChild(Random.Range(0, _spawnPoints[0].childCount)).position, Quaternion.identity, _carsParent);         
            Instantiate(_cars[Random.Range(0, 3)], _spawnPoints[1].GetChild(Random.Range(0, _spawnPoints[0].childCount)).position, Quaternion.identity, _carsParent);
            Instantiate(_cars[Random.Range(0, 3)], _spawnPoints[1].GetChild(Random.Range(0, _spawnPoints[0].childCount)).position, Quaternion.identity, _carsParent);
            yield return new WaitForSeconds(1);           
        }
    }
}
