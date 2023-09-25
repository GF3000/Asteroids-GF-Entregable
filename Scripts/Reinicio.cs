using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reinicio : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReiniciarJuego(){
        Debug.Log("Reiniciando juego");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        MeteoritoSpawnerManager.gameOver = false;
        Player.score = 0;
        MeteoritoSpawnerManager.tiempoInicial = Time.time;
        
    }

}
