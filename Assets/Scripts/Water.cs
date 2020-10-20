using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
	GameObject Pressure;
	PressureUpdater pressureSript;
    // Start is called before the first frame update
    void Start()
    {
        Pressure = GameObject.Find("Pressure");
        pressureSript = Pressure.GetComponent<PressureUpdater>();

    }

    // Update is called once per frame
    void Update()
    {
		
		if(pressureSript.pressure>150)
		{
				
			// Debug.Log("OW");
			if(transform.localScale.y>1.3)
			{
				transform.localScale -= new Vector3(0, (float)(Mathf.Max(pressureSript.currentPressurePlus*(Mathf.Pow(pressureSript.pressure,(float)3.5)/Mathf.Pow(600,(float)3.5)),(float).5))*(float).0005, 0);

					//Debug.Log(transform.localScale.y);						
			}
			// Trigger for once you passed the level
			else
			{
				Time.timeScale = 0;
			}

		}
    }
}
