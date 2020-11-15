using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class goToWaterLevel : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
			
	}

	// Update is called once per frame
	void Update()
	{
			
	}

    void OnMouseDown()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        //SceneManager.LoadScene("waterLevel");
		
		if(name=="lakeLevel")
		{
			SceneManager.LoadScene("waterLevel");
			
		}
		if(name=="lavaLevel")
		{
			//SceneManager.LoadScene("menuScreen");
			Debug.Log("Level Not In Yet!");	
			
		}
		if(name=="fruitLevel")
		{
			//SceneManager.LoadScene("menuScreen");
			Debug.Log("Level Not In Yet!");	
		}

    }
	
		void OnMouseOver()
    {
        transform.localScale=new Vector3(1.5f,1.5f,0f);
		
        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        transform.localScale=new Vector3(1f,1f,0f);
    }
}
