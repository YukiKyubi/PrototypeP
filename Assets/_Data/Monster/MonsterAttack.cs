using System;
using UnityEngine;

public abstract class MonsterAttack : DamageDealer
{
    protected MonsterCtrl monsterCtrl;
    protected PlayerCtrl playerCtrl;
    [SerializeField] protected float distanceAttack = 5f;

    protected override void Start()
    {
        base.Start();
        monsterCtrl = GameCtrl.Instance.MonsterCtrl;
        playerCtrl = GameCtrl.Instance.PlayerCtrl;
    }

    protected void FixedUpdate()
    {
        Attack();
    }

    protected abstract void Attack();
}