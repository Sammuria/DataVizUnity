using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    // Use this for initialization
    public ParticleSystem particleController;
    public ParticleSystem particleSplatter;
    int[] loc1 = new int[50];
    int length1;
    LoadQuests lq;

    void Start ()
    {
        //LoadQuests lq = GetComponent<LoadQuests>();

        //GameObject point = GameObject.FindWithTag("Player");
        LoadQuests lq = GetComponent<LoadQuests>();
        //lq = GameObject.Find("Point")

        if (lq != null)
        {
            Debug.Log("Start Function");
            lq.var = 5;
            Debug.Log("Var" + lq.var);
            Debug.Log("pc length" + lq.length);
            length1 = lq.length;
            for (int i = 0; i < lq.length; i++)
            {
                Debug.Log("In Particle Controller Final Testrow is " + lq.finalrow[i]);
            }
            for (int i = 0; i < lq.length; i++)
            {
                loc1[i] = lq.finalrow[i];
            }


        }
        if (lq == null)
        {
            Debug.Log("Cannot find 'point' script");
        }
    

    //int[] array1;
    //array1 = lq.testrow;
    

	}


    void OnParticleCollision(GameObject other)
    {
        emitAtLocation();
    }

    void emitAtLocation()
    {
        particleSplatter.Emit(3);
    }


    
    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        Debug.Log("Clicked");
        //particleController.startSpeed = 0.2f;

        particleController.Emit(28);
        StartCoroutine(waiter());

    }
    // Update is called once per frame


    IEnumerator waiter()
    {
        if (lq == null)
        {
            Debug.Log("Cannot find 'point' script");
        }

        else
        {
            Debug.Log("Access indiv element from ienumerator " + lq.finalrow[5]);

        }

        Debug.Log("loc1 Access indiv element from ienumerator " + loc1[5]);


        for(int i = 0;i<length1; i++)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("at "+ i +" o clock ");
            particleController.Emit(loc1[i]);
        }
        /*
        yield return new WaitForSeconds(2);
        Debug.Log("after 2 sec");
        particleController.Emit(16);

        yield return new WaitForSeconds(2);
        Debug.Log("after 2 sec2");
        particleController.Emit(16);

        yield return new WaitForSeconds(2);
        Debug.Log("after 2 sec3");
        particleController.Emit(16);
        */

    }
    void Update ()
    {
       

        
    }
}
