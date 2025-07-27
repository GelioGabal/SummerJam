using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    void Update()
    {
        transform.position = new(followTarget.position.x,transform.position.y,transform.position.z);
    }
}
