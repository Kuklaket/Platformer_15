using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private CoinsCounter _coinsCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Collect();
            _coinsCounter.AddCoin();
        }     
    }
}
