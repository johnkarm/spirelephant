using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishHop : MonoBehaviour
{
    // Start is called before the first frame update
	float spd = .04f;
	public bool finish=false;
	int timeToFinish=380;
	int direction=1;
	int start=-1;
	float time=0;
	int oldTime=0;
	//Animator anim;
	
	private void Awake(){
		if((name=="Roary"))
		{
			direction=-1;
			start=0;
			timeToFinish=180;
		}
		//anim = GetComponent<Animator>();
		
	}

    // Update is called once per frame
    void Update()
    {
		if(name=="appleParent")
		{
			if(finish&&transform.position.y>2)
			{
				transform.Translate(0,(float)(-1*spd),0);
			}
		}
		else
		{
			if(transform.position.y<-2.4)
			{
				time=0;
			}
			if (finish&&oldTime<timeToFinish){
				oldTime+=1;
				transform.Translate((float)(direction*spd),0,0);
				//Debug.Log(Time.deltaTime);
				transform.position = new Vector3(transform.position.x, start+(float)(2*(Mathf.Sin(time))), transform.position.z);
				time+=Time.deltaTime;
				
			}			
		}

    }
}
