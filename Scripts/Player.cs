using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;

    public Camera mainCamera = Camera.main;
    public float fuerzaAlejamiento = 10.0f;

    public static int score = 0;

    public GameObject cartelGameOver;
    public GameObject botonReinicio; //boton de reinicio
    public float avanceFijo = 1.1f;
    private bool primerMovimiento = true;


    private Rigidbody2D _rb; //Al ser oculto se ponen _ delante por convencion, no es necesario
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); //Se obtiene el componente Rigidbody2D del objeto
        botonReinicio.SetActive(false); //desactivamos el boton de reinicio
        primerMovimiento = true;
        cartelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float thrust = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //Tras el primer movimiento aplicamos una velocidad constante para que el jugador no se quede parado
        if (primerMovimiento && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space)))
        {
            primerMovimiento = false;
        }
        
        if (!primerMovimiento) transform.Translate(Vector3.right * avanceFijo * Time.deltaTime);

        
        float rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        
        Vector3 posicionRelativa = mainCamera.WorldToViewportPoint(transform.position);
        Vector2 direccionFuerza = new Vector2(0.5f - posicionRelativa.x, 0.5f - posicionRelativa.y).normalized;
        _rb.AddForce(direccionFuerza * fuerzaAlejamiento);
        
        if (!MeteoritoSpawnerManager.gameOver){
            _rb.AddForce(transform.right * thrust);
            transform.Rotate(Vector3.forward, -rotation);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            cartelGameOver.SetActive(true);
            botonReinicio.SetActive(true); //activamos el boton de reinicio
            MeteoritoSpawnerManager.gameOver = true;
            }
    }
}
