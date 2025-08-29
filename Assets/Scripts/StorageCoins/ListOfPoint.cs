using System.Collections.Generic;
using UnityEngine;

public class ListOfPoint : MonoBehaviour
{
    private List<PointSpawn> _spawnPoints = new();
    
    private void Start()
    {
        FillList();
        SpawnCoin();
    }

    private void OnEnable()
    {
        Coin.PlayerTouched += SpawnCoin;
    }

    private void OnDisable()
    {
        Coin.PlayerTouched -= SpawnCoin;
    }
   
    public void SpawnCoin()
    {
        _spawnPoints[GeneratePointNumber()].SpawnCoin();
    }

    private void FillList()
    {
        foreach (Transform oneTransform in transform)
        {
            if (oneTransform.CompareTag(HashForTags.Point) && oneTransform.TryGetComponent(out PointSpawn spawnPoint))
            {
                _spawnPoints.Add(spawnPoint);
            }
        }
    }

    private int GeneratePointNumber()
    {
        int pointNumber = Random.Range(0, _spawnPoints.Count);

        return pointNumber;
    }
}
