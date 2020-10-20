using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeUpdater : MonoBehaviour
{
	private int time=0;
	private TextMeshProUGUI timeText;
	private TextMeshProUGUI[] allThings;
    // Start is called before the first frame update
    void Start()
    {
		
        
		allThings = FindObjectsOfType<TextMeshProUGUI>();
		foreach (TextMeshProUGUI value in allThings)
        {
            if(value.name=="Time")
			{
				timeText = value;
			}
				
        }
    }
    // Update is called once per frame
    void Update()
    {
		time++;
        timeText.SetText("Time: "+(int)(time/60));
    }
}
