using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moverColumnasScript : MonoBehaviour {

    public Vector3 velocidad;
    public Vector3 distanciaColumnas;
   
   // public GUIText marcador;
   // private bool sumarPuntos = true;
    public bool inicio;
    
    private int puntos = 0;

    // Use this for initialization
    void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        if (inicio == true) {
            moverColumnas();
        }
            
        
          
    }

    private void moverColumnas() {
        this.transform.position = this.transform.position + (velocidad * Time.deltaTime);

        if (this.transform.position.x <= -13f) {
            Vector3 posicionTemporal = this.transform.position + distanciaColumnas;

            posicionTemporal.y = Random.Range (-3f,2f);

            this.transform.position = posicionTemporal;

            //sumarPuntos = true;
        }
        if (this.transform.position.x <= -11f ) {

         
     
           //int puntos = int.Parse(marcador.text) + 1;
          // marcador.text = puntos.ToString();
           //sumarPuntos = false;
           
            Debug.Log("puntos");

   
        }

    }
     
}
