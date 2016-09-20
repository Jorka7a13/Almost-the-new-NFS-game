using UnityEngine;
using System.Collections;

public class SetTunningCar : MonoBehaviour {
	
	public GameObject F599 , Lotus, Lambo , FCa , Cata , body;
	public GameObject lotusBlack, lotusRed, lotusYellow, lotusGreen, lotusSilver, lotusBlue;
	public GameObject lamboBlack, lamboRed, lamboYellow, lamboGreen, lamboOrange, lamboBlue;
	public GameObject fCaBlack, fCaRed, fCaYellow, fCaGreen, fCaSilver, fCaBlue;
	public GameObject f599Black, f599Red, f599Yellow, f599White, f599Silver, f599Blue;
	
	public Texture red, blue, yellow, pink, green, orange;
	
	public static Transform _target , CataMass , LotusMass, LamboMass , FCaMass , F599Mass;
		
	public static int _CarSelectionGridInt;	
	int selectedColorInt; 

	// Use this for initialization
	void Start () {
		_CarSelectionGridInt=ChooseCar.CarSelectionGridInt;
		selectedColorInt=SetColorCS.ColorsSelectionGridInt;

		_target = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	if(_CarSelectionGridInt==0) {
		
		Cata.SetActiveRecursively(true);
		F599.SetActiveRecursively(false);
		FCa.SetActiveRecursively(false);
		Lambo.SetActiveRecursively(false);
		Lotus.SetActiveRecursively(false);
		
	if(CataColorChange.ColorsSelectionGridInt==0) {
		body.renderer.material.mainTexture = red;
	}
	
	if(CataColorChange.ColorsSelectionGridInt==1) {
		body.renderer.material.mainTexture = blue;
	}
	if(CataColorChange.ColorsSelectionGridInt==2) {
		body.renderer.material.mainTexture = yellow;
	}
	if(CataColorChange.ColorsSelectionGridInt==3) {
		body.renderer.material.mainTexture = pink;
	}
	if(CataColorChange.ColorsSelectionGridInt==4) {
		body.renderer.material.mainTexture = green;
	}
	if(CataColorChange.ColorsSelectionGridInt==5) {
		body.renderer.material.mainTexture = orange;
	}

			
			_target=CataMass;
	}
	
	if(_CarSelectionGridInt==1) {
		Cata.SetActiveRecursively(false);
		Lotus.SetActiveRecursively(true);
		F599.SetActiveRecursively(false);
		FCa.SetActiveRecursively(false);
		Lambo.SetActiveRecursively(false);
		
		lotusBlack.active =false;
		lotusRed.active =false;
		lotusYellow.active =false;
		lotusGreen.active =false;
		lotusSilver.active =false;
		lotusBlue.active =false;
		
					
		if(selectedColorInt==0) {
			lotusBlack.SetActiveRecursively(true);
			}
		
		if(selectedColorInt==1){
			lotusRed.SetActiveRecursively(true);
			}
		if(selectedColorInt==2){
			lotusYellow.SetActiveRecursively(true);
			}
		if(selectedColorInt==3){
			lotusGreen.SetActiveRecursively(true);
			}
		if(selectedColorInt==4){
			lotusSilver.SetActiveRecursively(true);
			}
		if(selectedColorInt==5){
			lotusBlue.SetActiveRecursively(true);
			}

	}
	if(_CarSelectionGridInt==2) {
		Cata.SetActiveRecursively(false);
		F599.SetActiveRecursively(false);
		Lambo.SetActiveRecursively(true);
		FCa.SetActiveRecursively(false);
		Lotus.SetActiveRecursively(false);
		
		lamboRed.active =false;
		lamboOrange.active =false;
		lamboYellow.active =false;
		lamboBlue.active =false;
		lamboBlack.active =false;
		lamboGreen.active =false;
		
		if(selectedColorInt==0) {
			lamboBlack.SetActiveRecursively(true);
			}
		if(selectedColorInt==1){
			lamboRed.SetActiveRecursively(true);
			}
		if(selectedColorInt==2){
			lamboYellow.SetActiveRecursively(true);
			}
		if(selectedColorInt==3){
			lamboGreen.SetActiveRecursively(true);
			}
		if(selectedColorInt==4){
			lamboOrange.SetActiveRecursively(true);
			lamboOrange.active = true;
			}
		if(selectedColorInt==5){
			lamboBlue.SetActiveRecursively(true);
			}			
	}
	if(_CarSelectionGridInt==3) {
		Cata.SetActiveRecursively(false);
		F599.SetActiveRecursively(false);
		FCa.SetActiveRecursively(true);
		Lambo.SetActiveRecursively(false);
		Lotus.SetActiveRecursively(false);
		
		fCaBlack.active =false;
		fCaBlue.active =false;
		fCaYellow.active =false;
		fCaRed.active =false;
		fCaSilver.active =false;
		fCaGreen.active =false;
		
		if(selectedColorInt==0) {
			fCaBlack.SetActiveRecursively(true);
			}
		if(selectedColorInt==1){
			fCaRed.SetActiveRecursively(true);
			}
		if(selectedColorInt==2){
			fCaYellow.SetActiveRecursively(true);
			}
		if(selectedColorInt==3){
			fCaGreen.SetActiveRecursively(true);
			}
		if(selectedColorInt==4){
			fCaSilver.SetActiveRecursively(true);
			}
		if(selectedColorInt==5){
			fCaBlue.SetActiveRecursively(true);
			}	

		
	}
	if(_CarSelectionGridInt==4) {
		Cata.SetActiveRecursively(false);
		F599.SetActiveRecursively(true);
		FCa.SetActiveRecursively(false);
		Lambo.SetActiveRecursively(false);
		Lotus.SetActiveRecursively(false);
		
		f599Black.active =false;
		f599Blue.active =false;
		f599Red.active =false;
		f599White.active =false;
		f599Yellow.active =false;
		f599Silver.active =false;
		
		if(selectedColorInt==0) {
			f599Black.SetActiveRecursively(true);
			}
		if(selectedColorInt==1){
			f599Red.SetActiveRecursively(true);
			}
		if(selectedColorInt==2){
			f599Yellow.SetActiveRecursively(true);
			}
		if(selectedColorInt==3){
			f599White.SetActiveRecursively(true);
			}
		if(selectedColorInt==4){
			f599Silver.SetActiveRecursively(true);
			}
		if(selectedColorInt==5){
			f599Blue.SetActiveRecursively(true);
			}	
		
	}
	
	
}
}