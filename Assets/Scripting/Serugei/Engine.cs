using UnityEngine;

public class Engine : BreakAble
{
    [SerializeField] float speed;
    public float Speed => speed;
    [SerializeField] Vector2 direction;
    public Vector2 Direction => direction;
    float baseSpeed;
    private void Start()
    {
        baseSpeed = Speed;
    }

    protected override void Break()
    {
        speed = 0;
    }

    protected override void Fix()
    {
        speed = baseSpeed;
    }
}
