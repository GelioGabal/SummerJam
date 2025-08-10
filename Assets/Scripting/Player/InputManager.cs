using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputSystem_Actions playerInput;
    static Camera cam;
    
    private void Awake()
    {
        cam = Camera.main;
        playerInput = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    
    private void OnDisable()
    {
        playerInput.Disable();
    }
    public static Vector3 ScreenToWorld(Vector3 screen) =>
        setZ(cam.ScreenToWorldPoint(screen), 10);
    public static Vector3 WorldToScreen(Vector3 world) =>
        setZ(cam.WorldToScreenPoint(world), 10);
    static Vector3 setZ(Vector3 vector, float z)
    {
        vector.z = z;
        return vector;
    }
}
