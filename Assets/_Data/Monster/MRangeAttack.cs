using UnityEngine;

public class MRangeAttack : MonsterAttack
{
    [Header("Range Attack")]
    [SerializeField] protected float attackDelay = 1f;
    [SerializeField] protected float attackTimer;
    [SerializeField] protected float attackRange;
    [SerializeField] protected bool canAttack = false;
    [SerializeField] protected bool targetInDistance = false;

    protected override void Start()
    {
        base.Start();
        attackRange = distanceAttack;
    }

    protected override void Attack()
    {
        if(!InDistance() && !targetInDistance) return;

        canAttack = CanAttack();
        
        targetInDistance = true;

        StopMoveAround();

        float distance = Vector3.Distance(playerCtrl.transform.position, transform.parent.position);

        ChaseTarget(distance);
        RotateAttackPoint();

        if(distance <= attackRange && canAttack)
        {
            monsterCtrl.Shooting.Shoot();

            canAttack = false;
            attackTimer = 0;
        }
    }

    protected bool InDistance()
    {
        float distance = Vector3.Distance(playerCtrl.transform.position, transform.parent.position);

        if(distance <= distanceAttack) return true;
        return false;
    }

    protected bool CanAttack()
    {
        if(attackTimer < attackDelay) attackTimer += Time.fixedDeltaTime;
        if(attackTimer >= attackDelay) return true;
        return false;
    }

    protected void StopMoveAround()
    {
        monsterCtrl.MonsterMovement.SetStop(true);
    }

    protected void ChaseTarget(float distance)
    {
        SetDirection();
        SetModelDirection();
        if(distance <= attackRange) return;
        Follow();
    }

    protected void SetDirection()
    {
        if(transform.parent.position.x > playerCtrl.transform.position.x)
        {
            monsterCtrl.MonsterMovement.SetRight(false);
        }
        else
        {
            monsterCtrl.MonsterMovement.SetRight(true);
        }
    }

    protected void SetModelDirection()
    {
        monsterCtrl.MonsterMovement.SetModelDirection();
    }

    protected void Follow()
    {
        bool isRight = monsterCtrl.MonsterMovement.IsRight;
        float speed = monsterCtrl.MonsterMovement.Speed;

        if(isRight)
        {
            transform.parent.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.parent.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }
    }

    protected void RotateAttackPoint()
    {
        Vector3 playerPos = playerCtrl.transform.position;
        Vector3 attackPoint = monsterCtrl.AttackPoint.position;
        Vector3 direction = playerPos - attackPoint;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        monsterCtrl.AttackPoint.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}