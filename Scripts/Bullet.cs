using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour

{

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the bullet collides with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            //Destroy the bullet
            Destroy(gameObject);
            //Increase the score
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        Player.score+=1;
        Debug.Log("Score: " + Player.score);
        GameObject.Find("Score").GetComponent<Text>().text = "Score: " + Player.score;
    }
}