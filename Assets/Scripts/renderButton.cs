using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderButton : MonoBehaviour
{
	GameObject button;
    // Start is called before the first frame update
    void Start()
    {
			button = GameObject.Find("Button");
			button.SetActiveRecursively(false);  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void renderTheButton()
	{
		button.SetActiveRecursively(true);  
		
	}
}
