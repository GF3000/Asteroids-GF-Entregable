using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritoSpawnerManager : MonoBehaviour
{

    public GameObject meteoritoPrefab; //prefab del meteorito
    public float spawnRate = 1f; //tiempo entre generaciones del spawn
    public float rangeSpawnX = 10f;  //rango de spawn en el eje X
    public float rangeSpawnY = 5f;  //rango de spawn en el eje Y

    private float nextSpawn = 0f; //tiempo de la siguiente generacion del spawn
    public static float tiempoInicial = 0f; //tiempo inicial del juego

    public static bool gameOver = false; //variable que indica si el juego ha terminado



    // Start is called before the first frame update
    void Start()
    {
        tiempoInicial = Time.time; //obtenemos el tiempo inicial del juego
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) //si el juego no ha terminado
        {
            GenerarMeteoritos(); //generamos meteoritos
        }
        
        
    }

    void SpawnMeteorito(){
        float posX = Random.Range(-rangeSpawnX, rangeSpawnX); //generamos una posicion aleatoria en el eje X
        float posY = Random.Range(0, rangeSpawnY); //generamos una posicion aleatoria en el eje Y

        Vector3 spawnPos = new Vector3(posX, transform.position.y + posY, -1); //creamos un vector con la posicion aleatoria generada
        Instantiate(meteoritoPrefab, spawnPos, Quaternion.identity); //instanciamos el prefab del meteorito en la posicion aleatoria generada

    }

    private void GenerarMeteoritos(){
        float tiempoTranscurrido = Time.time - tiempoInicial; //obtenemos el tiempo transcurrido desde el inicio del juego
        
        nextSpawn += Time.deltaTime; //aumentamos el tiempo de la siguiente generacion del spawn
        float dificultad =  spawnRate / ((int)(tiempoTranscurrido / 15)+1);
        if (nextSpawn > dificultad) //si el tiempo de la siguiente generacion del spawn es mayor al tiempo de generacion del spawn
        {
            nextSpawn = 0f; //reiniciamos el tiempo de la siguiente generacion del spawn
            SpawnMeteorito(); //generamos un meteorito
        }
    }
}
