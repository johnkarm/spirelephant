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
	public bool costume;
	public string[] facts;
	public int numFacts;
	public int levelOneFacts;
	public int levelTwoFacts;
	public int levelThreeFacts;
	
	public playerData(PlayerScript player)
	{
		coins=PlayerScript.coins;
		levelOne=PlayerScript.levelOne;
		levelTwo=PlayerScript.levelTwo;
		levelThree=PlayerScript.levelThree;
		facts=PlayerScript.facts;
		costume=PlayerScript.costume;
		numFacts=PlayerScript.numFacts;
		levelOneFacts=PlayerScript.levelOneFacts;
		levelTwoFacts=PlayerScript.levelTwoFacts;
		levelThreeFacts=PlayerScript.levelThreeFacts;
		
	}
}
