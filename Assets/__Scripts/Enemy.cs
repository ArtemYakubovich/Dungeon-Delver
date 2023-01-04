using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected static Vector3[] directions = new Vector3[] { Vector3.right, Vector3.up, Vector3.left, Vector3.down };

    [Header("Set in Inspector: Enemy")]
    public float maxHealth = 1;

    [Header("Set Dynamically: Enemy")] 
    public float health;

    protected Animator _animator;
    protected Rigidbody _rigidbody;
    protected SpriteRenderer _spriteRenderer;

    protected void Awake()
    {
        health = maxHealth;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
