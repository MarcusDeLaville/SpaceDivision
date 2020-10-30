using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovenment : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private KeyCode _jumpButton;
    [SerializeField] private int _gravityScale = -1;
    private Vector2 _moveVectore;

    [Header("Flying Settings")]
    [SerializeField] private float _movePower;
    [SerializeField] private FlyingSatchel _flyingSatchel;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpForse;

    [Header("Walking Settings")]
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private float _rayLenght;
    [SerializeField] private float _walkSpeed;

    public bool InWeightlessness { get; private set; } = true;
    public bool IsMoving { get; private set; } = false;

    public int GravityScale => _gravityScale;

    private void FixedUpdate()
    {
        Move();

        if(_rigidbody.velocity.magnitude > _maxSpeed && InWeightlessness == true)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if(InWeightlessness == true)
        {
            _moveVectore = new Vector2(horizontalInput, verticalInput);

            if (Mathf.Abs(horizontalInput + verticalInput) > 0)
            {
                _flyingSatchel.ActiveFly(horizontalInput + verticalInput);

                if (!_flyingSatchel.IsWork)
                {
                    _moveVectore = Vector2.zero;
                }
                IsMoving = true;
            }
            else
            {
                _flyingSatchel.DisableFly();

                IsMoving = false;
            }

            _rigidbody.AddForce(_moveVectore * _movePower * Time.deltaTime, ForceMode2D.Force);
        }
        else if(InWeightlessness == false)
        {
            CheakGround();
           _moveVectore = new Vector2(horizontalInput, _gravityScale);
                
            if (Input.GetKey(_jumpButton) && _isGrounded)
            {
                Jump();
            }

            _rigidbody.AddForce(_moveVectore * _walkSpeed * Time.deltaTime, ForceMode2D.Force);
        }

        IsMoving = Mathf.Abs(horizontalInput + verticalInput) > 0 ? true : false;


        if (horizontalInput > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.down * _gravityScale * _jumpForse * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void CheakGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _rayLenght);
        Debug.DrawRay(transform.position, Vector2.up * _gravityScale * hit.distance, Color.cyan); 

        if (hit.collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    public void SetWeightlessnessStatus(bool isWeightlessness)
    {
        InWeightlessness = isWeightlessness;
    }

    public void SetGravityScale(int scale)
    {
        _gravityScale = scale;
    }


}
