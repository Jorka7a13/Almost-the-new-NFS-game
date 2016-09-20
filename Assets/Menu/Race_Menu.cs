using UnityEngine;
using System.Collections;

public class Race_Menu : MonoBehaviour {

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
       GUI.BeginGroup(new Rect(Screen.width/2-190, Screen.height/2-100, 360, 210));
       GUI.Box(new Rect(0, 0,  360, 210), "Nedo do some stuff here!!!");
   GUI.EndGroup();


}
   // Update is called once per frame
   void Update () {
   
   }
}

