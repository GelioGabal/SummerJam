using UnityEngine;

public class Engine : BreakAble
{
    [SerializeField] float speed;
    public float Speed => speed;
    [SerializeField] Vector2 direction;
    public Vector2 Direction => direction;
    float baseSpeed;
    Vector2 baseDirection;
    protected override void Start()
    {
        baseSpeed = Speed;
        baseDirection = direction;
        base.Start();
    }

    protected override void Break()
    {
        speed = 0;
        base.Break();
    }

    protected override void Fix()
    {
        speed = baseSpeed;
        base.Fix();
    }
    public void Down(float p)
    {
        direction = Vector2.Lerp(IsBreaked ? new(0, baseDirection.y) : baseDirection, Vector2.up, p);
        speed = Mathf.Lerp(baseSpeed, baseSpeed * 3, p);
    }
}
