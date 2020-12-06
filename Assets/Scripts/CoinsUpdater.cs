using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsUpdater : MonoBehaviour
{
	private TextMeshProUGUI coinText;
	private TextMeshProUGUI[] allThings;
    void Start()
    {
		

		allThings = FindObjectsOfType<TextMeshProUGUI>();
		foreach (TextMeshProUGUI value in allThings)
        {
            if(value.name=="Coins")
			{
				coinText = value;
				coinText.SetText((PlayerScript.coins).ToString());
				//Debug.Log("Found you!");
				break;
			}
			
        }
    }

    // Update is called once per frame
    void Update()
    {
		//Player.coins+=1;
		coinText.SetText((PlayerScript.coins).ToString());
		
		
		
		
		
		/*
		
		if (Input.GetKey(KeyCode.E)){
			pressure+=1;
			
		}
		if(pressure>0)
		{	
			pressure-=Mathf.Max(1*(Mathf.Pow(pressure,(float)3.5)/Mathf.Pow(600,(float)3.5)),(float).5);
		}
		pressureText.SetText("Pressure: "+(int)(pressure/30));
		
		*/
		//scale.gameObject.transform.localScale = new Vector3((float)2.578344, (float)2.578344+pressure/45, (float)2.578344);
		//Debug.Log(scale.gameObject.transform.localScale.x);
        
    }
	

}
