using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigadeiroController : MonoBehaviour
{

    public float _moveSpeedBrigadeiro = 3.5f;   
    private bool isDead = false;
    private Vector2 _brigadeiroDirection;
    private CapsuleCollider2D brigadeiroBoxCollider;
    private Rigidbody2D _brigadeiroRB2D;
    private Animator _brigadeiroAnimator;

    public float health = 1;

    public DetectionController _detectionArea;

    private SpriteRenderer _spritRenderer;

    public GameObject canva;

    // Start is called before the first frame update
    void Start()
    {
        _brigadeiroRB2D = GetComponent<Rigidbody2D>();
        _spritRenderer = GetComponent<SpriteRenderer>();
        _brigadeiroAnimator = GetComponent<Animator>();
        brigadeiroBoxCollider = GetComponent<CapsuleCollider2D>();
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
                _brigadeiroAnimator.SetBool("isMoving", true);

                _brigadeiroDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

                _brigadeiroRB2D.MovePosition(_brigadeiroRB2D.position + _brigadeiroDirection * _moveSpeedBrigadeiro * Time.fixedDeltaTime);

                canva.SetActive(true);

                if (_brigadeiroDirection.x > 0)
                {
                    _spritRenderer.flipX = false;
                }
                else if (_brigadeiroDirection.x < 0)
                {
                    _spritRenderer.flipX = true;
                }
            } else if (_detectionArea.detectedObjs.Count == 0)
            {
                _brigadeiroAnimator.SetBool("isMoving", false);

                canva.SetActive(false);
              //  _nutritionDialog.HideDialog();
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
        _brigadeiroAnimator.SetTrigger("death");
        isDead = true;
        brigadeiroBoxCollider.enabled = false;
    }
}
