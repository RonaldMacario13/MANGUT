using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/New Enemy")]
public class EnemyData : ScriptableObject
{
    public float health = 1;
    public float moveSpeedEnemy = 3.5f;

    private DetectionController detectionArea;
    [NonSerialized]
    public bool isDead = false;
    private Vector2 enemyDirection;
    private Rigidbody2D enemyRB2D;
    private CapsuleCollider2D enemyBoxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator enemyAnimator;
}
