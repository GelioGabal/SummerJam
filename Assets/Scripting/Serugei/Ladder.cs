using UnityEngine;

public class Ladder : InteractiveObject
{
    [SerializeField] float posY;
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        base.OnInteract.AddListener(Teleport);
    }
    void Teleport()
    { 
        Vector3 pos = player.position;
        pos.y = posY;
        player.transform.position = pos;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(new(transform.position.x, posY), Vector3.one/5f);
    }
}
