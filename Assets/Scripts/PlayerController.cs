using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _playerRigidbody2D;
    [SerializeField]
    private float _playerSpeed;
    private float _playerInitialSpeed;
    [SerializeField]
    private float _playerRunSpeed;
    private Vector2 _playerDirection;
    [SerializeField]
    private Animator _playerAnimator;
    private float _playerInitialLives = 3;
    private float _playerCurrentLives;
    private bool _isPlayerDead = false;
    private bool _isAttacking = false;


    [SerializeField] Image vidaOn;
    [SerializeField] Image vidaOn2;
    [SerializeField] Image vidaOff;
    [SerializeField] Image vidaOff2;

    void Start() 
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();

        _playerInitialSpeed = _playerSpeed;

        _playerCurrentLives = _playerInitialLives;
    }

    void Update() 
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        PlayerRun();

        OnAttack();

        if(_isAttacking){
            _playerAnimator.SetInteger("Movimento", 2);
        } else {
            _playerAnimator.SetInteger("Movimento", 0);
        }

        // _playerInitialLives = Mathf.Clamp(_playerInitialLives, 0, 3);
        Debug.Log(_playerCurrentLives);
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
