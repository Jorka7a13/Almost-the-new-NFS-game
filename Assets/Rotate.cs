using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	float rotate;
	public float rotationSpeed;
	public static bool rotationActivated;
	
	// Use this for initialization
	void Start () {
		rotate = 0;
		rotationSpeed = 3;
		rotationActivated = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(rotationActivated) {
				rotate = Input.GetAxis("Horizontal") * rotationSpeed;	
				transform.Rotate(0, rotate, 0);
		}	
	}
}
