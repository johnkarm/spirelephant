using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class levelGrayscale : MonoBehaviour
{
	GameObject Player;
	PlayerScript playerScript;
	private SpriteRenderer spriteRenderer;

// Pause
	public Animator animator;

	// Start is called before the first frame update
	void Start()
	{
        Player = GameObject.Find("Player"); 
        playerScript = Player.GetComponent<PlayerScript>();
		animator= GetComponent<Animator>();
		spriteRenderer=GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		
		if(name=="shop")
		{
			//If we don't have the costume
			if(!PlayerScript.costume)
			{
				spriteRenderer.material.SetFloat("_GrayscaleAmount",0);
				animator.speed = 1f;


			}
			else
			{
				spriteRenderer.material.SetFloat("_GrayscaleAmount",1);
				animator.speed = 0f;
			}
			
		}	
		
		if(name=="lakeLevel")
		{
			if(PlayerScript.levelOne)
			{
				spriteRenderer.material.SetFloat("_GrayscaleAmount",0);
			}
			else
			{
				spriteRenderer.material.SetFloat("_GrayscaleAmount",1);
			}
			
		}		
		if(name=="lavaLevel")
		{
			if(PlayerScript.levelTwo)
			{
				spriteRenderer.material.SetFloat("_GrayscaleAmount",0);
			}
			else
			{
				spriteRenderer.material.SetFloat("_GrayscaleAmount",1);
			}
			
		}		
		if(name=="fruitLevel")
		{
			if(PlayerScript.levelThree)
			{
				spriteRenderer.material.SetFloat("_GrayscaleAmount",0);
			}
			else
			{
				spriteRenderer.material.SetFloat("_GrayscaleAmount",1);
			}
			
		}
		

		

	}
}
