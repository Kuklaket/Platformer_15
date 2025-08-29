using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private Text _text;

    private int _coinCount = 0;

    private void Update()
    {
        _text.DOText(_coinCount.ToString(), 0);
    }
    public void AddCoin()
    {
        _coinCount++;
    }
}
