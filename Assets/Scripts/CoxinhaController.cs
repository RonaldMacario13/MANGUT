using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoxinhaController : MonoBehaviour
{
    public float _moveSpeedCoxinha = 2.0f;
    private bool isDead = false;
    private Vector2 _coxinhaDirection;
    private CapsuleCollider2D coxinhaBoxCollider;
    private Rigidbody2D _coxinhaRB2D;
    private Animator _coxinhaAnimator;

    public float health = 3;

    public DetectionController _detectionArea;

    private SpriteRenderer _spritRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _coxinhaRB2D = GetComponent<Rigidbody2D>();
        _spritRenderer = GetComponent<SpriteRenderer>();
        _coxinhaAnimator = GetComponent<Animator>();
        coxinhaBoxCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (!isDead)
        {
            if (_detectionArea.detectedObjs.Count > 0)
            {
                _coxinhaAnimator.SetBool("isMoving", true);

                _coxinhaDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

                _coxinhaRB2D.MovePosition(_coxinhaRB2D.position + _coxinhaDirection * _moveSpeedCoxinha * Time.fixedDeltaTime);

                if (_coxinhaDirection.x > 0)
                {
                    _spritRenderer.flipX = false;
                }
                else if (_coxinhaDirection.x < 0)
                {
                    _spritRenderer.flipX = true;
                }
            } else if (_detectionArea.detectedObjs.Count == 0)
            {
                _coxinhaAnimator.SetBool("isMoving", false);
            }    
        }
    }

    public float Health {
        set {
            health = value;
            if (health <= 0)
            {
                Defeated();
            }        
        }
        get {
            return health;
        }

    }

    public void Defeated(){
        _coxinhaAnimator.SetTrigger("death");
        isDead = true;
        coxinhaBoxCollider.enabled = false;
        // Destroy(gameObject);
    }
}
