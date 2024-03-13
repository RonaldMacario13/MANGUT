using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeijinhoController : MonoBehaviour
{

    public float _moveSpeedBeijinho = 3.5f;
    private bool isDead = false;
    private Vector2 _beijinhoDirection;
    private Rigidbody2D _beijinhoRB2D;
    private Animator _beijinhoAnimator;
    public float health = 1;

    public DetectionController _detectionArea;

    private SpriteRenderer _spritRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _beijinhoRB2D = GetComponent<Rigidbody2D>();
        _spritRenderer = GetComponent<SpriteRenderer>();
        _beijinhoAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        if (!isDead)
        {
            if (_detectionArea.detectedObjs.Count > 0)
            {
                _beijinhoAnimator.SetBool("isMoving", true);

                _beijinhoDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

                _beijinhoRB2D.MovePosition(_beijinhoRB2D.position + _beijinhoDirection * _moveSpeedBeijinho * Time.fixedDeltaTime);

                if (_beijinhoDirection.x > 0)
                {
                    _spritRenderer.flipX = false;
                }
                else if (_beijinhoDirection.x < 0)
                {
                    _spritRenderer.flipX = true;
                }
            } else if (_detectionArea.detectedObjs.Count == 0)
            {
                _beijinhoAnimator.SetBool("isMoving", false);
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
        _beijinhoAnimator.SetTrigger("death");
        isDead = true;
        // Destroy(gameObject);
    }
}
