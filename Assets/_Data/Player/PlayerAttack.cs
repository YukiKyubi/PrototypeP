using UnityEngine;

public class PlayerAttack : DamageDealer
{
    [SerializeField] protected bool canAttack = false;
    [SerializeField] protected float attackDelay = 1;
    [SerializeField] protected float attackTimer;
    protected PlayerCtrl playerCtrl;

    protected override void Start()
    {
        base.Start();

        playerCtrl = GameCtrl.Instance.PlayerCtrl;
    }

    protected virtual void FixedUpdate()
    {
        Attack();
    }

    protected void Attack()
    {
        canAttack = CanAttack();

        if(!canAttack)  return;
        if(IsClickAttack())
        {
            DealDamage();

            canAttack = false;
            attackTimer = 0;
        }
    }

    protected bool CanAttack()
    {
        if(attackTimer < attackDelay) attackTimer += Time.fixedDeltaTime;
        if(attackTimer > attackDelay) return true;
        return false;
    }

    protected bool IsClickAttack()
    {
        return InputManager.Instance.OnAttacking > 0;
    }

    protected virtual void DealDamage()
    {
        //Override
    }
}