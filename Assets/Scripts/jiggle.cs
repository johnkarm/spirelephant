using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; 

public class jiggle : MonoBehaviour
{
	int change = 1;
	int count =0;
	int frameCounter=0;
	int maxDrift =12;
    void Start()
    {
		if(name=="WaterBack")
		{

			change = -1;
		}

    }

    // Update is called once per frame
    void Update()
    {	
		if(frameCounter==0)
		{
			
			if(count==maxDrift)
			{
				change = -1;
			}
			if(count==-maxDrift)
			{
				change = +1;
			}
			count+=change;
			
			
			//Debug.Log(count);
			transform.position += new Vector3(((maxDrift-Math.Abs(count))/100.0f)*change, 0, 0);
			//change = )
			
			/*
			if(count<0)
			{
				transform.position -= new Vector3((6-Math.Abs(count))/100.0f, 0, 0);	
			
			}
			if(count>0)
			{
				transform.position += new Vector3((6-Math.Abs(count))/100.0f, 0, 0);
				
			}
			if(count==0)
			{
				transform.position += new Vector3(((6-Math.Abs(count))/100.0f)*change, 0, 0);
			}*/
		}
		frameCounter++;
		if(frameCounter==24)
		{
			frameCounter=0;
		}
    }
}
