using UnityEngine;
using System.Collections;
using System.Xml; 
using System.Xml.Serialization; 
using System.Text; 
using System.IO; 



public class Main_Menu : MonoBehaviour {
	
	public GameObject MainMenu;
   
    public static int transfer;
	
    public static int SelectedOption;
    public string[] FieldNames;
    int buttonSpacing, buttonWidth, buttonHeight;
   
   // Use this for initialization
   void Start () {
 
       SelectedOption = 5;
       FieldNames =  new string[5] {"Race"," Your Cars"," Multiplayer" ,"About", " Exit"} ;
       buttonSpacing = 5;
       buttonWidth = 350;
       buttonHeight = 200;

   }
   void OnGUI() {
	   if(transfer == 0){
		   MainMenu.SetActiveRecursively(true);
		   
	   
	   
	GUI.BeginGroup(new Rect(Screen.width/2-190, Screen.height/2-100, 360, 210));
       GUI.Box(new Rect(0, 0,  360, 210), "");
       SelectedOption = GUI.SelectionGrid(new Rect(buttonSpacing, buttonSpacing, buttonWidth, buttonHeight), SelectedOption,FieldNames, 1);
		GUI.EndGroup();
	   
	   if(SelectedOption == 0){ // Go to Garage
		   Application.LoadLevel("ChooseCar");
		}
       if(SelectedOption==1) {
		  Application.LoadLevel("YourCars");   
       }
	   
	   if(SelectedOption == 2){ // Multiplayer Menu
		   	Application.LoadLevel("MultiChooseCar");  
		}
		if(SelectedOption == 3){ // About
			Application.LoadLevel("About");
		}
	   if(SelectedOption == 4){ // Exit
	
		Application.Quit();
		   
		}	
		
	}
}
   // Update is called once per frame
   void Update () {
   
   }
}

