using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
	public int coins;	
	public bool levelOne;
	public bool levelTwo;
	public bool levelThree;
	
	public playerData(PlayerScript player)
	{
		coins=PlayerScript.coins;
		levelOne=PlayerScript.levelOne;
		levelTwo=PlayerScript.levelTwo;
		levelThree=PlayerScript.levelThree;
		
	}
}
