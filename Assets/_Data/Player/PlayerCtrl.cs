using UnityEditor;
using UnityEngine;

public class PlayerCtrl : LiMono 
{
    [SerializeField] protected Transform model;

    public Transform Model => model;

    [SerializeField] protected Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    [SerializeField] protected Transform attackPoint;

    public Transform AttackPoint => attackPoint;

    [SerializeField] protected PlayerMeleeAttack playerMeleeAttack;

    public PlayerMeleeAttack PlayerMeleeAttack => playerMeleeAttack;

    [SerializeField] protected PlayerRangeAttack playerRangeAttack;

    public PlayerRangeAttack PlayerRangeAttack => playerRangeAttack;

    [SerializeField] protected Shooting shooting;

    public Shooting Shooting => shooting;

    protected override void Start()
    {
        base.Start();
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadRigidBody();
        LoadAttackPoint();
        LoadPlayerMeleeAttack();
        LoadPlayerRangeAttack();
        LoadShooting();
    }

    protected void LoadModel()
    {
        if(model != null) return;

        model = transform.Find("Model");

        Debug.LogWarning(transform.name + ": Load Model", gameObject);
    }

    protected void LoadRigidBody()
    {
        if(this._rigidbody != null) return;

        this._rigidbody = GetComponent<Rigidbody>();

        Debug.LogWarning(transform.name + ": Load RigidBody", gameObject);
    }

    protected void LoadAttackPoint()
    {
        if(attackPoint != null) return;

        attackPoint = transform.Find("AttackPoint");

        Debug.LogWarning(transform.name + ": Load AttackPoint", gameObject);
    }

    protected void LoadPlayerMeleeAttack() 
    {
        if(playerMeleeAttack != null) return;

        playerMeleeAttack = transform.GetComponentInChildren<PlayerMeleeAttack>();

        Debug.LogWarning(transform.name + ": Load PlayerMeleeAttack", gameObject);
    }

    protected void LoadPlayerRangeAttack()
    {
        if(playerRangeAttack != null) return;

        playerRangeAttack = transform.GetComponentInChildren<PlayerRangeAttack>();

        Debug.LogWarning(transform.name + ": Load PlayerRangeAttack", gameObject);
    }

    protected void LoadShooting()
    {
        if(shooting != null) return;

        shooting = GetComponentInChildren<Shooting>();

        Debug.LogWarning(transform.name + ": Load Shooting", gameObject);
    }
}