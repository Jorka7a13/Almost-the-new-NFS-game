using UnityEngine;
using System.Collections;

public class Multiplayer_Menu : MonoBehaviour {

       public static int SelectedOption;
       public string[] FieldNames;
       int buttonSpacing, buttonWidth, buttonHeight;
   
   // Use this for initialization
   void Start () {
       SelectedOption = 0;
       FieldNames =  new string[5] {"Free Ride"," Time Trail","Circuit" ," Sprint", "Drag"} ;
       buttonSpacing = 5;
       buttonWidth = 350;
       buttonHeight = 200;
   }
   void OnGUI() {

	   
	GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height -100  - 300, 1000, 210));
       GUI.Box(new Rect(0, 0, 360,210), "");
       SelectedOption = GUI.SelectionGrid(new Rect(buttonSpacing, buttonSpacing, buttonWidth, buttonHeight), SelectedOption,FieldNames, 1);
    GUI.EndGroup();
	   
/*    GUI.BeginGroup(Rect(Screen.width/2 - 240, 220, 480, 260));

       if(GUI.Button(Rect(0, 0, 480, 80), image1)) {
           Application.LoadLevel(1);
       }
   
       if(GUI.Button(Rect(0, 90, 480, 80), image2)) {
           Application.LoadLevel(4);
       }
       
       if(GUI.Button(Rect(0, 180, 480, 80),image3)) {
           Application.Quit();
       }
       
   GUI.EndGroup();
*/
}
   // Update is called once per frame
   void Update () {
   
   }
}

