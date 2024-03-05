using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Vector2 leftAttackOffset;
    Collider2D swordCollider;

    public float damage = 3;

    // Start is called before the first frame update
    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        leftAttackOffset = transform.position;
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.position = new Vector3(leftAttackOffset.x * (-1), leftAttackOffset.y, 0f);
        Debug.Log("atacando direita!");
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.position = leftAttackOffset;
        Debug.Log("atacando esquerda!");
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        BrigadeiroController brigadeiro = other.GetComponent<BrigadeiroController>();

        if (other.tag == "Enemy")
        {
            brigadeiro.Health -= damage;
        }
    }
}
