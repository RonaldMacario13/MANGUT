using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Vector2 rightAttackOffset;
    public Collider2D swordCollider;

    public float damage = 1;

    // Start is called before the first frame update
    private void Start()
    {
        rightAttackOffset = transform.localPosition;
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Health -= damage;
        }
    }
}
