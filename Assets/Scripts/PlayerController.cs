using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SwordAttack swordAttack;

    private BoxCollider2D playerBoxCollider;

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

    private float _playerInitialFatRate = 0;
    private float _playerCurrentFatRate;

    // private float _playerCurrentLives;

    public Text fatRateText;
    public Text deathText;
    public AudioSource audioSourceStep;
    public AudioSource audioSourceSword;

    private bool _isPlayerDead = false;
    private bool _isAttacking = false;
    private bool _isWide = false;
    private SpriteRenderer _spritRenderer;
    FoodController _foodController;
    public float stepInterval = 0.05f;
    private float nextStepTime = 0f;

    [SerializeField] Image vidaOn;
    [SerializeField] Image vidaOn2;
    [SerializeField] Image vidaOff;
    [SerializeField] Image vidaOff2;
    [SerializeField] Image vidaOff3;

    void Start() 
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();

        _playerInitialSpeed = _playerSpeed;
        
        _playerCurrentFatRate = _playerInitialFatRate;

        _playerAnimator = GetComponent<Animator>();

        _spritRenderer = GetComponent<SpriteRenderer>();

        playerBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update() 
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        PlayerRun();

        OnAttack();



        if (_playerDirection.sqrMagnitude > 0)
        {
            _playerAnimator.SetBool("isMoving", true); 
            if (Time.time >= nextStepTime)
            {
                audioSourceStep.Play();
                nextStepTime = Time.time + stepInterval;
            }
        } else {
            _playerAnimator.SetBool("isMoving", false);
            audioSourceStep.Stop();
        }

        if(_isAttacking){
            audioSourceSword.Play();
            _playerAnimator.SetTrigger("attack");
        }

        if(_isWide) {
            _playerAnimator.SetBool("isWide", true);
            _playerSpeed = 4;
            swordAttack.damage = 0.5f;
        } else {
            _playerAnimator.SetBool("isWide", false);
            _playerSpeed = 6;
            swordAttack.damage = 1f;
        }

        Flip();
    }

    void FixedUpdate() 
    {   

        if (!_isPlayerDead)
        { 
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection.normalized * _playerSpeed * Time.fixedDeltaTime);
        }
    }

    void UpdateFatRateText()
    {
        fatRateText.text = "Gordura: " + _playerCurrentFatRate.ToString() + "%";
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "Enemy") {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy.health > 0)
            {
                PlayerIncreaseFatRate(10f);
            }
        }
        if(other.gameObject.CompareTag("Food")) {
            RecoverFatRate(20f);
            FoodController food = other.gameObject.GetComponent<FoodController>();
            food.DestroyFood();
        }
    }

    void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            print("To CORRENDO");
            _playerSpeed = _playerRunSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            print("To andando");
            _playerSpeed = _playerInitialSpeed;
        }
    }

    // void PlayerTakeDamage(float damage)
    // {
    //     _playerCurrentLives -= damage;

    //     VerifyLife();

    //     if (_playerCurrentLives <= 0)
    //     {
    //         _isPlayerDead = true;

    //         Dead();

    //         // vidaOff.enabled = false;
    //         // vidaOff2.enabled = false;
    //         // vidaOff3.enabled = false;
    //     }
    // }

    void PlayerIncreaseFatRate(float damage)
    {
        _playerCurrentFatRate += damage;

        VerifyLife();

        // if (_playerCurrentLives <= 0)
        // {
        //     _isPlayerDead = true;

        //     Dead();

        //     // vidaOff.enabled = false;
        //     // vidaOff2.enabled = false;
        //     // vidaOff3.enabled = false;
        // }

        if (_playerCurrentFatRate > 99)
        {
            _isPlayerDead = true;

            Dead();

            // vidaOff.enabled = false;
            // vidaOff2.enabled = false;
            // vidaOff3.enabled = false;
        }
    }

    void VerifyLife() {
        print(_playerCurrentFatRate);
        UpdateFatRateText();

        if (_playerCurrentFatRate >= 50)
        {
            _isWide = true;
        } else if (_playerCurrentFatRate < 50) {
            _isWide = false;
        }

        // if (_playerCurrentLives < 3) {
        //     _isWide = true;
        // } else if (_playerCurrentLives > 2) {
        //     _isWide = false;
        // }

        // if (_playerCurrentLives < 3.0f && _playerCurrentLives >= 2.0f)
        // {
        //     vidaOn2.enabled = true;
        //     vidaOff2.enabled = false;
        // } else {
        //     vidaOn2.enabled = false;
        //     vidaOff2.enabled = true;
        // }

        // if (_playerCurrentLives < 2.0f && _playerCurrentLives > 0f)
        // {
        //     vidaOn2.enabled = true;
        //     vidaOff2.enabled = false;

        //     vidaOn.enabled = true;
        //     vidaOff.enabled = false;
        // } else {
        //     vidaOn.enabled = false;
        //     vidaOff.enabled = true;
        // }
    }

    // void RecoverLife(float life) {
    //     if (_playerCurrentLives < 3)
    //     {
    //         _playerCurrentLives += life;
    //         VerifyLife();
    //     }
    // }

    void RecoverFatRate(float life) {
        if (_playerCurrentFatRate > 0)
        {
            _playerCurrentFatRate -= life;
            if (_playerCurrentFatRate < 0)
            {
                _playerCurrentFatRate = 0;
            }
            VerifyLife();
        }
    }

    void Dead() {

        IEnumerator activeDeathText()
        {
            yield return new WaitForSeconds(2f);
            deathText.enabled = true;
        }


        if (_isPlayerDead)
        {
            _playerAnimator.SetTrigger("isDead");
            playerBoxCollider.enabled = false;
            StartCoroutine(activeDeathText());
            Invoke(nameof(ChangeSceneToMenu), 5f);
        }
    }

    void ChangeSceneToMenu() {
        SceneManager.LoadSceneAsync(0);
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
    }

    public void SwordAttack() {
        if (_spritRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        } else {
            swordAttack.AttackRight();
        }
    }

    public void EndSwordAttack() {
        swordAttack.StopAttack();
    }

    void Flip() {
        if (_playerDirection.x > 0)
        {
            _spritRenderer.flipX = false;
        } else if(_playerDirection.x < 0)
        {
            _spritRenderer.flipX = true;
        }
    }
}
