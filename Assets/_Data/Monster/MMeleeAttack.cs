using UnityEngine;

public class MMeleeAttack : MonsterAttack
{
    [Header("Melee Attack")]
    [SerializeField] protected float attackRange = 0.4f;
    public LayerMask playerLayer;
    [SerializeField] protected float attackTimer;
    [SerializeField] protected float attackDelay = 1;
    [SerializeField] protected bool canAttack = false;
    [SerializeField] protected bool targetInDistance = false;

    protected override void Attack()
    {
        if(!InDistance() && !targetInDistance) return;

        canAttack = CanAttack();
        
        targetInDistance = true;

        StopMoveAround();

        float distance = Vector3.Distance(playerCtrl.transform.position, monsterCtrl.AttackPoint.position);

        ChaseTarget(distance);
        if(distance <= attackRange && canAttack) 
        {
            DealDamage();

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

    protected void StopMoveAround()
    {
        monsterCtrl.MonsterMovement.SetStop(true);
    }

    protected void ChaseTarget(float distance)
    {
        float distancePvsM = Vector3.Distance(playerCtrl.transform.position, transform.parent.position);
        float distanceMvsAP = Vector3.Distance(transform.parent.position, monsterCtrl.AttackPoint.position);
        
        if(distance <= attackRange) return;
        if(distancePvsM <= distanceMvsAP) return;
        SetDirection();
        SetModelDirection();
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

    protected bool CanAttack()
    {
        if(attackTimer < attackDelay) attackTimer += Time.fixedDeltaTime;
        if(attackTimer >= attackDelay) return true;
        return false;
    }

    protected void DealDamage()
    {
        Collider[] players = Physics.OverlapSphere(monsterCtrl.AttackPoint.position, attackRange, playerLayer);

        foreach (var player in players)
        {
            DealDamage(player);
        }
    }

    protected void OnDrawGizmosSelected()
    {
        Vector3 maxPoint = transform.parent.position + Vector3.right.normalized * distanceAttack;
        Vector3 minPoint = transform.parent.position + Vector3.left.normalized * distanceAttack;
        
        Gizmos.DrawLine(minPoint, maxPoint);

        Transform attackP = transform.parent.Find("AttackPoint"); 

        Gizmos.DrawSphere(attackP.position, attackRange);
    }
}