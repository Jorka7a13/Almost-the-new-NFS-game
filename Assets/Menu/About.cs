using UnityEngine;
using System.Collections;

public class About : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnGUI(){
		

		GUI.BeginGroup(new Rect(Screen.width/2-190, Screen.height/2-100, 360, 210));
		GUI.Box(new Rect(0, 0,  360, 210), "About");
       
			if (Input.GetKeyDown ("escape")){
						Application.LoadLevel("Menu");
			}

		   GUI.EndGroup();
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
