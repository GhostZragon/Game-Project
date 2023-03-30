using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Transform coin;
    SpriteRenderer sprite;
    Color color;
    public float speed = 3f;

    void Start()
    {
        coin = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Fly();
    }
    void Fly()
    {
        coin.transform.position += new Vector3(0, speed*Time.deltaTime, 0);
        color.a -= 1f*Time.deltaTime;
        sprite.color = color;
    }
}
