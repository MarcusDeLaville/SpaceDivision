using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Hint : MonoBehaviour
{
    [SerializeField] private Text _hintText;

    private void Start()
    {
        _hintText.DOFade(0, 0.1f);
    }

    public void ShowNewHint(string hintText)
    {
        _hintText.text = hintText;
        _hintText.DOFade(255, 3f);
        _hintText.DOFade(0, 3f).SetDelay(3);
    }
}
