using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rg2d;
    private void Awake()
    {
        rg2d = GetComponent<Rigidbody2D>();
        float a = Random.Range(4.7f, 9.7f);
        rg2d.AddForce(transform.right * 50);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
