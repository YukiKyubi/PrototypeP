using UnityEngine;

public class InputManager : LiMono
{
    private static InputManager instance;

    public static InputManager Instance => instance;

    public Vector3 mousePos;

    [SerializeField] protected float onMoving;

    public float OnMoving => onMoving;

    [SerializeField] protected float onAttacking;

    public float OnAttacking => onAttacking;

    protected bool jump;

    public bool Jump => jump;

    protected override void Awake()
    {
        base.Awake();
        if(instance != null) Debug.LogError("Only 1 InputManager is allowed to exist");

        instance = this;
    }

    private void Update()
    {
        GetMousePos();
        GetHorizontalInput();
        GetJumpInput();
        GetAttackInput();
    }

    protected void GetHorizontalInput()
    {
        onMoving = Input.GetAxis("Horizontal");
    }

    protected void GetJumpInput()
    {
        this.jump = Input.GetKeyDown(KeyCode.W);
    }
    
    protected void GetAttackInput()
    {
        onAttacking = Input.GetAxis("Fire1");
    }

    protected void GetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}