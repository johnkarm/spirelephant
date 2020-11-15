using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	float spd = .01f;
	Animator anim;
	
	private void Awake(){
		float walkSpd = spd;
		float collisionSpd = spd+(float).01;
		anim = GetComponent<Animator>();
		
	}
	
	
	private void Update(){
		
		if (Input.GetKey(KeyCode.A)){
			if((Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))&&!(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.S)))
			{
				transform.Translate((float)(-1.05*spd/Mathf.Sqrt(2)), 0, 0);
			}
			else
			{
				transform.Translate((float)(-spd),0,0);
			}
			
		}
		if (Input.GetKey(KeyCode.W)){
			if((Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))&&!(Input.GetKey(KeyCode.A)&&Input.GetKey(KeyCode.D)))
			{
				transform.Translate(0, (float)(1.05*spd/Mathf.Sqrt(2)), 0);
			}
			else
			{
				transform.Translate(0,(float)(spd),0);
			}
			
		}
		if (Input.GetKey(KeyCode.S)){
			if((Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))&&!(Input.GetKey(KeyCode.A)&&Input.GetKey(KeyCode.D)))
			{
				transform.Translate(0, (float)(-1.05*spd/Mathf.Sqrt(2)), 0);
			}
			else
			{
				transform.Translate(0,(float)(-spd),0);
			}
			
		}
		if (Input.GetKey(KeyCode.D)){
			if((Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))&&!(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.S)))
			{
				transform.Translate((float)(1.05*spd/Mathf.Sqrt(2)), 0, 0);
			}
			else
			{
				transform.Translate((float)(spd),0,0);
			}
			
		}
		
		
		if (Input.GetKey(KeyCode.E)){
			anim.SetBool("eIsPressed",true);
		}
		else
		{
			anim.SetBool("eIsPressed",false);
			
		}
		
		
		
		/*
		float speed = 4f;
		float movex = 0f;
		float movey = 0f;
		
		if (Input.GetKey(KeyCode.W)){
			movey=+1f;
			
		}
		
		if (Input.GetKey(KeyCode.A)){
			movex=-1f;
			
		}
		
		if (Input.GetKey(KeyCode.S)){
			movey=-1f;
			
		}
		
		if (Input.GetKey(KeyCode.D)){
			movex=+1f;
			
		}
		Vector3 moveDir = new Vector3(movex,movey);
		transform.position += moveDir*speed*Time.deltaTime;
		
		*/
	}
}
