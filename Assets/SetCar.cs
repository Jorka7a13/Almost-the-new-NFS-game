using UnityEngine;
using System.Collections;

public class SetCar : MonoBehaviour {

	public GameObject F599 , Lotus, Lambo , FCa , Cata;
	public static Transform _target , CataMass , LotusMass, LamboMass , FCaMass , F599Mass;
		
	public static int _CarSelectionGridInt;
	
	// Use this for initialization
	void Start () {
		_CarSelectionGridInt=ChooseCar.CarSelectionGridInt;
		
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
			_target=CataMass;
	}
	
	if(_CarSelectionGridInt==1) {
		Cata.SetActiveRecursively(false);
		F599.SetActiveRecursively(false);
		FCa.SetActiveRecursively(false);
		Lambo.SetActiveRecursively(false);
		Lotus.SetActiveRecursively(true);
	}
	if(_CarSelectionGridInt==2) {
		Cata.SetActiveRecursively(false);
		F599.SetActiveRecursively(false);
		FCa.SetActiveRecursively(false);
		Lambo.SetActiveRecursively(true);
		Lotus.SetActiveRecursively(false);
	}
	if(_CarSelectionGridInt==3) {
		Cata.SetActiveRecursively(false);
		F599.SetActiveRecursively(false);
		FCa.SetActiveRecursively(true);
		Lambo.SetActiveRecursively(false);
		Lotus.SetActiveRecursively(false);
	}
	if(_CarSelectionGridInt==4) {
		Cata.SetActiveRecursively(false);
		F599.SetActiveRecursively(true);
		FCa.SetActiveRecursively(false);
		Lambo.SetActiveRecursively(false);
		Lotus.SetActiveRecursively(false);
	}

		
	}
}
