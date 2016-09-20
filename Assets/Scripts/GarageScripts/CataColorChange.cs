using UnityEngine;
using System.Collections;

public class CataColorChange : MonoBehaviour {

	public GameObject body;
	
	public Texture red, blue, yellow, pink, green, orange;
//	public Texture image1, image2, image3, image4, image5;
	
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
		body.renderer.material.mainTexture = red;
	}
	
	if(ColorsSelectionGridInt==1) {
		body.renderer.material.mainTexture = blue;
	}
	if(ColorsSelectionGridInt==2) {
		body.renderer.material.mainTexture = yellow;
	}
	if(ColorsSelectionGridInt==3) {
		body.renderer.material.mainTexture = pink;
	}
	if(ColorsSelectionGridInt==4) {
		body.renderer.material.mainTexture = green;
	}
	if(ColorsSelectionGridInt==5) {
		body.renderer.material.mainTexture = orange;
	}
	

}
	
	// Update is called once per frame
	void Update () {
	
	}
}
