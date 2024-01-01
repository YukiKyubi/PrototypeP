public class MonsterDR : DamageReceiver
{
    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Monster";
    }
}