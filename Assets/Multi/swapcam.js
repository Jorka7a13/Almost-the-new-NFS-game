var camera1 : Camera;
var camera2 : Camera;


function Start () { 
	camera1.enabled = true;
	camera2.enabled = false; 
}

function Update () {
	if (Input.GetKeyDown ("2")){ 
		camera1.enabled = false;
		camera2.enabled = true;
	} 
	if (Input.GetKeyDown ("1")){
		camera1.enabled = true;
		camera2.enabled = false; 
	}
	
	
}
