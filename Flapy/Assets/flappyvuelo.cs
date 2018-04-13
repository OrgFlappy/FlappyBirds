using System.Collections;
using UnityEngine;


public class flappyvuelo : MonoBehaviour {

    public Rigidbody2D rigi;
    public Vector3 velocidad =Vector3.zero;
    public float velocidadMaxima;
    public  float angulo = 0;
    void Start() {
        rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) {
        rigi.AddForce(new Vector2(0, 600));
        transform.position +=velocidad * Time.deltaTime;
       
        angulo = Mathf.Lerp(0, 25, 600/velocidadMaxima);
        }
        else {
            angulo = Mathf.Lerp(0, -75, -600/ velocidadMaxima);
        }


        
        
           
       
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }
    /*
    void OnCollisionEnter2D(Collision2D colision) {

        Debug.Log("Colisión");
        
        if (colision.gameObject.name == "Columna1" || colision.gameObject.name == "Columna2" || colision.gameObject.name == "Suelo") {
            columna1.velocidad = new Vector3(0, 0, 0);
            columna2.velocidad = new Vector3(0, 0, 0);
            ani.SetTrigger("Fin");
            finJuego = true;

        }
        if (colision.gameObject.name == "Columna2") {
            colision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (colision.gameObject.name == "Suelo") {
            gravedad = new Vector3(0, 0, 0);
        }
    }

    */


}
