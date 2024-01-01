using UnityEngine;

public class MShooting : MonsterAbstract
{
    [SerializeField] protected Transform bullet;

    public void Shoot()
    {
        GameCtrl.Instance.BulletCtrl.BulletDL.SetDealer(EntityType.Monster);
        Instantiate(bullet, monsterCtrl.AttackPoint.position, monsterCtrl.AttackPoint.rotation);
    }
}