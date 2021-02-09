using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadQuests : MonoBehaviour {

    List<Quest> quests = new List<Quest>();
    public string[] row;
    public int[] testrow;
    public int[] finalrow = new int[50];
    public int var = 3;
    public int length;
    public ParticleSystem particleController;




    // Use this for initialization
    void Start () 
	{
		TextAsset mydata = Resources.Load<TextAsset>("mydata");

		string[] data = mydata.text.Split(new char[]{ '\n' });
        int[] testrow = new int[25];

        Debug.Log (data.Length);

        for(int i=1; i< data.Length-1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            //Debug.Log(row.Length);

            //Debug.Log("row");
            //Debug.Log("r0" + row[0]);

            if (row[1] != "")
            {
                //Debug.Log("row");
                //Debug.Log(row.Length);
                Quest q = new Quest();
                q.Sensor = row[0];

                if(i==1)
                {
                    for (int k = 0; k < row.Length - 1; k++)
                    {
                        int.TryParse(row[k+1], out testrow[k]);
                        //--works Debug.Log("Testrow first try " + testrow[k]);
                    }


                }
               

                /*for (int k = 0; k < row.Length - 1; k++)
                {
                    Debug.Log("Testrow first try " + testrow[k]);
                }*/
                //Debug.Log("r0"+row[1]+ "r1" + row[2] + "r2" + row[3] );
                int.TryParse(row[1], out q.Midnight);
                int.TryParse(row[1], out q.a1am);
                int.TryParse(row[2], out q.a2am);
                int.TryParse(row[3], out q.a3am);
                int.TryParse(row[4], out q.a4am);
                int.TryParse(row[5], out q.a5am);
                int.TryParse(row[6], out q.a6am);
                int.TryParse(row[7], out q.a7am);
                int.TryParse(row[8], out q.a8am);
                int.TryParse(row[9], out q.a9am);
                int.TryParse(row[10], out q.a10am);
                int.TryParse(row[11], out q.a11am);
                int.TryParse(row[12], out q.Noon);
                int.TryParse(row[1], out q.a1pm);
                int.TryParse(row[2], out q.a2pm);
                int.TryParse(row[3], out q.a3pm);
                int.TryParse(row[4], out q.a4pm);
                int.TryParse(row[5], out q.a5pm);
                int.TryParse(row[6], out q.a6pm);
                int.TryParse(row[7], out q.a7pm);
                int.TryParse(row[8], out q.a8pm);
                int.TryParse(row[9], out q.a9pm);
                int.TryParse(row[10], out q.a10pm);
                int.TryParse(row[11], out q.a11pm);

                quests.Add(q);

            }
            //Debug.Log("col 1 is" + row[1]);

        }


        foreach (Quest q in quests)
        {
            //Debug.Log(q.Midnight+" people in "+q.Sensor + " at midnight ");
        }

        /*
        foreach (int i in testrow)
        {
            //--works Debug.Log("Final Testrow is "+i);
            //Debug.Log(i);
            finalrow[i] = testrow[i];
        }
        */
        for (int i=0; i<testrow.Length;i++)
        {
            finalrow[i] = testrow[i];
        }
        //finalrow[5] = testrow[5];
        length = testrow.Length;
        Debug.Log("Testrow 5 " + testrow[5]);
        Debug.Log("finalrow 5 " + finalrow[5]);

        Debug.Log("Testrow length " + testrow.Length);
        Debug.Log("Finalrow length " + finalrow.Length);

        Debug.Log("Test Row full" + testrow);

        func();
    }

    // Update is called once per frame
    void Update () 
	{
		
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
        

        //Debug.Log("loc1 Access indiv element from ienumerator " + loc1[5]);


        for (int i = 0; i < length; i++)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("at " + i + " o clock ");
            particleController.Emit(finalrow[i]);
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

    public void func()
    {
        Debug.Log("Inside Func Testrow length " + testrow.Length);
        Debug.Log("Fin Testrow length " + finalrow.Length);
        for (int i = 0; i < length; i++)
        {
            Debug.Log("normal for looped func Final Testrow is " + finalrow[i]);
        }

        foreach (int i in testrow)
        {

            Debug.Log("func Final Testrow is "+i);
            //Debug.Log(i);
        }
        // :( cant be done sweety! Debug.Log("Func Testrow 5 " + testrow[5]);

    }
}
