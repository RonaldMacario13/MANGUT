using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _playerRigidbody2D;
    [SerializeField]
    private float _playerSpeed;
    private float _playerInitialSpeed;
    [SerializeField]
    private float _playerRunSpeed;
    private Vector2 _playerDirection;

    void Start() 
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();

        _playerInitialSpeed = _playerSpeed;
    }

    void Update() 
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        PlayerRun();
    }

    void FixedUpdate() 
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection.normalized * _playerSpeed * Time.fixedDeltaTime);
    }

    void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _playerSpeed = _playerRunSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _playerSpeed = _playerInitialSpeed;
        }
    }

}
