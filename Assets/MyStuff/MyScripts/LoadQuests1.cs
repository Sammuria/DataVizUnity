using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadQuests1 : MonoBehaviour {

    List<Quest> quests = new List<Quest>();
    public string[] row;
    public string[] data;
    public int[] testrow;
    public int[,] finalrow = new int[65,65];
    public int var = 3;
    public int length;
    public ParticleSystem[] particleController;
    int check = 0;




    // Use this for initialization
    void Start () 
	{
        
        //particleController = new ParticleSystem[i];

        
        TextAsset mydata1 = Resources.Load<TextAsset>("editedApril20");
        TextAsset mydata2 = Resources.Load<TextAsset>("editedMay17");
        TextAsset mydata = Resources.Load<TextAsset>("blm");
        

        string[] data = mydata.text.Split(new char[]{ '\n' });
        
        int[,] testrow = new int[65,65];

        Debug.Log (data.Length);
        //Debug.Log("r26 " + row[26]);

        for (int i=1; i< data.Length-1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
          
            
            if (row[1] != "")
            { 
                //Debug.Log("row");
                //Debug.Log(row.Length);
                Quest q = new Quest();
                q.Sensor = row[0];

                for (int k = 0; k < row.Length - 1; k++)
                {
                    int.TryParse(row[k + 1], out testrow[i - 1, k]);
                    //Debug.Log(" accesing "+i+" row "+k+"column. Testrow is " + testrow[i - 1, k]);
                }


                
            }


        }

        
        for (int i = 0; i < testrow.GetLength(1); i++)
        {
            

            for (int lol = 0; lol < data.Length-1; lol++)
            {
                finalrow[lol, i] = testrow[lol, i];
            }

            



        }

        length = testrow.GetLength(1);
       

        StartCoroutine(waiter());

        Debug.Log("The End!!");

    }

    // Update is called once per frame
    void Update () 
	{
        TextAsset mydata1 = Resources.Load<TextAsset>("editedApril20");
        TextAsset mydata2 = Resources.Load<TextAsset>("editedMay17");
        TextAsset mydata = Resources.Load<TextAsset>("Origmydata");


        if (check == 0)
        {
            //string[] data1;
            data = mydata.text.Split(new char[] { '\n' });

        }
        else if (check == 1)
        {
            data = mydata1.text.Split(new char[] { '\n' });

        }
        else if (check == 2)
        {
            data = mydata2.text.Split(new char[] { '\n' });

        }
    }



    


    IEnumerator waiter()
    {


        //Debug.Log("loc1 Access indiv element from ienumerator " + loc1[5]);
        
        for (int i = 0; i < length; i++)
        {

           
            for (int lol = 0; lol < 54; lol++)
            {
                Debug.Log("at " + i + " o clock in loc 7 " + finalrow[lol, i]);
                particleController[lol].Emit(finalrow[lol, i]);
            }
                yield return new WaitForSeconds(2);
            
        }



    }

    
}
