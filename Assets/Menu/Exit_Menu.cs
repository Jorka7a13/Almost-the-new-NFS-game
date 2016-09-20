using UnityEngine;
using System.Collections;

public class Exit_Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnGUI(){
		
		GUI.BeginGroup(new Rect(Screen.width/2-190, Screen.height/2-100, 300, 60), ""); 		// Exit_Menu
		
		GUI.Box(new Rect(0, 0,  300, 60), "");	
		
						Application.Quit();

		   GUI.EndGroup();
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
