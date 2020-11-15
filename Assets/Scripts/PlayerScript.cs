using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System; 

public class PlayerScript : MonoBehaviour
{
	static public int coins = 0;
	static public bool levelOne=true;
	static public bool levelTwo=false;
	static public bool levelThree=false;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("space"))
		{
			Debug.Log("Game Was Saved!");
			saveSystem.savePlayer(this);
			
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log("Game Was loaded!");
			loadMePlease();

		}
    }
	
	public void loadMePlease()
	{
		playerData data = saveSystem.loadPlayer();
		coins=data.coins;
		levelOne=data.levelOne;
		levelTwo=data.levelTwo;
		levelThree=data.levelThree;	
	}
	
	void OnMouseDown()
    {
		Debug.Log(coins);
	}
}
