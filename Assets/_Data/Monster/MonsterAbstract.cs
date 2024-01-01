using UnityEngine;

public abstract class MonsterAbstract : LiMono
{
    [SerializeField] protected MonsterCtrl monsterCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMonsterCtrl();
    }

    protected void LoadMonsterCtrl()
    {
        if(monsterCtrl != null) return;

        monsterCtrl = transform.parent.GetComponent<MonsterCtrl>();

        Debug.LogWarning(transform.name + ": Load MonsterCtrl", gameObject);
    }
}