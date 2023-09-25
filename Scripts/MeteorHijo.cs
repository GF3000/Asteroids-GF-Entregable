using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHijo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()

    {
        Destroy(gameObject, 4f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
        
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
    

