using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class Prologue : MonoBehaviour
{
    [SerializeField] private List<ProloguePart> _prologueParts;

    [SerializeField] private Image _pictureImage;
    [SerializeField] private Text _discriptionText;
    [SerializeField] private int _currentProloguePart;

    [SerializeField] private GameObject _closeButton;
    [SerializeField] private GameObject _nextButton;

    [SerializeField] private string _prologueKey = "Prologue";

    public UnityEvent StartPrologue;

    private void Start()
    {
        if (PlayerPrefs.GetInt(_prologueKey) != 1)
        {
            StartPrologue.Invoke();
        }
    }

    public void NextProloguePart()
    {
        _currentProloguePart++;

        if (_currentProloguePart == _prologueParts.Count)
        {
            _nextButton.SetActive(false);
            _closeButton.SetActive(true);

            PlayerPrefs.SetInt(_prologueKey, 1);
        }
        if (_currentProloguePart < _prologueParts.Count)
        {
            SetCurrentProloguePart();
        }
    }

    private void SetCurrentProloguePart()
    {
        _pictureImage.sprite = _prologueParts[_currentProloguePart].Picture;
        _discriptionText.text = _prologueParts[_currentProloguePart].Discription;
    }

    [Serializable]
    public struct ProloguePart
    {
        public string Discription;
        public Sprite Picture;
    }
}
