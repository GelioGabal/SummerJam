using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] float speed;
    public float Speed => speed;
    [SerializeField] Vector2 direction;
    public Vector2 Direction => direction;
}
