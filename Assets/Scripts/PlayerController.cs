using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SwordAttack swordAttack;

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

        _playerAnimator = GetComponent<Animator>();
    }

    void Update() 
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        PlayerRun();

        OnAttack();



        if (_playerDirection.sqrMagnitude > 0)
        {
            _playerAnimator.SetBool("isMoving", true);
        } else {
            _playerAnimator.SetBool("isMoving", false);
        }

        if(_isAttacking){
            _playerAnimator.SetTrigger("attack");
        }
        //  else {
        //     _playerAnimator.SetInteger("Movimento", 0);
        // }

        Flip();
        // _playerInitialLives = Mathf.Clamp(_playerInitialLives, 0, 3);
        // Debug.Log(_playerCurrentLives);
    }

    void FixedUpdate() 
    {   
        // if (_playerDirection != Vector2.zero)
        // {
        //     _playerAnimator.SetBool("isMoving", true);
        // }
        if (!_isPlayerDead)
        { 
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection.normalized * _playerSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy") {
            PlayerTakeDamage(1.0f);
        }
    }

    void PlayerRun()
    {
        // Debug.Log("Entrou na parada de correr");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _playerSpeed = _playerRunSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _playerSpeed = _playerInitialSpeed;
        }
    }

    void PlayerTakeDamage(float damage)
    {
        _playerCurrentLives -= damage;

        if (_playerCurrentLives == 2.0f)
        {
            vidaOn2.enabled = true;
            vidaOff2.enabled = false;
        } else {
            vidaOn2.enabled = false;
            vidaOff2.enabled = true;
        }

        if (_playerCurrentLives == 1.0f)
        {
            vidaOn2.enabled = true;
            vidaOff2.enabled = false;

            vidaOn.enabled = true;
            vidaOff.enabled = false;
        } else {
            vidaOn.enabled = false;
            vidaOff.enabled = true;
        }

        if (_playerCurrentLives <= 0)
        {
            _isPlayerDead = true;
            // Debug.Log("O jogador morreu!");
            Dead();
        }
    }

    void Dead() {
        if (_isPlayerDead)
        {
            // Debug.Log("O jogador morreu!");
            _playerAnimator.SetTrigger("isDead");
            // Thread.Sleep(10000);
            // SceneManager.LoadScene("Menu");
        }
    }

    void OnAttack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _isAttacking = true;
            _playerSpeed = 0;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            _isAttacking = false;
            _playerSpeed = _playerInitialSpeed;
        }

        if (_playerDirection.x > 0)
        {
            swordAttack.AttackRight();
        } else if(_playerDirection.x < 0)
        {
            swordAttack.AttackLeft();
        }
    }

    void Flip() {
        if (_playerDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        } else if(_playerDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }
}
