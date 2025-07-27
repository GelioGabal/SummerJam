using System.Collections;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] Engine _engine;
    [SerializeField] float _speed;
    Vector2 startpos;
    public void Swim(float speed, Sprite sprite, Engine engine)
    {
        startpos = transform.position;
        _engine = engine;
        _speed = speed;
        var spriter = GetComponent<SpriteRenderer>();
        spriter.sprite = sprite;
        spriter.flipX = _speed > 0;
        StartCoroutine(mover());
        Invoke("destroy", 20);
    }
    IEnumerator mover()
    {
        while(Vector2.Distance(startpos,(Vector2)transform.position)<60)
        {
            transform.Translate(new Vector3(_speed + _engine.Direction.x * _engine.Speed,
                _engine.Direction.y * _engine.Speed, 0) * 0.1f);
            yield return new WaitForFixedUpdate();
        }
        destroy();
    }
    void destroy() => Destroy(gameObject);
}
