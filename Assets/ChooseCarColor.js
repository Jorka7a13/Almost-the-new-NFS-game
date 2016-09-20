var buttonSpacing : int = 5;
var buttonWidth : int = 350;
var buttonHeight : int = 450;

var chooseColorsGridInt : int = 5;
var chooseColorsStrings : String[] = ["Red", "Blue", "Yellow", "Pink", "Green", "Orange"];

var chooseColorButtonWidth : int = 350;
var chooseColorButtonHeight : int = 250;

var red: Texture2D;
var blue: Texture2D;
var yellow: Texture2D;
var pink: Texture2D;

var body : GameObject;

var redText : Texture;
var blueText : Texture;
var yellowText : Texture;
var pinkText : Texture;
var greenText : Texture;
var orangeText : Texture;


function OnGUI () {

	// Choose (type of) Parts	
	
	GUI.BeginGroup (Rect(Screen.width - buttonWidth - buttonSpacing*3, buttonHeight/5 + buttonSpacing*4, chooseColorButtonWidth +  buttonSpacing*2, chooseColorButtonHeight +  buttonSpacing*2), "");
		GUI.Box(Rect(0, 0, chooseColorButtonWidth +  buttonSpacing*2, chooseColorButtonHeight*4 +  buttonSpacing*2), "");
		chooseColorsGridInt = GUI.SelectionGrid(Rect(buttonSpacing, buttonSpacing, chooseColorButtonWidth, chooseColorButtonHeight), chooseColorsGridInt, chooseColorsStrings, 3);
	GUI.EndGroup();
		
			
	if(chooseColorsGridInt == 0) {
		// Red Color is selected

		body.renderer.material.mainTexture = redText;
	
	} else if(chooseColorsGridInt == 1) {
		// Blue Color is selected

		body.renderer.material.mainTexture = blueText;
		
	} else if (chooseColorsGridInt == 2) {
		// Yellow color is selected
		body.renderer.material.mainTexture = yellowText;
		
	}
	
		 else if (chooseColorsGridInt == 3) {
		// Pink color is selected
		body.renderer.material.mainTexture = pinkText;
		
	
		} else if (chooseColorsGridInt == 4) {
		// Green color is selected
		body.renderer.material.mainTexture = greenText;
		
	
		} else if (chooseColorsGridInt == 5) {
		// Orange color is selected
		body.renderer.material.mainTexture = orangeText;
		
	}
		
	
}