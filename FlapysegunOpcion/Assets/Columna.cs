using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columna : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.GetComponent<flappyvuelo>() != null)
        {
            //If the bird hits the trigger collider in between the columns then
            //tell the game control that the bird scored.
            GameControl.instance.BirdScored();
			Debug.Log ("he pasado una columna");
        }
    }
}
