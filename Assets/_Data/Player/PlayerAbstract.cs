using UnityEngine;

public abstract class PlayerAbstract : LiMono
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    protected void LoadPlayerCtrl()
    {
        if(playerCtrl != null) return;

        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();

        Debug.LogWarning(transform.name + ": Load PlayerCtrl", gameObject);
    }
}