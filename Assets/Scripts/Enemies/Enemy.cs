using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;
    
    public float health;
    [SerializeField]
    private float moveSpeedEnemy;

    [SerializeField]
    private DetectionController detectionArea;
    private bool isDead;
    private Vector2 enemyDirection;
    private Rigidbody2D enemyRB2D;
    private CapsuleCollider2D enemyBoxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator enemyAnimator;

    void Start()
    {
        health = enemyData.health;
        moveSpeedEnemy = enemyData.moveSpeedEnemy;
        isDead = enemyData.isDead;

        enemyRB2D = GetComponent<Rigidbody2D>();
        enemyBoxCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        if (!isDead)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        if (detectionArea.detectedObjs.Count > 0)
            {
                enemyAnimator.SetBool("isMoving", true);

                enemyDirection = (detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

                enemyRB2D.MovePosition(enemyRB2D.position + enemyDirection * moveSpeedEnemy * Time.fixedDeltaTime);

                if (enemyDirection.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                else if (enemyDirection.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
            } else if (detectionArea.detectedObjs.Count == 0)
            {
                enemyAnimator.SetBool("isMoving", false);
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
        enemyAnimator.SetTrigger("death");
        isDead = true;
        enemyBoxCollider.enabled = false;
    }
}