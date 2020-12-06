using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System; 

public class PlayerScript : MonoBehaviour
{
	static public int coins = 0;
	static public bool levelOne=true;
	static public bool levelTwo=false;
	static public bool levelThree=false;
	static public bool costume=false;
	static public int levelOneFacts=0;
	static public int levelTwoFacts=0;
	static public int levelThreeFacts=0;
	static public string[] facts = new string[9];
	static public int numFacts=0;
	static public float volume = 1f;
	public Sprite costume2;
	private TextMeshProUGUI[] allThings;
	private TextMeshProUGUI pageOne;
	private TextMeshProUGUI pageTwo;
	GameObject theCostume;
	GameObject theCostume2;
	GameObject audio;
	AudioSource audiosource;
	Animator anim;
	
	GameObject WATER;
	Water water;
	public SpriteRenderer spriteRenderer;
	
	

	
    void Start()
    {
		
		anim = GetComponent<Animator>();	
		if(SceneManager.GetActiveScene().name=="waterLevel")
		{
			WATER = GameObject.Find("Water");
			
		}
		if(SceneManager.GetActiveScene().name=="lavaLevel")
		{
			
			WATER = GameObject.Find("waterParent");
		}
		if(SceneManager.GetActiveScene().name=="fruitLevel")
		{
			
			WATER = GameObject.Find("ropeParent");
		}
		if(WATER)
		{
			water = WATER.GetComponent<Water>();
		}
		 
		theCostume = GameObject.Find("costume"); 
		theCostume2 = GameObject.Find("costume2");  
		if(theCostume)
		{
			spriteRenderer = theCostume.GetComponent<SpriteRenderer>(); 
			theCostume.SetActiveRecursively(false); 
		}  
		if(theCostume2)
		{
			theCostume2.SetActiveRecursively(false);  
		}
        Screen.SetResolution(1600, 900, true);
		if(SceneManager.GetActiveScene().name=="facts")
		{
			allThings = FindObjectsOfType<TextMeshProUGUI>();
			foreach (TextMeshProUGUI value in allThings)
			{
				if(value.name=="pageOne")
				{
					pageOne = value;
				}
				if(value.name=="pageTwo")
				{
					pageTwo = value;
				}
			}			
		}

    }

    // Update is called once per frame
    void Update()
    {
		if(GameObject.Find("Audio Source") != null) {
			Debug.Log("Found it");
			audio = GameObject.Find("Audio Source");
			audiosource = audio.GetComponent<AudioSource>();
			audiosource.volume = volume;
			Debug.Log(audiosource.volume);
		}
		
        if(theCostume&&costume)
		{	
			if(water.LevelWon)
			{
				
			}
			else
			{
				theCostume.SetActiveRecursively(true);
			}			
		}
		else if (theCostume)
		{
			theCostume.SetActiveRecursively(false);  	
		}
		if(SceneManager.GetActiveScene().name=="facts")
		{
			string first="Fact 1: Elly Loves you\n\n";
			string second="";
			for(int i=0;i<4;i++)
			{
				
				if(facts[i]!=null)
				{
					first+="Fact "+(i+2).ToString()+": "+facts[i]+"\n\n";
					
				}
			}
			for(int i=4;i<9;i++)
			{
				if(facts[i]!=null)
				{
					second+="Fact "+(i+2).ToString()+": "+facts[i]+"\n\n";
				}
			}
			pageOne.SetText(first);
			pageTwo.SetText(second);
		}
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
		costume=data.costume;	
		facts=data.facts;
		numFacts=data.numFacts;
		levelOneFacts=data.levelOneFacts;
		levelTwoFacts=data.levelTwoFacts;
		levelThreeFacts=data.levelThreeFacts;	
	}
	
	void OnMouseDown()
    {
		Debug.Log(coins);
		Debug.Log(numFacts);
        foreach(string item in facts)
        {
            Debug.Log(item);
        }
		
	}
	
	public void dollyUp()
	{
		spriteRenderer.sprite = costume2;
		
		//anim.SetBool("lavaEIsPressed",true);	
	}
}
