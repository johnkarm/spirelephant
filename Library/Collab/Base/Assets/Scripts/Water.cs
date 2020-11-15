using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; 

public class Water : MonoBehaviour
{
	private TextMeshProUGUI aveBreath;
	private TextMeshProUGUI idealBreath;
	private TextMeshProUGUI coins;
	private TextMeshProUGUI newFact;
	private TextMeshProUGUI[] allThings;
	
	GameObject Pressure;
	GameObject winScreen;
	GameObject mapButton;
	GameObject textCanvas;
	PressureUpdater pressureSript;

	
	bool LevelWon=false;
    // Start is called before the first frame update
    void Start()
    {
		
							
		allThings = FindObjectsOfType<TextMeshProUGUI>();
		foreach (TextMeshProUGUI value in allThings)
        {
            if(value.name=="idealBreath")
			{
				idealBreath = value;
			}
            if(value.name=="aveBreath")
			{
				aveBreath = value;
			}
            if(value.name=="coins")
			{
				coins = value;
			}
            if(value.name=="newFact")
			{
				newFact = value;
			}
				
        }
		
		
		winScreen = GameObject.Find("WinScreen");  
		winScreen.SetActiveRecursively(false);  
		mapButton = GameObject.Find("goToMap");  
		mapButton.SetActiveRecursively(false);  
        textCanvas = GameObject.Find("textCanvas"); 
		textCanvas.SetActiveRecursively(false);

		
        Pressure = GameObject.Find("Pressure"); 
        pressureSript = Pressure.GetComponent<PressureUpdater>();
    }

    // Update is called once per frame
    void Update()
    {
		if(pressureSript != null && pressureSript.pressure>1500)
		{
				
			// Debug.Log("OW");
			if(transform.localScale.y>1.3)
			{
				transform.localScale -= new Vector3(0, (float)(Mathf.Max(pressureSript.currentPressurePlus*(Mathf.Pow(pressureSript.pressure,(float)3.5)/Mathf.Pow(6000,(float)3.5)),(float).5))*(float).0003, 0);

					//Debug.Log(transform.localScale.y);						
			}
			// Trigger for once you passed the level
			else
			{
				if(!LevelWon)
				{			
					LevelWon=true;
					Time.timeScale = 0;
										
					winScreen.SetActiveRecursively(true);
					mapButton.SetActiveRecursively(true);
					textCanvas.SetActiveRecursively(true);
					
					double sum=0;
					pressureSript.breaths.ForEach(num => sum+=1.0*num);
					
					aveBreath.SetText((sum/pressureSript.breaths.Count).ToString("N2"));
					idealBreath.SetText("1");
					coins.SetText((100*(1-Math.Abs(1-sum/pressureSript.breaths.Count))).ToString("N0"));
					newFact.SetText("1");
					


				}
				
			}

		}
    }
}
