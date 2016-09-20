using UnityEngine;
using System.Collections;



public class RotateCamera : MonoBehaviour {
public Transform target;
	
	
void Update() {
transform.LookAt(target);
	
	
}
}