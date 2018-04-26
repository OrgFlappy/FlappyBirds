using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonJugar : MonoBehaviour {
	public InputField nombreT;
	public string nombre;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown() {
        Application.LoadLevel("escena1");
		nombre = nombreT.text;
		Debug.Log (nombre);
    }
}
