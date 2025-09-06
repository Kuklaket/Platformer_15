using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
        Destroy(gameObject);
    }
}
