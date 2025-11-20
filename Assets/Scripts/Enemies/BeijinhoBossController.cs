using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeijinhoBossController : MonoBehaviour
{
    public int health;

    public String name;
    
    public Text hpText;

    public Text hitText;

    private Animator animator;

    private void Start()
    {
        UpdateHPText();

        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        Invoke(nameof(UpdateHPText), 0.8f);

        if (hitText != null)
        {
            hitText.text = name + " levou dano!";
        }

        Invoke(nameof(ResetHitText), 1f);

        if (health <= 0)
        {
            Invoke(nameof(Die), 1.2f);
        }
    }



    void UpdateHPText()
    {
        if (hitText != null)
        {
            hitText.text = "";
        }
    }

    void ResetHitText()
    {
        if (hpText != null)
        {
            hpText.text = "VIDA: " + health.ToString();
        }
    }

    void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("death");  // Ativa o trigger no Animator
        }

        hpText.text = "";

        //Destroy(gameObject);
    }
}
