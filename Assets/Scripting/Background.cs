using System.Collections;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Engine engine;
    [SerializeField] ParticleSystem bubbles;
    [SerializeField] GameObject FishPrefab;
    [SerializeField] Sprite[] fishes;
    [SerializeField] float boundWidth, boundHeight;
    Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().materials[0];
        StartCoroutine(fisher());
    }

    void FixedUpdate()
    {
        mat.mainTextureOffset += engine.Direction * engine.Speed * Time.fixedDeltaTime;
        var vel = bubbles.velocityOverLifetime;
        vel.x = engine.Direction.x * engine.Speed *10;
    }

    IEnumerator fisher()
    {
        while (true)
        {
            float speed = Random.Range(0.8f,1f) * (Random.Range(0, 2) == 1 ? -1 : 1);
            Vector3 pos = new(transform.position.x + boundWidth * (speed > 0 ? -1 : 1), Random.Range(-boundHeight, boundHeight), 9);
            GameObject fish = Instantiate(FishPrefab, pos, Quaternion.identity);
            fish.transform.SetParent(transform);
            fish.GetComponent<Fish>().Swim(speed, fishes[Random.Range(0, fishes.Length)], engine);
            yield return new WaitForSeconds(Random.Range(2, 4));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new(transform.position.x - boundWidth, boundHeight), new(transform.position.x - boundWidth, -boundHeight));
        Gizmos.DrawLine(new(transform.position.x + boundWidth, boundHeight), new(transform.position.x + boundWidth, -boundHeight));
    }
}
