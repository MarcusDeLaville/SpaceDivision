using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnInterection()
    {
        _animator.SetBool("isOpen", true);
    }
}
