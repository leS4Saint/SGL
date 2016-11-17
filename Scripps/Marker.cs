using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {
	void Update ()
    {
        //THIS MARKER KEEPS THE SPACE GONDOLAS DORMANT UNTIL THEY ARE PICKED UP it is important

        GetComponent<GondolaAI>().currentState = GetComponent<GondolaAI>().gondoIdle;
        GetComponent<Animator>().SetBool(GetComponent<GondolaAI>().walkHash, false);
        GetComponent<GondolaAI>().idleTime = 0;
        GetComponent<GondolaAI>().lonely = 0;
        GetComponent<GondolaAI>().boredom = 0;
    }
}
