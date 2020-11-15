using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class grayscale : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	// Start is called before the first frame update
	void Start()
	{
		spriteRenderer=GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		string path = Application.persistentDataPath+"/player.love";

		if(File.Exists(path))
		{
			spriteRenderer.material.SetFloat("_GrayscaleAmount",0);
		}
		else
		{
			spriteRenderer.material.SetFloat("_GrayscaleAmount",1);
		}
		
		if(Input.GetKey(KeyCode.R)) 
		{
			try
			{
				File.Delete(path);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
		}
	}
}
