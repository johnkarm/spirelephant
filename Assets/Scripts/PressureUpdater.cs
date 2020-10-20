using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PressureUpdater : MonoBehaviour
{
	public float pressure=0;
	public float rotateSpeed = 20.0f;
    public float angleMax = 90.0f;
	private Vector3 initialVector = Vector3.forward;
	private bool wiggle = true;
	private SpiroSim sim;
	private int arrayCounter=0;
	private int frameCounter=1;
	private int lastFlow=0;
	private int lastArrayCounter= 0;
	// private bool resetBreathNeeded = true;
	public int currentPressurePlus = 0;
	 
	private TextMeshProUGUI pressureText;
	private TextMeshProUGUI[] allThings;
	
	//public Animator anim;

	
    // Start is called before the first frame update
	GameObject scale;
	GameObject player;

    void Start()
    {
		scale = GameObject.Find("Scale");
		sim = gameObject.AddComponent<SpiroSim>() as SpiroSim;

		//player = GameObject.Find("Player");    
		
		//anim = player.GetComponent<Animator>();
		
		if(scale != null)
         {
             initialVector = transform.position - scale.transform.position;
             initialVector.y = 0;
         }
		
		allThings = FindObjectsOfType<TextMeshProUGUI>();
		foreach (TextMeshProUGUI value in allThings)
        {
            if(value.name=="Pressure")
			{
				pressureText = value;
				break;
			}
				
        }
    }

	void GetBreath() {
		
		if(Input.GetKey(KeyCode.Z)) {
			Debug.Log("StartBestBreath");
			sim.StartBestBreath();
			arrayCounter = 0;
			// resetBreathNeeded = false;

		} else if(Input.GetKeyDown(KeyCode.X)) {
			Debug.Log("StartBetterBreath");
			sim.StartBetterBreath();
			arrayCounter = 0;
			
			// resetBreathNeeded = false;

		} else if(Input.GetKeyDown(KeyCode.C)) {
			Debug.Log("StartGoodBreath");
			sim.StartGoodBreath();
			arrayCounter = 0;
			// resetBreathNeeded = false;

		} else if(Input.GetKeyDown(KeyCode.V)) {
			Debug.Log("StartPoorBreath");
			sim.StartPoorBreath();
			arrayCounter = 0;
			// resetBreathNeeded = false;
		
		} else if(Input.GetKeyDown(KeyCode.B)) {
			Debug.Log("StartPoorerBreath");
			sim.StartPoorerBreath();
			arrayCounter = 0;
			// resetBreathNeeded = false;
		
		} else if(Input.GetKeyDown(KeyCode.N)) {
			Debug.Log("StartBadBreath");
			sim.StartBadBreath();
			arrayCounter = 0;
			// resetBreathNeeded = false;

		}
		else if(Input.GetKeyDown(KeyCode.M)) {
			Debug.Log("StartVariableBreath");
			sim.StartVariableLengthTest(10);
			arrayCounter = 0;
			// resetBreathNeeded = false;
		
		}
		

	}

// TODO, set the arrays to 0
	// void failedBreath() {
	// 	return;
	// }

	void ProcessBreath() {
		// Debug.Log("Process!");
		// Debug.Log(arrayCounter);
		// Debug.Log(Time.time);
		// Debug.Log(frameCounter);
		frameCounter++;
		if(frameCounter % 30 == 0 && arrayCounter < SpiroSim.NumDataPoints-1) {
			arrayCounter++;
			
		}
		// TODO implement functionality for failed breath
		if (lastFlow == 0 && lastArrayCounter != arrayCounter && sim._flowList[arrayCounter] == 0) {
			// END BREATHE
			// resetBreathNeeded = true;
			// failedBreath();
			// pressure = 0;
			// return;

		}
		if(sim._flowList[arrayCounter] == 1) {
			pressure += 3;
			currentPressurePlus = 3;
		} else if (sim._flowList[arrayCounter] == 3) {
			pressure += 1;
			currentPressurePlus = 1;
		} else {
			pressure += sim._flowList[arrayCounter];
			currentPressurePlus = sim._flowList[arrayCounter];
		}
		lastFlow = sim._flowList[arrayCounter];
		lastArrayCounter = arrayCounter;

		// TODO need to account for fluctuations in breath flow and then grade breathes


		


	}

    // Update is called once per frame
    void Update()
    {
		// Trigger for once you passed the level, ref line 34 Water.cs
		if(Time.timeScale != 0)
		{
			GetBreath();


			// Debug.Log("Pressure: "+pressure);
			// Think of E as our trigger
			if (Input.GetKey(KeyCode.E)){
				
				// TODO: Implement the resetBreath feature
				// if(resetBreathNeeded){
				// 	Debug.Log("Reset your breathe!");
				// } else {
				// 	ProcessBreath();
				// }
				ProcessBreath();
				
				
			}
			if(pressure>0)
			{	
				// 1*  = pressure in 
				pressure-=Mathf.Max(currentPressurePlus*(Mathf.Pow(pressure,(float)3.5)/Mathf.Pow(600,(float)3.5)),(float).5);
				// Debug.Log(pressure);
			}
			if(pressure<0)
			{
				pressure=0;
			}
			pressureText.SetText("Pressure: "+(int)(pressure));
			
			
			//scale.gameObject.transform.RotateAround(scale.transform.position, Vector3.forward, pressure/600);
			

			
			float rotateDegrees = 0f;
				
			if (Input.GetKey(KeyCode.E)) 
			{
				rotateDegrees -= currentPressurePlus;
			}
			
			if(pressure>0)
			{
				rotateDegrees += Mathf.Max(currentPressurePlus*(Mathf.Pow(pressure,(float)3.5)/Mathf.Pow(600,(float)3.5)),(float).5);
			}
				
			Vector3 currentVector = transform.position - scale.transform.position;
			currentVector.y = 0;
			float angleBetween = Vector3.Angle(initialVector, currentVector) * (Vector3.Cross(initialVector, currentVector).y > 0 ? 1 : -1);            
			float newAngle = Mathf.Clamp(angleBetween + rotateDegrees, -angleMax, angleMax);
			rotateDegrees = newAngle - angleBetween;
			
			if(pressure<=590)
			{
				scale.transform.RotateAround(scale.transform.position, Vector3.forward, rotateDegrees/(float)3.25);
			}
			if(pressure==0)
			{
				scale.gameObject.transform.localRotation = new Quaternion((float)0, (float)0, (float)0, (float)0);
			}
		
		
		}
			
		
		
		
		
		
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
