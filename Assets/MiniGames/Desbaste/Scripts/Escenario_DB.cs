using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escenario_DB : MonoBehaviour
{

    private SpriteRenderer spriteRendererComponent;
    public float scrollSpeed;

    private void Awake()
    {
        spriteRendererComponent = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

    }
    void Update()
    {//mueve las cintas transportadoras
        float x = Mathf.Repeat(Time.time * scrollSpeed, 17f) - 40f;
        Vector2 offset = new Vector2(x, 2f);
        spriteRendererComponent.size = offset; // any vector2
        if (scrollSpeed == 0) {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
