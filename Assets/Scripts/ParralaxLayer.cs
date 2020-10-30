using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxLayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerVelosity;
    [SerializeField] private int _divisionMultiplier;
    [SerializeField] private float _smooth;

    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, _startPosition + -(_playerVelosity.velocity / _divisionMultiplier), _smooth * Time.deltaTime);
    }
}
