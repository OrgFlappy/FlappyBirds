using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;             
	public Text scoreText;                         
	public GameObject gameOvertext;             
    private int score = 0;                      
    public bool gameOver = false;               
    public float scrollSpeed = -1.5f;
    public AudioClip sonidoPunto;
    public string nombre;


    void Awake()
    {
		Debug.Log ("hola");
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if(instance != this)
            //...destroy this one because it is a duplicate.
            Destroy (gameObject);
    }

    /* void Update()
     {
         //If the game is over and the player has pressed some input...
         if (gameOver && (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))){
             //...reload the current scene.
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }
     }
     */

    public void Guardarnombre(string nombre2) {
        nombre = nombre2 + " ";
    }

    void OnGUI()
    {
        if (gameOver == true)
        {
            const int anchoBoton = 84;
            const int altoBoton = 60;

            // Dibujamos un boton  de Nivel 
            if (GUI.Button(new Rect(Screen.width / 2 - (anchoBoton / 2), (1.5f * Screen.height / 3) - (altoBoton / 2), anchoBoton, altoBoton), "1 NIvel"))
            {
                Application.LoadLevel("escena1");
                    Debug.Log("es1");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - (anchoBoton / 2), (2 * Screen.height / 3) - (altoBoton / 2), anchoBoton, altoBoton), "2 Nivel"))
            {
                Application.LoadLevel("escena2");
                Debug.Log("es2");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - (anchoBoton / 2), (2.5f * Screen.height / 3) - (altoBoton / 2), anchoBoton, altoBoton), "3 Nivel!"))
            {
                Application.LoadLevel("escena3");
                Debug.Log("es3");
            }
        }
    }

    public void BirdScored()
    {
        //The bird can't score if the game is over.
        if (gameOver)   
            return;
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        scoreText.text = "SCORE: " + score.ToString();
        ReproducirSonido(sonidoPunto);

    }

    public void BirdDied()
    {
        //Activate the game over text.
        gameOvertext.SetActive (true);
        scoreText.text = nombre + score.ToString();
        //Set the game to be over.
        gameOver = true;
    }

    //Reproduce un efecto de sonido
    private void ReproducirSonido(AudioClip clipOriginal)
    {
        // Como no es un sonido 3D la posicion no importa
        AudioSource.PlayClipAtPoint(clipOriginal, transform.position);
    }
}