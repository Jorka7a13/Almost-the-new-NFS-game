var car1 : Car;
var car2 : Car;


function Start () { 
	car1.enabled = true;
	car2.enabled = false; 
}

function Update () {
	if (Input.GetKeyDown ("2")){ 
		car1.enabled = false;
		car2.enabled = true;
	} 
	if (Input.GetKeyDown ("1")){
		car1.enabled = true;
		car2.enabled = false; 
	}
	
	
}
