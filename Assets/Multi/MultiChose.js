
var buttonSpacing : int = 5;
var buttonWidth : int = 400;
var buttonHeight : int = 400;
static var choice_:int =1;

var CarSelectionGridInt : int = 5;


var CarStrings : String[] = ["Lotus", "Lambo", "Ferrari California ", "Ferrari 599", "Unity"];



function OnGUI () {
  GUI.BeginGroup(new Rect(Screen.width - buttonWidth*2 -130 - buttonSpacing*40, buttonSpacing, buttonWidth +  buttonSpacing*160, buttonHeight/3 - buttonSpacing*4));
       GUI.Box(new Rect(    0, 0, buttonWidth*2-135  + buttonSpacing*2, buttonHeight/6 + 18 + buttonSpacing*5), "");
       CarSelectionGridInt= GUI.SelectionGrid(new Rect(buttonSpacing, buttonSpacing, buttonWidth*2 , buttonHeight/4), CarSelectionGridInt,CarStrings, 6);
       GUI.EndGroup();
	   
	   
		if(CarSelectionGridInt==0) {
			choice_ = 5;
		}	else	if(CarSelectionGridInt==1) {
			choice_ =4;
		} else	if(CarSelectionGridInt==2) {
			choice_ = 3;
		} else	if(CarSelectionGridInt==3) {
			choice_ = 2;
		} else	if(CarSelectionGridInt==4) {
			choice_ = 1;
		}
		 DontDestroyOnLoad (this);


}