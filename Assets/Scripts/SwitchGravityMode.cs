using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityType
{
    Top,
    Down
}

public class SwitchGravityMode : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private PlayerMovenment _playerMovenment;
    [SerializeField] private GravityIndicator _gravityIndicator;

    [SerializeField] private KeyCode _switchButton;

    private GravityType _gravityType;

    private void Update()
    {
        if (_playerMovenment.InWeightlessness == true & _gravityType == GravityType.Top)
        {
            _gravityType = GravityType.Down;
            SetGravityType();
        }

        if (Input.GetKeyDown(_switchButton) & !_playerMovenment.InWeightlessness)
        {
            _gravityType = _gravityType == GravityType.Down ? GravityType.Top : GravityType.Down;

            SetGravityType();
        }
    }

    private void SetGravityType()
    {
        if (_gravityType == GravityType.Down)
        {
            _playerSprite.flipY = false;
            _playerMovenment.SetGravityScale(-1);
        }
        else
        {
            _playerSprite.flipY = true;
            _playerMovenment.SetGravityScale(1);
        }

        _gravityIndicator.SetIndicatorIcon(_gravityType);
    }

}
