using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent OnEnter = new();
    public UnityEvent OnExit = new();
    private void OnTriggerEnter2D(Collider2D collision)
    { if(collision.CompareTag("Player")) OnEnter.Invoke(); }
    private void OnTriggerExit2D(Collider2D collision)
    { if(collision.CompareTag("Player")) OnExit.Invoke(); }
}
