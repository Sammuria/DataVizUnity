using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    // Use this for initialization
    int check = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log("Mouse press");
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1.0f;
            Debug.Log("check ==0");

        }

        else
        {
            Time.timeScale = 0.0f;
            Debug.Log("check !=0");
            check = 1;

        }

    }



    private void OnMouseEnter()
    {
        
    }
}
