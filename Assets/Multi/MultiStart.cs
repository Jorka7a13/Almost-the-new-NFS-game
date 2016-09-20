using UnityEngine;
using System.Collections;

public class MultiStart: MonoBehaviour {
	
	public string[] Thumbnails;
		
	public static int SelectionGridInt;
	
	public static int _CarSelectionGridInt; 
	
	int buttonSpacing, buttonWidth, buttonHeight;
	
	
void Start () {
	
		SelectionGridInt = 3;
		//_CarSelectionGridInt=ChooseCar.CarSelectionGridInt;
		
		Thumbnails = new string[] {"Go to Garage","Continue"};
		buttonSpacing = 5;
		buttonWidth = 400;
		buttonHeight = 400;

	}
	
void OnGUI () {

       GUI.BeginGroup(new Rect(Screen.width - buttonWidth+ 125  + buttonSpacing, buttonSpacing, buttonWidth +  buttonSpacing/2, buttonHeight/2 - buttonSpacing));
       GUI.Box(new Rect(    0, 0, buttonWidth/2 + 75 , buttonHeight/5+ buttonSpacing*5), "");
       SelectionGridInt= GUI.SelectionGrid(new Rect(buttonSpacing, buttonSpacing, buttonWidth*2 , buttonHeight/4), SelectionGridInt,Thumbnails, 6);
   GUI.EndGroup();

}

	// Update is called once per frame
	void Update () {
		
			if(SelectionGridInt==0) { // Go to Garage
		
				if (ChooseCar.CarSelectionGridInt == 0){
			
					Application.LoadLevel("GarageCata");
			
				};
				
				if(xmlReaderRights.lotusStatus_ != 0){
					if (ChooseCar.CarSelectionGridInt == 1){
					
					Application.LoadLevel("GarageLotus");
					
					};	
				}
			
				if(xmlReaderRights.lamboStatus_ != 0){				
						 if (ChooseCar.CarSelectionGridInt == 2){
							
							Application.LoadLevel("GarageLamborghini");
							
						};
				}	

				if(xmlReaderRights.fCaStatus_ != 0){				
						 if (ChooseCar.CarSelectionGridInt== 3){
							
							Application.LoadLevel("GarageFerrariCa");
							
						};
					}	
					
				if(xmlReaderRights.f599Status_ != 0){	
					 if (ChooseCar.CarSelectionGridInt == 4){
						
						Application.LoadLevel("GarageFerrari599");
						
					}
				}
	}
	
	if(SelectionGridInt==1) { // Start
		
		Application.LoadLevel("Lobby");

	}

	
	}
}
