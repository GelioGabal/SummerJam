using UnityEngine;

public class Engine : BreakAble
{
    [SerializeField] float speed;
    public float Speed => speed;
    [SerializeField] Vector2 direction;
    public Vector2 Direction => direction;
    float baseSpeed;
    protected override void Start()
    {
        baseSpeed = Speed;
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
}
