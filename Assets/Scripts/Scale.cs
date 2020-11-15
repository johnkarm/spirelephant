using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scale : MonoBehaviour
{
	TextMesh pressureObj = null;
	float pressure =0;
	int time=0;
    // Start is called before the first frame update
    void Start()
    {
		pressureObj = GameObject.Find("Pressure").GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {
		//pressureObj.text="Pressure: " + time.ToString();
		//GUI.Label(Rect(0,0,100,100),"Time: " +time.ToString())

		time=time+1;
		
        if (Input.GetMouseButtonDown(0)){
			pressure+=1;
		}
    }
}
