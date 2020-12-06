using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class buyCostume : MonoBehaviour
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
		
	}
	
	void OnMouseDown()
    {
		if(PlayerScript.coins>250&&!PlayerScript.costume)
		{
			PlayerScript.coins-=250;	
			PlayerScript.costume=true;
		}
	}
}
