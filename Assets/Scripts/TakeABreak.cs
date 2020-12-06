using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeABreak : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerScript playerscript;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        playerscript = player.GetComponent<PlayerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
		Time.timeScale = 1;
		Debug.Log("Game Was Saved!");
		saveSystem.savePlayer(playerscript);
        SceneManager.LoadScene("startScreen");

    }
}
