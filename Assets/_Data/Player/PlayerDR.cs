public class PlayerDR : DamageReceiver
{
    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Player";
    }
}