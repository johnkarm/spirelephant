using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settingsScript : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    GameObject slider;
    PlayerScript playerscript;
    void Start()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Slider");
        playerscript = player.GetComponent<PlayerScript>();

    }

    public void saveGame()
    {
		Debug.Log("Game Was Saved!");
		saveSystem.savePlayer(playerscript);
    }

    public void LoadMap()
    {
        SceneManager.LoadScene("menuScreen");
    }
	
    public void LoadMainMenu()
    {
		Debug.Log("Game Was Saved!");
		saveSystem.savePlayer(playerscript);
        SceneManager.LoadScene("startScreen");
    }
    public void OnValueChanged(float newValue)
    {
        // Debug.Log(newValue);
        PlayerScript.volume = newValue;
        Debug.Log(PlayerScript.volume);
    }
}
