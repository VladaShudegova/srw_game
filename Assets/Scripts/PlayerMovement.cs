using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;



public class PlayerMovement : MonoBehaviour, IControllable
{
    #region VARIABLES

    private Vector2 _inputDirection;

    [SerializeField] private float _speed;
    //[SerializeField] private float _verticalSpeed = -1f;
    [SerializeField] private LayerMask _checkerLayerMask;
    [SerializeField] private float jumpForce = 12.0f;
    [SerializeField] private float _gravity = -9.81f;
    //[SerializeField] private float _jumpHeight = 3f;

    [SerializeField] private Vector2 _capsuleSize;
    [SerializeField] private CapsuleDirection2D _capsuleDirection;
    [SerializeField] private float _groundCheckDistance = 0.1f;
    [SerializeField] private float radiusLegs = 0.04f;
    [SerializeField] Transform legs;

    private float _velocity;
    private bool _onGround = false;
    private Rigidbody2D _body;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider;
    #endregion

    private void Awake(){
        _collider = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
        _spriteRenderer  = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        IsOnTheGround();


        if (_onGround && _velocity < 0)
        {
            _velocity = -1;
        }
        Move();
        Jump();
        DoGravity();
    }


    public void InputUpdate(Vector2 inputDirection){
        _inputDirection = inputDirection;
    }

    private void Move(){
        Vector3 moveDirection = new Vector3(_inputDirection.x, 0.0f, 0.0f);

        transform.Translate(moveDirection * _speed * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        if (!_onGround)
        {
            //_onGround = true;
            _body.velocity = new Vector2(0, 0);
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //_body.velocity += Vector2.up * _gravity * Time.fixedDeltaTime;
           
            //_body.AddForce(Vector2.up * speed * _gravity, ForceMode2D.Impulse);
        }
       
    }



    private void DoGravity()
    {
        _velocity += _gravity * Time.fixedDeltaTime;

        transform.Translate(Vector3.up * _velocity * Time.fixedDeltaTime);

  
    }

    private void IsOnTheGround()
    {
        _onGround = !Physics2D.OverlapCircle(legs.position, radiusLegs, _checkerLayerMask);

    }


}
