using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D _playerRigidbody2D;
    [SerializeField]
    private float _playerSpeed;
    private Vector2 _playerDirection;

    void Start() {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate() {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }

}
