using UnityEngine;

public class MonsterCtrl : LiMono
{
    [SerializeField] protected DamageReceiver damageReceiver;
    [SerializeField] protected Transform rightPoint;

    public Transform RightPoint => rightPoint;

    [SerializeField] protected Transform leftPoint;

    public Transform LeftPoint => leftPoint;

    [SerializeField] protected Transform model;

    public Transform Model => model;

    [SerializeField] protected Transform attackPoint;

    public Transform AttackPoint => attackPoint;

    [SerializeField] protected MonsterMovement monsterMovement;

    public MonsterMovement MonsterMovement => monsterMovement;

    [SerializeField] protected MShooting shooting;

    public MShooting Shooting => shooting;

    protected override void Start()
    {
        base.Start();
        gameObject.layer = LayerMask.NameToLayer("Monster");
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDR();
        LoadRightAndLeftPoint();
        LoadModel();
        LoadAttackPoint();
        LoadMonsterMovement();
        LoadShooting();
    }

    protected void LoadDR()
    {
        if(damageReceiver != null) return;

        damageReceiver = GetComponentInChildren<DamageReceiver>();

        Debug.LogWarning(transform.name + ": Load DR", gameObject);
    }

    protected void LoadRightAndLeftPoint() 
    {
        if(leftPoint != null && rightPoint != null) return;



        leftPoint = GameObject.Find("FixedPoint").transform.Find("MLeftPoint");
        rightPoint = GameObject.Find("FixedPoint").transform.Find("MRightPoint");

        Debug.LogWarning(transform.name + ": Load LeftAndRightPoint", gameObject);
    }

    protected void LoadModel()
    {
        if(model != null) return;

        model = transform.Find("Model");

        Debug.LogWarning(transform.name + ": Load Model", gameObject);
    }

    protected void LoadAttackPoint()
    {
        if(attackPoint != null) return;

        attackPoint = transform.Find("AttackPoint");

        Debug.LogWarning(transform.name + ": Load AttackPoint", gameObject);
    }

    protected void LoadMonsterMovement()
    {
        if(monsterMovement != null) return;

        monsterMovement = GetComponentInChildren<MonsterMovement>();

        Debug.LogWarning(transform.name + ": Load MonsterMovement", gameObject);
    }

    protected void LoadShooting()
    {
        if(shooting != null) return;

        shooting = GetComponentInChildren<MShooting>();

        Debug.LogWarning(transform.name + ": Load Shooting", gameObject);
    }
}