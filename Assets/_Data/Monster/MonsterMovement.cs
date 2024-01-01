using UnityEngine;

public class MonsterMovement : MonsterAbstract
{
    [Header("Movement")]
    [SerializeField] protected float speed = 1f;

    public float Speed => speed;

    [SerializeField] protected bool isRight = true;

    public bool IsRight => isRight;

    [SerializeField] protected bool isStop = false;
    [SerializeField] protected float moveDistance;
    [SerializeField] protected Transform leftPoint;
    [SerializeField] protected Transform rightPoint;

    protected override void Start()
    {
        base.Start();

        leftPoint = monsterCtrl.LeftPoint;
        rightPoint = monsterCtrl.RightPoint;
        moveDistance = Vector3.Distance(leftPoint.position, rightPoint.position);
    }

    protected void Update()
    {
        Move();
    }

    protected void Move()
    {
        if(isStop) return;

        if(isRight) 
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    protected void MoveRight()
    {
        if(transform.parent.position.x > rightPoint.position.x) 
        {
            ChangeDirection();
            return;
        }
        SetModelDirection();
        transform.parent.Translate(Vector3.right * speed * Time.deltaTime);
    }

    protected void MoveLeft()
    {
        if(transform.parent.position.x < leftPoint.position.x)
        {
            ChangeDirection();
            return;
        }
        SetModelDirection();
        transform.parent.Translate(Vector3.left * speed * Time.deltaTime);
    }

    protected void ChangeDirection()
    {
        isRight = isRight ? false : true;
    }

    public void SetModelDirection()
    {
        if(isRight)
        {
            monsterCtrl.Model.localScale = new Vector3(1f, 1f, 1f);
            float x = monsterCtrl.AttackPoint.localPosition.x;
            float y = monsterCtrl.AttackPoint.localPosition.y;
            monsterCtrl.AttackPoint.localPosition = new Vector3(x > 0 ? x : -x, y, 0);
        }
        else
        {
            monsterCtrl.Model.localScale = new Vector3(-1f, 1f, 1f);
            float x = monsterCtrl.AttackPoint.localPosition.x;
            float y = monsterCtrl.AttackPoint.localPosition.y;
            monsterCtrl.AttackPoint.localPosition = new Vector3(x < 0 ? x : -x, y, 0);
        }
    }

    public void SetStop(bool isStop)
    {
        this.isStop = isStop;
    }

    public void SetRight(bool isRight)
    {
        this.isRight = isRight;
    }
}