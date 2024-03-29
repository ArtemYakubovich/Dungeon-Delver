using UnityEngine;

public class Dray : MonoBehaviour
{
    public enum eMode { idle, move, attack, transition}
    [Header("Set in Inspector")]
    public float speed = 5f;
    public float attackDuration = 0.25f;
    public float attackDelay = 0.5f;

    [Header("Set Dynamically")] 
    public int dirHeld = -1;
    public int facing = 1;
    public eMode mode = eMode.idle;

    private float timeAttackDone = 0;
    private float timeAttackNext = 0;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private Vector3[] _directions = new Vector3[] { Vector3.right, Vector3.up, Vector3.left, Vector3.down };

    private KeyCode[] _keys = new KeyCode[]
        { KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow };

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        dirHeld = -1;

        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKey(_keys[i])) dirHeld = i;
        }

        if (Input.GetKeyDown(KeyCode.Z) && Time.time >= timeAttackNext)
        {
            mode = eMode.attack;
            timeAttackDone = Time.time + attackDuration;
            timeAttackNext = Time.time + attackDelay;
        }

        if (Time.time >= timeAttackDone)
        {
            mode = eMode.idle;
        }

        if (mode != eMode.attack)
        {
            if (dirHeld == -1)
            {
                mode = eMode.idle;
            }
            else
            {
                facing = dirHeld;
                mode = eMode.move;
            }
        }

        Vector3 vel = Vector3.zero;

        switch (mode)
        {
            case eMode.attack:
                _animator.CrossFade($"Dray_Attack_{facing}",0);
                _animator.speed = 0;
                break;
            case eMode.idle:
                _animator.CrossFade($"Dray_Walk_{facing}",0);
                _animator.speed = 0;
                break;
            case eMode.move:
                vel = _directions[dirHeld];
                _animator.CrossFade($"Dray_Walk_{facing}",0);
                _animator.speed = 1;
                break;
        }
        
        _rigidbody.velocity = vel * speed;
    }
}
