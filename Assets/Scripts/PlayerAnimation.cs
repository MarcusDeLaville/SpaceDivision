using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovenment _playerMovenment;
    [SerializeField] private FlyingSatchel _flyingSatchel;

    private void Update()
    {
        SetAnimation();
    }

    private void SetAnimation()
    {
        if (_playerMovenment.InWeightlessness)
        {
            if (_flyingSatchel.IsWork)
            {
                _animator.SetBool("isFly", true);
                _animator.SetBool("isGrounded", false);

            }
            else
            {
                _animator.SetBool("isFly", false);
            }
        }
        if(!_playerMovenment.InWeightlessness)
        {
            _animator.SetBool("isGrounded", true);
            _animator.SetBool("isFly", false);

            if (_playerMovenment.IsMoving)
            {
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _animator.SetBool("isWalking", false);
            }
        }
    }

}
