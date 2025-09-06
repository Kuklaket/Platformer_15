using System;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    public event Action<Coin> CoinSpawned;

    public void SpawnCoin()
    {
        Coin currentCoin = Instantiate(_coin,transform.position, Quaternion.identity);
        CoinSpawned?.Invoke(currentCoin);
    }
}
