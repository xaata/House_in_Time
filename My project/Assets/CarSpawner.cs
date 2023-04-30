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
            var rn = Random.Range(0, _spawnPoints.Length);
            if (rn > 0 || rn / 2 < _spawnPoints.Length / 2)
            {
                Instantiate(_cars[Random.Range(0, 3)], _spawnPoints[0].GetChild(rn).position, Quaternion.identity, _carsParent);
                Instantiate(_cars[Random.Range(0, 3)], _spawnPoints[0].GetChild(rn - Random.Range(0, rn)).position, Quaternion.identity, _carsParent);
                Instantiate(_cars[Random.Range(0, 3)], _spawnPoints[0].GetChild(rn + Random.Range(0, rn)).position, Quaternion.identity, _carsParent);

                yield return new WaitForSeconds(1);

            }
        }
    }
}
