using System.Collections;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Vector2 startpos;
    public void Swim(float speed, Sprite sprite, Engine engine)
    {
        startpos = transform.position;
        var spriter = GetComponent<SpriteRenderer>();
        spriter.sprite = sprite;
        spriter.flipX = speed > 0;
        StartCoroutine(mover(engine, speed));
        Invoke("destroy", 20);
    }
    IEnumerator mover(Engine engine, float speed)
    {
        while(Vector2.Distance(startpos,(Vector2)transform.position)<60)
        {
            transform.Translate(new Vector3(speed + engine.Direction.x * engine.Speed,
                engine.Direction.y * engine.Speed, 0) * Time.fixedDeltaTime*16);
            yield return new WaitForFixedUpdate();
        }
        destroy();
    }
    void destroy() => Destroy(gameObject);
}
