using UnityEngine;

public class PlayerMeleeAttack : PlayerAttack
{
    [Header("Melee Attack")]
    public LayerMask monsterLayer;
    [SerializeField] protected float attackRange = 0.5f;
    [SerializeField] protected WeaponType weaponType = WeaponType.MeleeType;

    public WeaponType WeaponType => weaponType;

    protected override void DealDamage()
    {
        Collider[] monsters = Physics.OverlapSphere(playerCtrl.AttackPoint.position, attackRange, monsterLayer);

        foreach(Collider monster in monsters)
        {
            DealDamage(monster);
        }
    }

    protected void OnDrawGizmosSelected()
    {
        Transform attackPoint = transform.parent.Find("AttackPoint");

        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}