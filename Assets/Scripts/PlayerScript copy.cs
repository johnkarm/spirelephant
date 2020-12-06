// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro;
// using System; 

// public class PlayerScript : MonoBehaviour
// {
// 	static public int coins = 0;
// 	static public bool levelOne=true;
// 	static public bool levelTwo=false;
// 	static public bool levelThree=false;
// 	static public int levelOneFacts=0;
// 	static public int levelTwoFacts=0;
// 	static public int levelThreeFacts=0;
// 	static public string[] facts = new string[9];
// 	static public int numFacts=0;
// 	public float volume = 1;
// 	private TextMeshProUGUI[] allThings;
// 	private TextMeshProUGUI pageOne;
// 	private TextMeshProUGUI pageTwo;

	
//     // Start is called before the first frame update
//     void Start()
//     {
//         Screen.SetResolution(1600, 900, true);
// 		if(SceneManager.GetActiveScene().name=="facts")
// 		{
// 			allThings = FindObjectsOfType<TextMeshProUGUI>();
// 			foreach (TextMeshProUGUI value in allThings)
// 			{
// 				if(value.name=="pageOne")
// 				{
// 					pageOne = value;
// 				}
// 				if(value.name=="pageTwo")
// 				{
// 					pageTwo = value;
// 				}
// 			}			
// 		}

//     }

//     // Update is called once per frame
//     void Update()
//     {
// 		if(SceneManager.GetActiveScene().name=="facts")
// 		{
// 			string first="Fact 1: Elly Loves you\n\n";
// 			string second="";
// 			for(int i=0;i<4;i++)
// 			{
				
// 				if(facts[i]!=null)
// 				{
// 					first+="Fact "+(i+2).ToString()+": "+facts[i]+"\n\n";
					
// 				}
// 			}
// 			for(int i=4;i<9;i++)
// 			{
// 				if(facts[i]!=null)
// 				{
// 					second+="Fact "+(i+2).ToString()+": "+facts[i]+"\n\n";
// 				}
// 			}
// 			pageOne.SetText(first);
// 			pageTwo.SetText(second);
// 		}
// 		if (Input.GetKeyDown("space"))
// 		{
// 			Debug.Log("Game Was Saved!");
// 			saveSystem.savePlayer(this);
			
// 		}
// 		if (Input.GetKeyDown(KeyCode.Return))
// 		{
// 			Debug.Log("Game Was loaded!");
// 			loadMePlease();

// 		}
//     }
	
// 	public void loadMePlease()
// 	{
// 		playerData data = saveSystem.loadPlayer();
// 		coins=data.coins;
// 		levelOne=data.levelOne;
// 		levelTwo=data.levelTwo;
// 		levelThree=data.levelThree;	
// 		facts=data.facts;
// 		numFacts=data.numFacts;
// 		levelOneFacts=data.levelOneFacts;
// 		levelTwoFacts=data.levelTwoFacts;
// 		levelThreeFacts=data.levelThreeFacts;	
// 	}
	
// 	void OnMouseDown()
//     {
// 		Debug.Log(coins);
// 		Debug.Log(numFacts);
//         foreach(string item in facts)
//         {
//             Debug.Log(item);
//         }
		
// 	}
// }
