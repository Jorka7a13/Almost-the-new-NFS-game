using UnityEngine;
using System.Collections;

public class BackAndContinue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI(){
		
		if(GUI.Button (new Rect (0,Screen.height - 50,100,50), "Back")){
			
			Application.LoadLevel("ChooseCar");
			
			}
			
			
		if(GUI.Button(new Rect (Screen.width - 100,Screen.height - 50,100,50), "Continue")){
			
			Application.LoadLevel("ChooseTrackTunning");
			
			}
		
		
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
