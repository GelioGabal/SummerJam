using Newtonsoft.Json.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flicker : MonoBehaviour
{
    [SerializeField] Light2D _light;
    [SerializeField] float minWorkTime,maxWorkTime, minNotWorkTime, maxNotWorkTime, radius;
    [SerializeField] Vector2 center;
    void OnEnable()
    {
        StartCoroutine(flicker());
    }
    IEnumerator flicker()
    {
        while (true)
        {
            transform.position = new(Random.Range(center.x - radius, center.x + radius), Random.Range(center.y - radius, center.y + radius), transform.position.z);
            _light.enabled = true;
            yield return new WaitForSeconds(Random.Range(minWorkTime, maxWorkTime));
            _light.enabled = false;
            yield return new WaitForSeconds(Random.Range(minNotWorkTime, maxNotWorkTime));
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(center, radius);
    }
}
