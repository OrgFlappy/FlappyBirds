using System.Collections;
using UnityEngine;


public class flappyvuelo : MonoBehaviour
{
    //Declaramos la velocidad inicial del pajaro sea igual a zero, Vector3.zero = 0,0,0
    //1,1,0
    Vector3 velocidad = Vector3.zero;
    //Declaramos un vector que controle la gravedad, no usaremos la fisica de unity
    public Vector3 gravedad;
    //Declaramos un vector que define el salto (aleteo) del pajaro
    public Vector3 velocidadAleteo;
    //Declaramos si se debe aletear, si se toco la pantalla o se presiono espacio
    bool aleteo = false;
    //Declaramos la velocidad maxima de rotacion del pajaro
    public float velocidadMaxima;
    public moverColumnasScript columna1;
    public moverColumnasScript columna2;
    public Animator ani;
    public bool Fin = false;
    public bool inicio;
    public bool muerto = false;
    public AudioClip Sonidoinicio;
    public AudioClip Sonidosalto;

    // Use this for initialization
    void Start()
    {
        ani = this.gameObject.GetComponent<Animator>();
        ReproducirSonido(Sonidoinicio);
    }

    // Update is called once per frame
    void Update()
    {
        //Si la persona presiona el boton de espacio o hace clic en la pantalla con el mouse
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ReproducirSonido(Sonidosalto);
            aleteo = true;
            
            inicio = true;
            columna1.inicio = true;
            columna2.inicio = true;



        }
    }

    //Este es el update de la fisica, que es ligeramente mas lento que el update del juego
    void FixedUpdate()
    {
        if (inicio == true)
        {
            //A la velocidad le sumamos la gravedad (Para que el pajaro caiga)
            velocidad += gravedad * Time.deltaTime;

            //Si presionaron espacio o hicieron clic
            if (aleteo == true)
            {
                //Que solo sea una vez
                aleteo = false;
                //El vector velocidad recibe el impulso hacia arriba al pajaro
                velocidad.y = velocidadAleteo.y;
            }
            //Hacemos que el pajaro reciba la velocidad (la gravedad lo hace caer mas rapido)
            transform.position += velocidad * Time.deltaTime;
            float angulo = 0;
            if (velocidad.y >= 0)
            {
                //Cambiamos el angulo si Y es positivo que mire arriba
                angulo = Mathf.Lerp(0, 25, velocidad.y / velocidadMaxima);
            }
            else
            {
                //Cambiamos el angulo si Y es negativo que mire abajo
                angulo = Mathf.Lerp(0, -75, -velocidad.y / velocidadMaxima);
            }
            //Rotamos
            transform.rotation = Quaternion.Euler(0, 0, angulo);
        }
    }

    void OnCollisionEnter2D(Collision2D colision)
    //void OnTriggerEnter2D(Collider2D colision)
    {
        //Si colisionamos con el tubo que se detengan los tubos
        if (colision.gameObject.name == "ColumnasAB" | colision.gameObject.name == "ColumnasA" | colision.gameObject.name == "Suelo")
        {
            //Hacemos que la velocidad de los tubos se haga cero
            columna1.velocidad = new Vector3(0, 0, 0);
            columna2.velocidad = new Vector3(0, 0, 0);
            //Dejamos de ejecutar el aleteo(impulso) al hacer clic
            Fin = true;
            ani.SetTrigger("Fin");
            muerto = true;

        }

        //Al momento de caer, queremos ignorar la colision con el tubo de abajo
        if (colision.gameObject.name == "ColumnasAB")
        {
            colision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        //Si colisionamos con el Piso, que la gravedad no siga aumentando
        if (colision.gameObject.name == "Suelo")
        {
            gravedad = new Vector3(0, 0, 0);
        }
    }

    void OnGUI(){
        if (muerto == true)
        {
            const int anchoBoton = 84;
            const int altoBoton = 60;

            // Dibujamos un boton  de Reinicio
            if (GUI.Button(new Rect(Screen.width / 2 - (anchoBoton / 2), (1.5f * Screen.height / 3) -(altoBoton / 2), anchoBoton, altoBoton), "Reiniciar!"))
            {
                Application.LoadLevel("escena1");
            }
            if (
                GUI.Button(
                new Rect(
                Screen.width / 2 - (anchoBoton / 2),
                (2 * Screen.height / 3) - (altoBoton / 2),
                anchoBoton,
                altoBoton
                ),
                "Puntajes!"
                )
                )
            {
            }
            if (
                GUI.Button(
                new Rect(
                Screen.width / 2 - (anchoBoton / 2),
                (2.5f * Screen.height / 3) - (altoBoton / 2),
                anchoBoton,
                altoBoton
                ),
                "Compartir!"
                )
                )
            {
            }
        }
    }

    //Reproduce un efecto de sonido
    private void ReproducirSonido(AudioClip clipOriginal)
    {
        // Como no es un sonido 3D la posicion no importa
        AudioSource.PlayClipAtPoint(clipOriginal, transform.position);
    }
    /*
        void OnCollisionEnter2D(Collision2D colision) {


            if (colision.gameObject.name == "Columna1" || colision.gameObject.name == "Columna2" || colision.gameObject.name == "Suelo") {
                columna1.velocidad = new Vector3(0, 0, 0);
                columna2.velocidad = new Vector3(0, 0, 0);
                Fin = true;
                ani.SetTrigger("Fin");
                Debug.Log("Colisión");
            }
            if (colision.gameObject.name == "Columna2") {
                colision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (colision.gameObject.name == "Suelo") {
                gravedad = new Vector3(0, 0, 0);
                Debug.Log("Suelo");
            }
        }

        */
}