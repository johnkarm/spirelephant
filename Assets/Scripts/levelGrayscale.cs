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
	// Start is called before the first frame update
	void Start()
	{
        Player = GameObject.Find("Player"); 
        playerScript = Player.GetComponent<PlayerScript>();
		spriteRenderer=GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		
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
