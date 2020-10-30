using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityIndicator : MonoBehaviour
{
    [SerializeField] private Sprite _gravityDown;
    [SerializeField] private Sprite _gravityTop;
    [SerializeField] private Image _gravityIndicator;

    public void SetIndicatorIcon(GravityType gravityType)
    {
        if (gravityType == GravityType.Down)
        {
            _gravityIndicator.sprite = _gravityDown;
        }
        else if(gravityType == GravityType.Top)
        {
            _gravityIndicator.sprite = _gravityTop;
        }
    }
}
