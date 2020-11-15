using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class PressureUpdater : MonoBehaviour
{
	public float pressure=0;
	public float rotateSpeed = 20.0f;
    public float angleMax = 90.0f;
	private Vector3 initialVector = Vector3.forward;
	//private bool wiggle = true;
	private SpiroSim sim;
	private int arrayCounter=0;
	private int frameCounter=1;
	private int lastFlow=0;
	private int lastArrayCounter= 0;
	public bool startedBreath = false;
	public bool failedBreath = false;
	public int currentPressurePlus = 0;
	private int timer=0;
	private float startTimeofBreath;
	private double variance;
	private float lastPressure = 0;
	 
	private TextMeshProUGUI pressureText;
	private TextMeshProUGUI BreathFeedback;
	private TextMeshProUGUI[] allThings;
	public List<int> breaths;
	
	
	Animator anim;

		
	
	//public Animator anim;

	
    // Start is called before the first frame update
	GameObject scale;
	GameObject player;
	GameObject water;
	
	

	
    void Start()
    {
		
		Application.targetFrameRate = 60;
		water = GameObject.Find("Water"); 
		breaths = new List<int>();
		scale = GameObject.Find("Scale");
		sim = gameObject.AddComponent<SpiroSim>() as SpiroSim;
		sim.LoadEmptyBreath();

		player = GameObject.Find("Player");    
		
		anim = player.GetComponent<Animator>();
		
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
			}
			else if(value.name=="BreathFeedback") {
				BreathFeedback = value;

			}
				
        }
    }

	void GetBreath() {
		
		if(Input.GetKey(KeyCode.Z)) {
			Debug.Log("StartBestBreath");
			sim.StartBestBreath();
			arrayCounter = 0;
			startedBreath = true;
			frameCounter = 1;
			startTimeofBreath = Time.time;
			variance = GetVariance(sim._flowList);
			// Debug.Log(GetVariance(sim._flowList));

		} else if(Input.GetKeyDown(KeyCode.X)) {
			Debug.Log("StartBetterBreath");
			sim.StartBetterBreath();
			arrayCounter = 0;
			startedBreath = true;
			frameCounter = 1;
			startTimeofBreath = Time.time;
			Debug.Log(GetVariance(sim._flowList));
			variance = GetVariance(sim._flowList);

		} else if(Input.GetKeyDown(KeyCode.C)) {
			Debug.Log("StartGoodBreath");
			sim.StartGoodBreath();
			arrayCounter = 0;
			startedBreath = true;
			frameCounter = 1;
			startTimeofBreath = Time.time;
			Debug.Log(GetVariance(sim._flowList));
			variance = GetVariance(sim._flowList);


		} else if(Input.GetKeyDown(KeyCode.V)) {
			Debug.Log("StartPoorBreath");
			sim.StartPoorBreath();
			arrayCounter = 0;
			startedBreath = true;
			frameCounter = 1;
			startTimeofBreath = Time.time;
			variance = GetVariance(sim._flowList);

		
		} else if(Input.GetKeyDown(KeyCode.B)) {
			Debug.Log("StartPoorerBreath");
			sim.StartPoorerBreath();
			arrayCounter = 0;
			startedBreath = true;
			frameCounter = 1;
			startTimeofBreath = Time.time;
			variance = GetVariance(sim._flowList);

		
		} else if(Input.GetKeyDown(KeyCode.N)) {
			Debug.Log("StartBadBreath");
			sim.StartBadBreath();
			arrayCounter = 0;
			startedBreath = true;
			frameCounter = 1;
			startTimeofBreath = Time.time;
			variance = GetVariance(sim._flowList);

		}
		else if(Input.GetKeyDown(KeyCode.M)) {
			Debug.Log("StartVariableBreath");
			sim.StartVariableLengthTest(10);
			arrayCounter = 0;
			startedBreath = true;
			frameCounter = 1;
			startTimeofBreath = Time.time;
			variance = GetVariance(sim._flowList);

		
		}
		else if(Input.GetKeyDown(KeyCode.P)) {
			Debug.Log("Stop Breath");
			sim.LoadEmptyBreath();
			arrayCounter = 0;
			startedBreath = false;
			lastFlow = 4;
			currentPressurePlus = 0;
			startTimeofBreath = Time.time;
		
		}
	}



	public double GetVariance(int[] values)
	{
		double avg = values.Average();
		double sum = values.Sum(v => (v - avg) * (v-avg));
		double denominator = values.Length;
		return sum / denominator;
	}

	void ProcessBreath() {

		if (frameCounter > 1000) {
			failedBreath = true;
			Time.timeScale = 0;
			Debug.Log("FAILED BREATH, Try again :)");
			currentPressurePlus = 0;

		}

		if (startedBreath && !failedBreath) {
			// Debug.Log(frameCounter)
			frameCounter++;
			if(frameCounter % 30 == 0 && arrayCounter < SpiroSim.NumDataPoints-1) {
				arrayCounter++;
			}
			
			Debug.Log(frameCounter);
			Debug.Log(Time.time - startTimeofBreath);
			
			
			breaths.Add((int)(sim._flowList[arrayCounter])); 
			if(sim._flowList[arrayCounter] == 1) {
				pressure += 3;
				currentPressurePlus = 3;
				BreathFeedback.SetText("Feedback: Perfect; 1");
			} else if (sim._flowList[arrayCounter] == 3) {
				pressure += 1;
				currentPressurePlus = 1;
				BreathFeedback.SetText("Feedback: Breathe Slower and Steadier; 3");
			} else if (sim._flowList[arrayCounter] == 2) {
				pressure += sim._flowList[arrayCounter];
				currentPressurePlus = sim._flowList[arrayCounter];
				BreathFeedback.SetText("Feedback: A little Slower; 2");
			} else {
				pressure += sim._flowList[arrayCounter];
				currentPressurePlus = sim._flowList[arrayCounter];
				BreathFeedback.SetText("Feedback: Aim for a slow steady breathe; 0");
			}

			// if(sim._flowList[arrayCounter] == 1) {
			// 	float fvariance = (float)variance;
			// 	currentPressurePlus = (int)Mathf.Floor(3 * (2.5f - fvariance));
			// 	pressure += currentPressurePlus;
			// 	BreathFeedback.SetText("Feedback: Perfect; 1");
			// } 
			// else if (sim._flowList[arrayCounter] == 3) {
			// 	float fvariance = (float)variance;
			// 	currentPressurePlus = (int)Mathf.Floor(1 * (2.5f - fvariance));
			// 	pressure += currentPressurePlus;
			// 	BreathFeedback.SetText("Feedback: Breathe Slower and Steadier; 3");
			// } 
			// else if (sim._flowList[arrayCounter] == 2) {
			// 	float fvariance = (float)variance;
			// 	currentPressurePlus = (int)Mathf.Floor(sim._flowList[arrayCounter] * (2.5f - fvariance));
			// 	pressure += currentPressurePlus;
			// 	BreathFeedback.SetText("Feedback: A little Slower; 2");
			// } 
			// else {
			// 	float fvariance = (float)variance;
			// 	currentPressurePlus = (int)Mathf.Floor(sim._flowList[arrayCounter] * (2.5f - fvariance));
			// 	pressure += currentPressurePlus;
			// 	BreathFeedback.SetText("Feedback: Aim for a slow steady breathe; 0");
			// }
		



			if (sim._flowList[arrayCounter] != 0){
				anim.SetBool("eIsPressed",true);
			}
			else
			{
				anim.SetBool("eIsPressed",false);
			
			}
			
			lastFlow = sim._flowList[arrayCounter];
			lastArrayCounter = arrayCounter;
		}

		// TODO need to account for fluctuations in breath flow and then grade breathes


		


	}

    // Update is called once per frame
    void Update()
    {
		// Trigger for once you passed the level, ref line 34 Water.cs
		if(Time.timeScale != 0)
		{
			GetBreath();

			
			ProcessBreath();



			if(pressure>0)
			{	
				
				pressure-=Mathf.Max(currentPressurePlus*(Mathf.Pow(pressure,(float)3.5)/Mathf.Pow(500,(float)3.5)),(float).5);
			}
			if(pressure<0)
			{
				pressure=0;
			}
			pressureText.SetText("Pressure: "+(int)(pressure));
			
			
			//scale.gameObject.transform.RotateAround(scale.transform.position, Vector3.forward, pressure/600);
			

			
			float rotateDegrees = 0f;
				
			// Hmmm
			// rotateDegrees += currentPressurePlus;
			
			
			// if(pressure>0)
			// {
			// 	rotateDegrees -= Mathf.Max(currentPressurePlus*(Mathf.Pow(pressure,(float)3.5)/Mathf.Pow(100,(float)3.5)),(float).5);
			// }


			// I couldn't figure out how this works so I just made it simpler
			// Vector3 currentVector = transform.position - scale.transform.position;
			// currentVector.y = 0;
			// Debug.Log(currentVector);
			// float angleBetween = Vector3.Angle(initialVector, currentVector) * (Vector3.Cross(initialVector, currentVector).y > 0 ? 1 : -1);            
			// float newAngle = Mathf.Clamp(angleBetween + rotateDegrees, -angleMax, angleMax);
			// rotateDegrees = (newAngle - angleBetween)/160;

			//rotate degrees should equal change in pressure.
			rotateDegrees = currentPressurePlus - Mathf.Max(currentPressurePlus*(Mathf.Pow(pressure,(float)3.5)/Mathf.Pow(500,(float)3.5)),(float).5);
			Debug.Log(rotateDegrees);
			Debug.Log(pressure - lastPressure);
			

			//1000 pressure = 180 degrees. 
			// every 1 pressure additional = 0.18 degrees. Because we are adding pressure exponentially, it should rotate in exponential form
			if(pressure<=495)
			{
				// scale.transform.RotateAround(scale.transform.position, Vector3.forward, rotateDegrees/(float)3.25);
				scale.transform.RotateAround(scale.transform.position, Vector3.forward, -rotateDegrees*0.18f);
			}
			if(pressure==0)
			{
				scale.gameObject.transform.localRotation = new Quaternion((float)0, (float)0, (float)0, (float)0);
			}
		
		
		}

		lastPressure = pressure;
			
		
		
		
		
		
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
