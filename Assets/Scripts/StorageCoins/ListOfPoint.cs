using System.Collections.Generic;
using UnityEngine;

public class ListOfPoint : MonoBehaviour
{
    [SerializeField] private Coin _currentCoin;

    private List<PointSpawn> _spawnPoints = new();

    private void Start()
    {
        FillList();
        SpawnCoin();
    }

    private void HandleCoinCollected(Coin coin)
    {
        SpawnCoin();
        coin.Collected -= HandleCoinCollected;
    }

    private void HandleCoinSpawned(Coin nextCoin)
    {
        if (_currentCoin != null)
        {
            _currentCoin.Collected -= HandleCoinCollected;
        }

        _currentCoin = nextCoin;
        _currentCoin.Collected += HandleCoinCollected;
    }

    public void SpawnCoin()
    {
        _spawnPoints[GeneratePointNumber()].SpawnCoin();
    }

    private void FillList()
    {
        foreach (Transform oneTransform in transform)
        {
            if (oneTransform.TryGetComponent(out PointSpawn spawnPoint))
            {
                _spawnPoints.Add(spawnPoint);
                spawnPoint.CoinSpawned += HandleCoinSpawned;
            }
        }
    }

    private int GeneratePointNumber()
    {
        int pointNumber = Random.Range(0, _spawnPoints.Count);

        return pointNumber;
    }
}
