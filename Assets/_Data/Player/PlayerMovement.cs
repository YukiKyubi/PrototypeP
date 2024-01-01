using UnityEngine;

public class PlayerMovement : PlayerAbstract
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected bool isRight = true;
    [SerializeField] protected float xValue = 0f;
    [SerializeField] protected float jumpForce = 5f;
    [SerializeField] protected float jumpDelay = 2f;
    [SerializeField] protected float jumpTimer;
    [SerializeField] protected bool canJump = false;

    protected void Update()
    {
        Move();
        Jump();

    }

    protected void Move() 
    {
        xValue = InputManager.Instance.OnMoving;

        SetModelDirection();
        transform.parent.Translate(Vector3.right * xValue * speed * Time.deltaTime);
    }

    protected void Jump()
    {
        canJump = CanJump();

        if(!InputManager.Instance.Jump) return;
        if(!canJump) return;

        jumpTimer = 0;
        Vector3 jumpVelocity = new Vector3(0f, jumpForce, 0f);
        playerCtrl.Rigidbody.velocity = jumpVelocity;
    }

    protected bool CanJump()
    {
        if(jumpTimer < jumpDelay) jumpTimer += Time.deltaTime;
        if(jumpTimer > jumpDelay) return true;
        return false;
    }

    protected void SetModelDirection() {
        if(xValue < 0)
        {
            TurnLeft();

            isRight = false;
        }
        else if(xValue > 0)
        {
            TurnRight();
            
            isRight = true;
        }
        else
        {
            if(isRight) TurnRight();
            else TurnLeft();
        }
    }

    protected void TurnRight()
    {
        playerCtrl.Model.localScale = new Vector3(1f, 1f, 1f);

        if(!IsMeleeAttack()) return;

        float x = playerCtrl.AttackPoint.localPosition.x;
        float y = playerCtrl.AttackPoint.localPosition.y;
        playerCtrl.AttackPoint.localPosition = new Vector3(x > 0 ? x : -x, y, 0);
    }

    protected void TurnLeft()
    {
        playerCtrl.Model.localScale = new Vector3(-1f, 1f, 1f);

        if(!IsMeleeAttack()) return;

        float x = playerCtrl.AttackPoint.localPosition.x;
        float y = playerCtrl.AttackPoint.localPosition.y;
        playerCtrl.AttackPoint.localPosition = new Vector3(x < 0 ? x : -x, y, 0);
    }

    protected bool IsMeleeAttack()
    {
        return playerCtrl.PlayerMeleeAttack.WeaponType == WeaponType.MeleeType;
    }
}