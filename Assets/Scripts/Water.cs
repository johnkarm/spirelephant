using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; 
using UnityEngine.SceneManagement;

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
	Animator anim;
	GameObject player; 
	GameObject apple; 
	public bool LevelWon=false;
	
    // Start is called before the first frame update
    void Start()
    {

		player = GameObject.Find("Player");    
		apple = GameObject.Find("apple");    
		
		anim = player.GetComponent<Animator>();		
							
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
		

		
        Pressure = GameObject.Find("Pressure"); 
        pressureSript = Pressure.GetComponent<PressureUpdater>();
		
		winScreen = GameObject.Find("WinScreen");  
		winScreen.SetActiveRecursively(false);  
		mapButton = GameObject.Find("goToMap");  
		mapButton.SetActiveRecursively(false);  
        textCanvas = GameObject.Find("textCanvas"); 
		textCanvas.SetActiveRecursively(false);
    }

    // Update is called once per frame
    void Update()
    {
	
	
			

		if(pressureSript != null && pressureSript.pressure>150)
		{
			if (pressureSript.failedBreath) 
			{
				Debug.Log("Failure :(");

			}
			else if(name=="Water")
			{
				if(transform.position.y>-7.4 && !pressureSript.failedBreath)
				{
					transform.position -= new Vector3(0, (float)(Mathf.Max(pressureSript.currentPressurePlus*(Mathf.Pow(pressureSript.pressure,(float)3.5)/Mathf.Pow(500,(float)3.5)),(float).5))*(float).005, 0);
					//Debug.Log(transform.localScale.y);			
				}
				else // Trigger for once you passed the level
				{
					if(!LevelWon)
					{			
						winLevel(1);
					}	
				}
			}
			else if (name=="waterParent")
			{
				
				if(transform.localScale.y<1 && !pressureSript.failedBreath)
				{
					transform.localScale += new Vector3(0, (float)(Mathf.Max(pressureSript.currentPressurePlus*(Mathf.Pow(pressureSript.pressure,(float)3.5)/Mathf.Pow(500,(float)3.5)),(float).5))*(float).002, 0);
					//Debug.Log(transform.localScale.y);			
				}
				else // Trigger for once you passed the level
				{
					if(!LevelWon)
					{			
						winLevel(2);
					}	
				}
				
			}
			else if (name=="ropeParent")
			{
				
				if(transform.localScale.y<1.5 && !pressureSript.failedBreath)
				{
					float val = (float)(Mathf.Max(pressureSript.currentPressurePlus*(Mathf.Pow(pressureSript.pressure,(float)3.5)/Mathf.Pow(500,(float)3.5)),(float).5));
					
					transform.localScale += new Vector3(0, val*(float).003, 0);
					
					
					
					apple.transform.position += new Vector3(0, val*(float)Math.Sin(Math.PI*7f/6f)*(float).01125, 0);//
					
					
					apple.transform.position += new Vector3(val*(float)Math.Cos(Math.PI*7f/6f)*(float).01125, 0, 0);//*
					
					
				}
				else // Trigger for once you passed the level
				{
					if(!LevelWon)
					{			
						winLevel(3);
					}	
				}
				
			}
			// Debug.Log("OW");

		}
		else
		{
			if(apple)
			{
				apple.gameObject.transform.localRotation = new Quaternion(apple.gameObject.transform.localRotation.x, 
																			apple.gameObject.transform.localRotation.y, 
																			-(float)pressureSript.pressure*.45f/150f,
																			apple.gameObject.transform.localRotation.w);
				
			}
									//pressureSript.currentPressurePlus*(Mathf.Pow(,(float)3.5)/Mathf.Pow(6000,(float)3.5))
		}
    }
	
	void winLevel(int level)
	{
		LevelWon=true;
		
		if(level==1)
		{
			PlayerScript.levelTwo=true;
			StartCoroutine(delayEnd());
			newFact.SetText("Baby rabbits are called ‘kittens’!");
		}
		if(level==2)
		{
			PlayerScript.levelThree=true;
			
			anim.SetBool("eIsPressed",false);
			anim.SetBool("lavaEIsPressed",true);
			StartCoroutine(delayEnd(anim.GetCurrentAnimatorStateInfo(0).length*3));
			player.transform.localScale = new Vector3(-1*player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
			player.transform.position = new Vector3(3.42f, player.transform.position.y, player.transform.position.z);
			newFact.SetText("Above ground, it's called lava. Below ground, it's called magma!");
		}
		if(level==3)
		{
			StartCoroutine(delayEnd());
			newFact.SetText("Elizabeth's secret ingredient for her fruit bat pie is a pinch of cinnamon and a dash of love!");
			//PlayerScript.levelTwo=true;
		}

			

					
	}
	
	IEnumerator delayEnd(float _delay=0)
	{
		yield return new WaitForSeconds(_delay);
		
		Time.timeScale = 0;
		winScreen.SetActiveRecursively(true);
		mapButton.SetActiveRecursively(true);
		textCanvas.SetActiveRecursively(true);
		
		double sum=0;
		pressureSript.breaths.ForEach(num => sum+=1.0*num);
		int newCoins=Convert.ToInt32((100*(1-Math.Abs(1-sum/pressureSript.breaths.Count))).ToString("N0"));
		newCoins = Mathf.Max(newCoins, 0);
		PlayerScript.coins+=newCoins;
		aveBreath.SetText((sum/pressureSript.breaths.Count).ToString("N2"));
		idealBreath.SetText("1");
		coins.SetText(newCoins.ToString("N0"));
					
		
	}
	

}
