using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/New Enemy")]
public class EnemyData : ScriptableObject
{
    public float health = 1;
    public float moveSpeedEnemy = 3.5f;

    [NonSerialized]
    public bool isDead = false;
    public RuntimeAnimatorController AnimatorController;
    private DetectionController detectionArea;
    private Vector2 enemyDirection;
    private Rigidbody2D enemyRB2D;
    private CapsuleCollider2D enemyBoxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator enemyAnimator;
}
