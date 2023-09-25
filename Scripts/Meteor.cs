using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    public float maxInclinacion = 30f;
    public GameObject MeteorHijo;
    float scale;
    // Start is called before the first frame update
    void Start()

    {
        scale = Random.Range(0.20f, 0.4f);
        transform.localScale = new Vector3(scale, scale, 0);
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
            for (int i = 0; i < 2; i++)
        {
            // Calcula una inclinación aleatoria en grados
            float inclinacionAleatoria = Random.Range(-maxInclinacion, maxInclinacion);

            // Crea el meteorito hijo con una rotación aleatoria basada en la inclinación
            Quaternion rotacionAleatoria = Quaternion.Euler(0f, 0f, inclinacionAleatoria);
            GameObject meteoritoHijo = Instantiate(MeteorHijo, transform.position, rotacionAleatoria);
            meteoritoHijo.transform.localScale = new Vector3(scale / 2, scale / 2, 0);
            //MeteoritoHijo tiene la misma velocidad que el padre
            meteoritoHijo.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        }
            Destroy(gameObject);
        }
    }
}
    

