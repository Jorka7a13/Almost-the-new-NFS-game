using UnityEngine;
using System.Collections;

public class SetColorCS : MonoBehaviour {

	public GameObject blackBody, redBody, yellowBody, greenBody, orangeBody, blueBody;
		
	public Texture2D image0, image1, image2, image3, image4, image5;
	
	public Texture2D[] Thumbnails; 	
	
	public static int ColorsSelectionGridInt;
	
	int buttonSpacing, buttonWidth, buttonHeight;

	// Use this for initialization
	void Start () {
		ColorsSelectionGridInt = 0;
		Thumbnails = new Texture2D[6] {image0,image1, image2, image3, image4, image5};
		buttonSpacing = 5;
		buttonWidth = 350;
		buttonHeight = 200;
	}
	
	void OnGUI () {

// Hoods
	GUI.BeginGroup(new Rect(Screen.width - buttonWidth - buttonSpacing*3, buttonSpacing, buttonWidth +  buttonSpacing*2, buttonHeight + buttonSpacing*2));
		GUI.Box(new Rect(0, 0, buttonWidth + buttonSpacing*2, buttonHeight + buttonSpacing*2), "");
		ColorsSelectionGridInt = GUI.SelectionGrid(new Rect(buttonSpacing, buttonSpacing, buttonWidth, buttonHeight), ColorsSelectionGridInt,Thumbnails, 2);
	GUI.EndGroup();

		if(ColorsSelectionGridInt==0) {
			
			blackBody.SetActiveRecursively(true);
			redBody.SetActiveRecursively(false);
			yellowBody.SetActiveRecursively(false);
			greenBody.SetActiveRecursively(false);
			orangeBody.SetActiveRecursively(false);
			blueBody.SetActiveRecursively(false);
		}
		if(ColorsSelectionGridInt==1) {
			//blue
		
			blackBody.SetActiveRecursively(false);
			redBody.SetActiveRecursively(true);
			yellowBody.SetActiveRecursively(false);
			greenBody.SetActiveRecursively(false);
			orangeBody.SetActiveRecursively(false);
			blueBody.SetActiveRecursively(false);
		}
		if(ColorsSelectionGridInt==2) {
			// yellow
			
			blackBody.SetActiveRecursively(false);
			redBody.SetActiveRecursively(false);
			yellowBody.SetActiveRecursively(true);
			greenBody.SetActiveRecursively(false);
			orangeBody.SetActiveRecursively(false);
			blueBody.SetActiveRecursively(false);
		}
		if(ColorsSelectionGridInt==3) {
					//pink
			
			blackBody.SetActiveRecursively(false);
			redBody.SetActiveRecursively(false);
			yellowBody.SetActiveRecursively(false);
			greenBody.SetActiveRecursively(true);
			orangeBody.SetActiveRecursively(false);
			blueBody.SetActiveRecursively(false);
		}
		if(ColorsSelectionGridInt==4) {
			//green
			
			blackBody.SetActiveRecursively(false);
			redBody.SetActiveRecursively(false);
			yellowBody.SetActiveRecursively(false);
			greenBody.SetActiveRecursively(false);
			orangeBody.SetActiveRecursively(true);
			blueBody.SetActiveRecursively(false);
		}
		if(ColorsSelectionGridInt==5) {
			//orage
			blackBody.SetActiveRecursively(false);
			redBody.SetActiveRecursively(false);
			yellowBody.SetActiveRecursively(false);
			greenBody.SetActiveRecursively(false);
			orangeBody.SetActiveRecursively(false);
			blueBody.SetActiveRecursively(true);
		}

		
	/*GUI.BeginGroup(new Rect(0,0,200,300));
		GUI.Box(new Rect(0, 0, 200,300), "");
		if(GUI.Button(new Rect(0,0,200,300), "Start")){
				Application.LoadLevel("CompleteSceneTuninged");
			}
	GUI.EndGroup();
*/
	}
	// Update is called once per frame
	void Update () {
	
	}
}
