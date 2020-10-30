using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _currentPosition;

    [SerializeField] private float _smooth;
    private void Update()
    {
        CameraMoving();
    }

    private void CameraMoving()
    {
        float movingSpeed = Vector2.Distance(_target.position, _currentPosition.position) * _smooth;

        Vector3 targetPosition = new Vector3(_target.position.x, _target.position.y, -10);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movingSpeed * Time.deltaTime);
    }
}
