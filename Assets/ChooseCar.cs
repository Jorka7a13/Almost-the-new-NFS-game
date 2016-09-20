using UnityEngine;
using System.Collections;

public class ChooseCar : MonoBehaviour {

	//Info and Price strings
	private string UnityCarInfo, LotusCarInfo, LamboCarInfo, FCaCarInfo, F599CarInfo, lotusPrice,lamboPrice, fCaPrice, f599Price;
	public string money;

	// Cars
	public GameObject F599 , Lotus, Lambo , FCa , Cata; 
	
	//Thumbnail Images
	public  Texture2D[] ThumbnailsLocked;
	public  Texture2D LotusLogoLocked, LamboLogoLocked, FerrariCaLogoLocked, Ferrari599LogoLocked;
	public  Texture2D  UnityLogo , LotusLogo, LamborghiniLogo, FerrariCALogo , Ferrari599Logo;
	
	//Var that shows selected car. Communicates with other scripts!! 
	public static int CarSelectionGridInt, CarSelectionGridInt2;
	
	int buttonSpacing, buttonWidth, buttonHeight;
	
	//Initialization!
	void Start () {
		
		lotusPrice = "$75,000";
		lamboPrice = "$354,000";
		fCaPrice="$200,000 ";
		f599Price = "$410,000 ";
		
		money=xmlReaderRights.money_.ToString();
		
		UnityCarInfo = "Class: Sports Car \n Transmission:	4-speed manual \n Curb weight: 1,800 kg \n Engine: Unity V8 \n Length: 4,464 mm \n Width: 1,752 mm \n Height: 1,246 mm \n Top Speed: 130 mph ";
		LotusCarInfo = "Class: Sports Car \n Transmission: 6-speed manual \n Curb weight: 1,350 kg \n Engine: 3.5 L Toyota 2GR-FE V6 \n Length: 4,342 mm \n Width: 1,848 mm \n Height: 1,223 mm \n Top Speed: 162 mph";
		LamboCarInfo = "Class: Sports Car \n Transmission: 6-speed manual \n Curb weight: 1,650 kg \n Engine: 6.2 L V12 \n Length: 4,580 mm \n Width: 2,045 mm \n Height: 1,135 mm \n Top Speed: 213 mph";
		FCaCarInfo ="Class: Sports Car \n Transmission: 7-speed manual \n Curb weight: 1,630 kg \n Engine: 4,297 cc (262.2 cu in) 90° V8 \n Length: 4,563 mm \n Width: 1,902 mm  \n Height: 1,308 mm \n Top Speed: 192 mph";
		F599CarInfo = "Class: Grand tourer \n Transmission: 6-speed manual \n Curb weight: 1,688 kg \n Engine: 6.0 L Tipo F140C V12 \n Length: 4,665 mm \n Width: 1,962 mm \n Height: 1,336 mm \n Top Speed: 202 mph";
	
		CarSelectionGridInt = 0;
		
	    ThumbnailsLocked = new Texture2D[] {UnityLogo , LotusLogoLocked, LamboLogoLocked, FerrariCaLogoLocked, Ferrari599LogoLocked};
	
		buttonSpacing = 5;
		buttonWidth = 400;
		buttonHeight = 400;

	}
	
	void OnGUI () {
			
       GUI.BeginGroup(new Rect(Screen.width - buttonWidth*2 -130 - buttonSpacing*40, buttonSpacing, buttonWidth +  buttonSpacing*160, buttonHeight/3 - buttonSpacing*4));
       GUI.Box(new Rect(    0, 0, buttonWidth*2-135  + buttonSpacing*2, buttonHeight/6 + 18 + buttonSpacing*5), "");
       CarSelectionGridInt= GUI.SelectionGrid(new Rect(buttonSpacing, buttonSpacing, buttonWidth*2 , buttonHeight/4), CarSelectionGridInt,ThumbnailsLocked, 6);
       GUI.EndGroup();
		
		
/*
If selected car is bought you can see filled info box and car itself 		
*/
		if(xmlReaderRights.lotusStatus_ != 0){
			ThumbnailsLocked[1] = LotusLogo;
			
				if(CarSelectionGridInt==1) {
		
					Cata.SetActiveRecursively(false);
					F599.SetActiveRecursively(false);
					FCa.SetActiveRecursively(false);
					Lambo.SetActiveRecursively(false);
					Lotus.SetActiveRecursively(true);

					GUI.Box(new Rect(0, 0, Screen.width-1150, Screen.height-400), "Lotus Evora");
					GUI.Box(new Rect(0, 20, Screen.width-1150, Screen.height-400), LotusCarInfo );
					
					CarSelectionGridInt = 1;
				}

			}
			
		if(xmlReaderRights.lamboStatus_ != 0){
			ThumbnailsLocked[2] = LamborghiniLogo;
			
				if(CarSelectionGridInt==2) {
					Cata.SetActiveRecursively(false);
					F599.SetActiveRecursively(false);
					FCa.SetActiveRecursively(false);
					Lambo.SetActiveRecursively(true);
					Lotus.SetActiveRecursively(false);
					
					GUI.Box(new Rect(0, 0, Screen.width-1150, Screen.height-400), "Lamborghini Murcielago");
					GUI.Box(new Rect(0, 20, Screen.width-1150, Screen.height-400), LamboCarInfo);

				}	
			
			}
			
		if(xmlReaderRights.fCaStatus_ != 0){
			ThumbnailsLocked[3] = FerrariCALogo;
			
				if(CarSelectionGridInt==3) {
					Cata.SetActiveRecursively(false);
					F599.SetActiveRecursively(false);
					FCa.SetActiveRecursively(true);
					Lambo.SetActiveRecursively(false);
					Lotus.SetActiveRecursively(false);
					
					GUI.Box(new Rect(0, 0, Screen.width-1150, Screen.height-400), "Ferrari California");
					GUI.Box(new Rect(0, 20, Screen.width-1150, Screen.height-400), FCaCarInfo);
					
				}

			}
			
		if(xmlReaderRights.f599Status_ != 0){
			ThumbnailsLocked[4] = Ferrari599Logo;
			
						if(CarSelectionGridInt==4) {
								Cata.SetActiveRecursively(false);
								F599.SetActiveRecursively(true);
								FCa.SetActiveRecursively(false);
								Lambo.SetActiveRecursively(false);
								Lotus.SetActiveRecursively(false);
								
								GUI.Box(new Rect(0, 0, Screen.width-1150, Screen.height-400), "Ferrari 599");
								GUI.Box(new Rect(0, 20, Screen.width-1150, Screen.height-400), F599CarInfo);		

						}

			}		
			
/*		
Shows Price tag for every car that is not bought
*/			
	if(xmlReaderRights.lotusStatus_ == 0){		 // for Lotus
		if(CarSelectionGridInt==1) {
		
					GUI.Box(new Rect(0, 0, Screen.width-1150, Screen.height-400), "Lotus Evora");
					GUI.Box(new Rect(0, 20, Screen.width-1150, Screen.height-400), lotusPrice + " \n Your money $" +money);
					
				}
			}
			
	if(xmlReaderRights.lamboStatus_ == 0){ 	//for Lambo
		if(CarSelectionGridInt==2) {
		
					GUI.Box(new Rect(0, 0, Screen.width-1150, Screen.height-400), "Lamborghini Murcielago");
					GUI.Box(new Rect(0, 20, Screen.width-1150, Screen.height-400), lamboPrice + " \n Your money $" +money);
					
				}
			}
	if(xmlReaderRights.fCaStatus_ == 0){			//for Ferrari CA
		if(CarSelectionGridInt==3) {
		
					GUI.Box(new Rect(0, 0, Screen.width-1150, Screen.height-400), "Ferrari California");
					GUI.Box(new Rect(0, 20, Screen.width-1150, Screen.height-400), fCaPrice + " \n Your money $" +money);
					
				}
			}
	if(xmlReaderRights.f599Status_ == 0){		//for Ferrari 599	
		if(CarSelectionGridInt==4) {
		
					GUI.Box(new Rect(0, 0, Screen.width-1150, Screen.height-400), "Ferrari F599");
					GUI.Box(new Rect(0, 20, Screen.width-1150, Screen.height-400), f599Price + " \n Your money $" +money);
					
				}
			}			
/*
Unity car is always active!
*/			
	if(CarSelectionGridInt==0) {
		
		Cata.SetActiveRecursively(true);
		F599.SetActiveRecursively(false);
		FCa.SetActiveRecursively(false);
		Lambo.SetActiveRecursively(false);
		Lotus.SetActiveRecursively(false);
		
		CarSelectionGridInt = 0;
		GUI.Box(new Rect(0, 0, Screen.width-1150, Screen.height-400), "Unit One");
		GUI.Box(new Rect(0, 20, Screen.width-1150, Screen.height-400), UnityCarInfo );
		
	}
		
	if(GUI.Button (new Rect (0,Screen.height - 50,100,50), "Back")){ // Brings you back to the Main Menu
			
			Application.LoadLevel("Menu");
			
	}
	
	xmlReaderRights reader = new xmlReaderRights();
	reader.Start();
	
}

	// Update is called once per frame
	void Update () {
	
	}
}
