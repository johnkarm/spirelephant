using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class retryWaterLevel : MonoBehaviour
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
        Debug.Log("hey");
		Time.timeScale = 1;
        SceneManager.LoadScene("waterLevel");

    }

}
