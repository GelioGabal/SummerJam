using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Engine engine;
    [SerializeField] ParticleSystem bubbles;
    Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().materials[0];
    }

    void Update()
    {
        mat.mainTextureOffset += engine.Direction * engine.Speed * 0.001f;
        var vel = bubbles.velocityOverLifetime;
        vel.x = engine.Direction.x * engine.Speed *10;
    }
}
