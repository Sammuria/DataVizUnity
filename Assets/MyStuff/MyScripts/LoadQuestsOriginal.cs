using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadQuestsOriginal : MonoBehaviour {

    List<Quest> quests = new List<Quest>();
    public string[] row;

    // Use this for initialization
    void Start () 
	{
		TextAsset mydata = Resources.Load<TextAsset>("mydata");

		string[] data = mydata.text.Split(new char[]{ '\n' });
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
                Debug.Log("r0"+row[1]+ "r1" + row[2] + "r2" + row[3] );
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
            Debug.Log("col 1 is" + row[1]);

        }


        foreach (Quest q in quests)
        {
            //Debug.Log(q.Midnight+" people in "+q.Sensor + " at midnight ");
        }


        /*for (int i=1;i<12;i++)
        {
            Debug.Log("col"+i+"is"+row[i]);
        }*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
