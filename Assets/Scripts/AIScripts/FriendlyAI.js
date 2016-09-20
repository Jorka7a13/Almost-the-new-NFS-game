private var wheelRadius : float = 0.4;
var suspensionRange : float = 0.1;
var suspensionDamper : float = 50;
var suspensionSpringFront : float = 18500;
var suspensionSpringRear : float = 9000;

public var brakeLights : Material;

var dragMultiplier : Vector3 = new Vector3(2, 5, 1);

private var throttle : float = 0; 
private var steer : float = 0;
private var handbrake : boolean = false;

private var steerValue : float = 0;
private var steerSign : int = 0;
private var steerAngle : float = 0;
private var missWaypointAngle : float = 0;

// Variables for the laps
private var currentLap : int = 0;
var laps : int = 0;
var finishedTheRace : boolean = false;

// Variables for the raycast
private var raycastStartPos : Vector3;
private var raycastY : float;
var hitFront : RaycastHit;
var hitRight1 : RaycastHit;
var hitRight2 : RaycastHit;
var hitRight3 : RaycastHit;
var hitRight4 : RaycastHit;
var hitLeft1 : RaycastHit;
var hitLeft2 : RaycastHit;
var hitLeft3 : RaycastHit;
var hitLeft4 : RaycastHit;

var carBody : Transform;

// Game objects showing where the rays point
var raycastFront : GameObject;
var raycastLeft1 : GameObject;
var raycastLeft2 : GameObject;
var raycastLeft3 : GameObject;
var raycastLeft4 : GameObject;
var raycastRight1 : GameObject;
var raycastRight2 : GameObject;
var raycastRight3 : GameObject;
var raycastRight4 : GameObject;

//If raycast detects a car
private var directionToTarget : Vector3;
private var newTarget : Collider;
private var foundACar : boolean = false;
private var targetsVelocityMagnitude : float;
private var targetsVelocity : Vector3;
private var distanceToCar : float = 0;
private var velocityDifference : float = 0; //Between the AI and the player
private var partOfVelocityDifference : float = 0;
private var idOfRay : int = 0; //Which ray is hit
private var calculatedSpeed : float = 0; //The speed of the AI after the calculation about the player
private var isSpeedCalculated : boolean = false; //Semafor, if the speed has been calculated, don't apply throttle 

var centerOfMass : Transform;

var frontWheels : Transform[];
var rearWheels : Transform[];

private var wheels : Wheel[];
wheels = new Wheel[frontWheels.Length + rearWheels.Length];

private var wfc : WheelFrictionCurve;

var topSpeed : float = 200;
var numberOfGears : int = 5;

var maximumTurn : int = 15;
var minimumTurn : int = 10;

var resetTime : float = 5.0;
private var resetTimer : float = 0.0;

private var engineForceValues : float[];
private var gearSpeeds : float[];

private var currentGear : int;
private var currentEnginePower : float = 0.0;

private var handbrakeXDragFactor : float = 0.5;
private var initialDragMultiplierX : float = 10.0;
private var handbrakeTime : float = 0.0;
private var handbrakeTimer : float = 1.0;

private var skidmarks : Skidmarks = null;
private var skidSmoke : ParticleEmitter = null;
var skidmarkTime : float[];

private var sound : SoundController = null;
sound = transform.GetComponent(SoundController);

private var canSteer : boolean;
private var canDrive : boolean;

var waypoints : Array;
private var currentWaypoint : int;

function Start()
{	
	// Measuring 1 - 60
	accelerationTimer = Time.time;
	
	SetupWheelColliders();
	
	SetupCenterOfMass();
	
	topSpeed = Convert_Miles_Per_Hour_To_Meters_Per_Second(topSpeed);
	
	SetupGears();
	
	SetUpSkidmarks();
	
	initialDragMultiplierX = dragMultiplier.x;

}

function Update()
{		
	var relativeVelocity : Vector3 = transform.InverseTransformDirection(rigidbody.velocity);
	
	Check_If_Car_Is_Flipped();
	
	UpdateWheelGraphics(relativeVelocity);
	
	UpdateGear(relativeVelocity);
}

function FixedUpdate()
{	
	// The rigidbody velocity is always given in world space, but in order to work in local space of the car model we need to transform it first.
	var relativeVelocity : Vector3 = transform.InverseTransformDirection(rigidbody.velocity);
	
	CalculateState();	
	
	UpdateFriction(relativeVelocity);
	
	UpdateDrag(relativeVelocity);
	
	CalculateEnginePower(relativeVelocity);	

	loadWaypoints();
	
	createRaycast(relativeVelocity);	

	followWaypoints(waypoints, relativeVelocity, laps);
	
}

function loadWaypoints() {
	
	var waypointFixedArray = GameObject.FindGameObjectsWithTag("Waypoint"); // Get the waypoints by tag
		
	waypoints = new Array(waypointFixedArray);

	waypoints.Reverse();

	if(waypoints[0].name == "Waypoint105NotUsed") { // Checks if the waypoints are loaded in incorrect order
		waypoints.Reverse();	 // Fixes this
	}
	
}

function createRaycast(relativeVelocity : Vector3) {
	
	raycastY = carBody.position.y; 
	raycastY += 1; // Put the starting point of the raycast a little bit higher
	
	raycastStartPos = Vector3(carBody.position.x, raycastY, carBody.position.z); // Initialize the starting point of the raycast
	
	Debug.DrawRay(raycastStartPos, (raycastFront.transform.position - raycastStartPos) * 3, Color.green); // Display the front ray in the editor		
    if(Physics.Raycast(raycastStartPos, (raycastFront.transform.position - raycastStartPos), hitFront, 15)) { // Makes the actual ray
		if(hitFront.collider.gameObject.tag == "Player") { // If there is a car infront 
			foundACar = true;
			RunAwayFromCar(hitFront);
			idOfRay = 0;
		} else {
			foundACar = false;
		}
	
		if(hitFront.collider.gameObject.tag == "Fence" && hitFront.distance < 4) { // If the car hits the fence 
			carHitTheFence(hitFront, relativeVelocity);
		}
	}
	
	Debug.DrawRay(raycastStartPos, (raycastRight1.transform.position - raycastStartPos) * 2, Color.green); // Display the right1 ray in the editor
	if(Physics.Raycast(raycastStartPos, (raycastRight1.transform.position - raycastStartPos), hitRight1, 11)) {
		if(hitRight1.collider.gameObject.tag == "Player") { // If there is a car slightly to the right
			foundACar = true;
			RunAwayFromCar(hitRight1);
			idOfRay = 1;
		} else {
			foundACar = false;
		}		 
	}
	
	Debug.DrawRay(raycastStartPos, (raycastRight2.transform.position - raycastStartPos) * 2, Color.green); // Display the right2 ray in the editor
	if(Physics.Raycast(raycastStartPos, (raycastRight2.transform.position - raycastStartPos), hitRight2, 9)) {
		if(hitRight2.collider.gameObject.tag == "Player") { // If there is a car more to the right
			foundACar = true;
			RunAwayFromCar(hitRight2);
			idOfRay = 2;
		} else {
			foundACar = false;
		}			 
	}
	
	Debug.DrawRay(raycastStartPos, (raycastRight3.transform.position - raycastStartPos) * 2, Color.green); // Display the right3 ray in the editor
	if(Physics.Raycast(raycastStartPos, (raycastRight3.transform.position - raycastStartPos), hitRight3, 7)) {
		if(hitRight3.collider.gameObject.tag == "Player") { // If there is a car to the right
			foundACar = true;
			RunAwayFromCar(hitRight3);
			idOfRay = 3;
		} else {
			foundACar = false;
		}		 
	}	
		
	Debug.DrawRay(raycastStartPos, (raycastRight4.transform.position - raycastStartPos) * 2, Color.green); // Display the right4 ray in the editor
	if(Physics.Raycast(raycastStartPos, (raycastRight4.transform.position - raycastStartPos), hitRight4, 7)) {
		if(hitRight4.collider.gameObject.tag == "Player") { // If there is a car to the left
			foundACar = true;
			RunAwayFromCar(hitRight4);
			idOfRay = 4;
		} else {
			foundACar = false;
		}		 
	} 
	
	Debug.DrawRay(raycastStartPos, (raycastLeft1.transform.position - raycastStartPos) * 2, Color.green); // Display the left1 ray in the editor
	if(Physics.Raycast(raycastStartPos, (raycastLeft1.transform.position - raycastStartPos), hitLeft1, 11)) {
		if(hitLeft1.collider.gameObject.tag == "Player") { // If there is a car slightly to the left
			foundACar = true;
			RunAwayFromCar(hitLeft1);
			idOfRay = 1;
		} else {
			foundACar = false;
		}		 
	}
	
	Debug.DrawRay(raycastStartPos, (raycastLeft2.transform.position - raycastStartPos) * 2, Color.green); // Display the left2 ray in the editor
	if(Physics.Raycast(raycastStartPos, (raycastLeft2.transform.position - raycastStartPos), hitLeft2, 8)) {
		if(hitLeft2.collider.gameObject.tag == "Player") { // If there is a car more to the left
			foundACar = true;
			RunAwayFromCar(hitLeft2);
			idOfRay = 2;
		} else {
			foundACar = false;
		}		 
	}
	
	Debug.DrawRay(raycastStartPos, (raycastLeft3.transform.position - raycastStartPos) * 2, Color.green); // Display the left3 ray in the editor
	if(Physics.Raycast(raycastStartPos, (raycastLeft3.transform.position - raycastStartPos), hitLeft3, 6)) {
		if(hitLeft3.collider.gameObject.tag == "Player") { // If there is a car to the left
			foundACar = true;
			RunAwayFromCar(hitLeft3);
			idOfRay = 3;
		} else {
			foundACar = false;
		}		 
	}
	
	Debug.DrawRay(raycastStartPos, (raycastLeft4.transform.position - raycastStartPos) * 2, Color.green); // Display the left4 ray in the editor
	if(Physics.Raycast(raycastStartPos, (raycastLeft4.transform.position - raycastStartPos), hitLeft4, 7)) {
		if(hitLeft4.collider.gameObject.tag == "Player") { // If there is a car to the left
			foundACar = true;
			RunAwayFromCar(hitLeft4);
			idOfRay = 4;
		} else {
			foundACar = false;
		}		 
	}

}

function RunAwayFromCar(hit : RaycastHit) {
	newTarget = hit.collider;
	directionToTarget = newTarget.transform.position - transform.position;
	targetsVelocity = newTarget.transform.parent.rigidbody.velocity; // Get the rigidbody of the parent of the body, a.k.a. the game objects rigidbody
	targetsVelocityMagnitude = targetsVelocity.magnitude;
	distanceToCar = hit.distance;
}

function followWaypoints(waypoint : Array, relativeVelocity : Vector3, laps : int) {

	if(currentWaypoint < waypoint.length) { // Iterate trough the waypoints
		var target : Vector3 = waypoint[currentWaypoint].transform.position;
		var moveDirection : Vector3 = target - transform.position;
		
		var hitFront : RaycastHit;
		
		if(moveDirection.magnitude < 6) { // If the AI is close to the waypoint, change to the next one

			currentWaypoint++;
			
			steerAngle = 0;
				
		} else { // Get close to waypoint
		
			if(foundACar) { //If raycast detects a car
				
				steerAngle = Vector3.Angle(transform.right, directionToTarget);  // Get the turn angle
				
				if(steerAngle > 90) { 
				
					steerAngle -= 90;
					steerSign = 1; // The turn is on the left, but the AI has to go to the opposite direction					
					steerValue = steerAngle / 100; // Convert it to a digit between -1.0 and 1.0
					
				} else {
					steerSign = -1; // The turn is on the right, but the AI has to go to the opposite direction					
					steerValue = steerAngle / 100; // Convert it to a digit between -1.0 and 1.0
				}
				
				steer = steerValue * steerSign;	
				
				if(moveDirection.z == transform.forward) { // If the target is infront of the AI
					steerValue = 0;
				}	
				
				//Correct the speed of the AI

				if(targetsVelocityMagnitude < transform.rigidbody.velocity.magnitude) { // If the AI is faster than the player
				//	transform.rigidbody.velocity = targetsVelocity;  
				
					velocityDifference = transform.rigidbody.velocity.magnitude - targetsVelocityMagnitude; // The difference in the speed of both the player and the AI
					partOfVelocityDifference = velocityDifference/4; // 4, because that's the number of the raycast rays on one of the sides of the car
					
					if(idOfRay == 1) { // If the player at a specific angle to the AI
						calculatedSpeed = transform.rigidbody.velocity.magnitude + partOfVelocityDifference;
					} else if(idOfRay == 2) {
						calculatedSpeed = transform.rigidbody.velocity.magnitude + partOfVelocityDifference*2;
					} else if(idOfRay == 3) {
						calculatedSpeed = transform.rigidbody.velocity.magnitude + partOfVelocityDifference*3;
					} else if(idOfRay == 4) {
						calculatedSpeed = transform.rigidbody.velocity.magnitude + partOfVelocityDifference*4;
					}
					
					isSpeedCalculated = true;
				
				} else {
					
					velocityDifference = transform.rigidbody.velocity.magnitude - targetsVelocityMagnitude; // The difference in the speed of both the player and the AI
					partOfVelocityDifference = velocityDifference/4; // 4, because that's the number of the raycast rays on one of the sides of the car
					
					if(idOfRay == 1) { // If the player at a specific angle to the AI
						calculatedSpeed = transform.rigidbody.velocity.magnitude - partOfVelocityDifference; // Calculate the speed of the AI depending on the angle it is coming to the player.
					} else if(idOfRay == 2) {
						calculatedSpeed = transform.rigidbody.velocity.magnitude - partOfVelocityDifference*2;
					} else if(idOfRay == 3) {
						calculatedSpeed = transform.rigidbody.velocity.magnitude - partOfVelocityDifference*3;
					} else if(idOfRay == 4) {
						calculatedSpeed = transform.rigidbody.velocity.magnitude - partOfVelocityDifference*4;
					}
					
					isSpeedCalculated = true;
					
				} 
				
			} else { // If there is no car around, continue on the waypoints

				steerAngle = Vector3.Angle(transform.right, moveDirection);  // Get the turn angle
			
				if(steerAngle > 90) { 
				
					steerAngle -= 90;
					steerSign = -1; // The turn is on the left					
					steerValue = steerAngle / 100; // Convert it to a digit between 0 and 1.0
					
				} else {
					steerSign = 1; // The turn is on the right					
					steerValue = steerAngle / 100; // Convert it to a digit between 0 and 1.0
				}
				
				steer = steerValue * steerSign;	// Myltiply by the sign of the digit so it get between -1.0 and 1.0								
				
				// The places, where the AI has to slow down
				if(currentLap == 0) { // If the car is on the first lap
					if((transform.rigidbody.velocity.magnitude > 12) && ((currentWaypoint == 6)  || (currentWaypoint == 8) || (currentWaypoint == 12) || (currentWaypoint == 16) || 
					(currentWaypoint == 20)	|| (currentWaypoint == 24)	|| (currentWaypoint == 28) || (currentWaypoint == 31) || 
					(currentWaypoint == 33) || (currentWaypoint == 36) || (currentWaypoint == 39) ||	(currentWaypoint == 43) || (currentWaypoint == 47) || 
					(currentWaypoint == 50) || (currentWaypoint == 53) || (currentWaypoint == 55) || (currentWaypoint == 58) || (currentWaypoint == 61) || 
					(currentWaypoint == 70) || (currentWaypoint == 76) || (currentWaypoint == 82) || (currentWaypoint == 84) || (currentWaypoint == 85) || (currentWaypoint == 88) || 
					(currentWaypoint == 93) || (currentWaypoint == 94))) {
						SlowDown();
					} else {		
						SpeedUp(); // If the car doesn't need to slow down, then speed up
					}
				} else { // If the car is not on the first lap
					if((transform.rigidbody.velocity.magnitude > 12) && ((currentWaypoint == 6)  || (currentWaypoint == 8) || (currentWaypoint == 10) || (currentWaypoint == 12) ||
					(currentWaypoint == 14) || (currentWaypoint == 16) || (currentWaypoint == 20)|| (currentWaypoint == 24) || (currentWaypoint == 28) || (currentWaypoint == 31) || 
					(currentWaypoint == 33) || (currentWaypoint == 36) || (currentWaypoint == 39) ||	(currentWaypoint == 43) || (currentWaypoint == 47) || 
					(currentWaypoint == 50) || (currentWaypoint == 53) || (currentWaypoint == 55) || (currentWaypoint == 58) || (currentWaypoint == 61) || 
					(currentWaypoint == 70) || (currentWaypoint == 76) || (currentWaypoint == 82) || (currentWaypoint == 84) || (currentWaypoint == 85) || (currentWaypoint == 88) || 
					(currentWaypoint == 93) || (currentWaypoint == 94))) {
						SlowDown();
					} else {		
						SpeedUp(); // If the car doesn't need to slow down, then speed up
					}
				}
			
			}

			if(!isSpeedCalculated) {
				ApplyThrottle(true, relativeVelocity);
			} else {
				transform.rigidbody.AddRelativeForce(Vector3.forward * calculatedSpeed);
			}
			
			ApplySteering(true, relativeVelocity);
			
			checkIfMissedWaypoint(moveDirection, waypoints);	

			if(waypoint[currentWaypoint].name == "Waypoint104") { // If the AI reaches the end of the lap
				currentWaypoint = 0;
				currentLap++;
			} else if(waypoint[currentWaypoint].name == "Waypoint104" && currentLap == laps) { // The race is over
				finishedTheRace = true;
			}
			
		}		
	} 
}

function carHitTheFence(hit : RaycastHit, relativeVelocity : Vector3) {
	
	if(hit.distance < 8) {
		goInReverse(relativeVelocity);
	}	
}

function checkIfMissedWaypoint(vector : Vector3, waypoint : Array) {

	if(currentWaypoint < waypoint.length) {
 		var nextWaypointPosition : Vector3 = waypoint[currentWaypoint+1].transform.position; // Get the vector from the car to the next waypoint
		var probableMoveDirection : Vector3 = nextWaypointPosition - transform.position; // Get the vector from the car to the current waypoint
		
		missWaypointAngle = Vector3.Angle(probableMoveDirection, vector); 
		
		if(missWaypointAngle >= 70) {
			currentWaypoint++;
		}
	}
}

//Some utility functions

function SlowDown() { 
	throttle = -1;		
	brakeLights.SetFloat("_Intensity", 0.2);	
}

function SpeedUp() {
	throttle = 1;		
	brakeLights.SetFloat("_Intensity", 0.0);
}

function fullStop() {
	rigidbody.velocity = Vector3.zero;
}

function goInReverse(relativeVelocity : Vector3) {
	throttle = -1;
	ApplyThrottle(true, relativeVelocity);
}

/**************************************************/
/* Functions called from Start()                  */
/**************************************************/

function SetupWheelColliders()
{
	SetupWheelFrictionCurve();
		
	var wheelCount : int = 0;
	
	for (var t : Transform in frontWheels)
	{
		wheels[wheelCount] = SetupWheel(t, true);
		wheelCount++;
	}
	
	for (var t : Transform in rearWheels)
	{
		wheels[wheelCount] = SetupWheel(t, false);
		wheelCount++;
	}
}

function SetupWheelFrictionCurve()
{
	wfc = new WheelFrictionCurve();
	wfc.extremumSlip = 1;
	wfc.extremumValue = 50;
	wfc.asymptoteSlip = 2;
	wfc.asymptoteValue = 25;
	wfc.stiffness = 1;
}

function SetupWheel(wheelTransform : Transform, isFrontWheel : boolean)
{
	var go : GameObject = new GameObject(wheelTransform.name + " Collider");
	go.transform.position = wheelTransform.position;
	go.transform.parent = transform;
	go.transform.rotation = wheelTransform.rotation;
		
	var wc : WheelCollider = go.AddComponent(typeof(WheelCollider)) as WheelCollider;
	wc.suspensionDistance = suspensionRange;
	var js : JointSpring = wc.suspensionSpring;
	
	if (isFrontWheel)
		js.spring = suspensionSpringFront;
	else
		js.spring = suspensionSpringRear;
		
	js.damper = suspensionDamper;
	wc.suspensionSpring = js;
		
	wheel = new Wheel(); 
	wheel.collider = wc;
	wc.sidewaysFriction = wfc;
	wheel.wheelGraphic = wheelTransform;
	wheel.tireGraphic = wheelTransform.GetComponentsInChildren(Transform)[1];
	
	wheelRadius = wheel.tireGraphic.renderer.bounds.size.y / 2;	
	wheel.collider.radius = wheelRadius;
	
	if (isFrontWheel)
	{
		wheel.steerWheel = true;
		
		go = new GameObject(wheelTransform.name + " Steer Column");
		go.transform.position = wheelTransform.position;
		go.transform.rotation = wheelTransform.rotation;
		go.transform.parent = transform;
		wheelTransform.parent = go.transform;
	}
	else
		wheel.driveWheel = true;
		
	return wheel;
}

function SetupCenterOfMass()
{
	if(centerOfMass != null)
		rigidbody.centerOfMass = centerOfMass.localPosition;
}

function SetupGears()
{
	engineForceValues = new float[numberOfGears];
	gearSpeeds = new float[numberOfGears];
	
	var tempTopSpeed : float = topSpeed;
		
	for(var i = 0; i < numberOfGears; i++)
	{
		if(i > 0)
			gearSpeeds[i] = tempTopSpeed / 4 + gearSpeeds[i-1];
		else
			gearSpeeds[i] = tempTopSpeed / 4;
		
		tempTopSpeed -= tempTopSpeed / 4;
	}
	
	var engineFactor : float = topSpeed / gearSpeeds[gearSpeeds.Length - 1];
	
	for(i = 0; i < numberOfGears; i++)
	{
		var maxLinearDrag : float = gearSpeeds[i] * gearSpeeds[i];// * dragMultiplier.z;
		engineForceValues[i] = maxLinearDrag * engineFactor;
	}
}

function SetUpSkidmarks()
{
	if(FindObjectOfType(Skidmarks))
	{
		skidmarks = FindObjectOfType(Skidmarks);
		skidSmoke = skidmarks.GetComponentInChildren(ParticleEmitter);
	}
	else
		Debug.Log("No skidmarks object found. Skidmarks will not be drawn");
		
	skidmarkTime = new float[4];
	for (var f : float in skidmarkTime)
		f = 0.0;
}

/**************************************************/
/* Functions called from Update()                 */
/**************************************************/

function CheckHandbrake()
{
		if(!handbrake)
		{
			handbrake = true;
			handbrakeTime = Time.time;
			dragMultiplier.x = initialDragMultiplierX * handbrakeXDragFactor;
		} else if(handbrake) 
		{
		handbrake = false;
		StartCoroutine(StopHandbraking(Mathf.Min(5, Time.time - handbrakeTime)));
	}
}

function StopHandbraking(seconds : float)
{
	var diff : float = initialDragMultiplierX - dragMultiplier.x;
	handbrakeTimer = 1;
	
	// Get the x value of the dragMultiplier back to its initial value in the specified time.
	while(dragMultiplier.x < initialDragMultiplierX && !handbrake)
	{
		dragMultiplier.x += diff * (Time.deltaTime / seconds);
		handbrakeTimer -= Time.deltaTime / seconds;
		yield;
	}
	
	dragMultiplier.x = initialDragMultiplierX;
	handbrakeTimer = 0;
}

function Check_If_Car_Is_Flipped()
{
	if(transform.localEulerAngles.z > 80 && transform.localEulerAngles.z < 280)
		resetTimer += Time.deltaTime;
	else
		resetTimer = 0;
	
	if(resetTimer > resetTime)
		FlipCar();
}

function FlipCar()
{
	transform.rotation = Quaternion.LookRotation(transform.forward);
	transform.position += Vector3.up * 0.5;
	rigidbody.velocity = Vector3.zero;
	rigidbody.angularVelocity = Vector3.zero;
	resetTimer = 0;
	currentEnginePower = 0;
}

var wheelCount : float;
function UpdateWheelGraphics(relativeVelocity : Vector3)
{
	wheelCount = -1;
	
	for(var w : Wheel in wheels)
	{
		wheelCount++;
		var wheel : WheelCollider = w.collider;
		var wh : WheelHit = new WheelHit();
		
		// First we get the velocity at the point where the wheel meets the ground, if the wheel is touching the ground
		if(wheel.GetGroundHit(wh))
		{
			w.wheelGraphic.localPosition = wheel.transform.up * (wheelRadius + wheel.transform.InverseTransformPoint(wh.point).y);
			w.wheelVelo = rigidbody.GetPointVelocity(wh.point);
			w.groundSpeed = w.wheelGraphic.InverseTransformDirection(w.wheelVelo);
			
			// Code to handle skidmark drawing. Not covered in the tutorial
			if(skidmarks)
			{
				if(skidmarkTime[wheelCount] < 0.02 && w.lastSkidmark != -1)
				{
					skidmarkTime[wheelCount] += Time.deltaTime;
				}
				else
				{
					var dt : float = skidmarkTime[wheelCount] == 0.0 ? Time.deltaTime : skidmarkTime[wheelCount];
					skidmarkTime[wheelCount] = 0.0;

					var handbrakeSkidding : float = handbrake && w.driveWheel ? w.wheelVelo.magnitude * 0.3 : 0;
					var skidGroundSpeed = Mathf.Abs(w.groundSpeed.x) - 15;
					if(skidGroundSpeed > 0 || handbrakeSkidding > 0)
					{
						var staticVel : Vector3 = transform.TransformDirection(skidSmoke.localVelocity) + skidSmoke.worldVelocity;
						if(w.lastSkidmark != -1)
						{
							var emission : float = UnityEngine.Random.Range(skidSmoke.minEmission, skidSmoke.maxEmission);
							var lastParticleCount : float = w.lastEmitTime * emission;
							var currentParticleCount : float = Time.time * emission;
							var noOfParticles : int = Mathf.CeilToInt(currentParticleCount) - Mathf.CeilToInt(lastParticleCount);
							var lastParticle : int = Mathf.CeilToInt(lastParticleCount);
							
							for(var i = 0; i <= noOfParticles; i++)
							{
								var particleTime : float = Mathf.InverseLerp(lastParticleCount, currentParticleCount, lastParticle + i);
								skidSmoke.Emit(	Vector3.Lerp(w.lastEmitPosition, wh.point, particleTime) + new Vector3(Random.Range(-0.1, 0.1), Random.Range(-0.1, 0.1), Random.Range(-0.1, 0.1)), staticVel + (w.wheelVelo * 0.05), Random.Range(skidSmoke.minSize, skidSmoke.maxSize) * Mathf.Clamp(skidGroundSpeed * 0.1,0.5,1), Random.Range(skidSmoke.minEnergy, skidSmoke.maxEnergy), Color.white);
							}
						}
						else
						{
							skidSmoke.Emit(	wh.point + new Vector3(Random.Range(-0.1, 0.1), Random.Range(-0.1, 0.1), Random.Range(-0.1, 0.1)), staticVel + (w.wheelVelo * 0.05), Random.Range(skidSmoke.minSize, skidSmoke.maxSize) * Mathf.Clamp(skidGroundSpeed * 0.1,0.5,1), Random.Range(skidSmoke.minEnergy, skidSmoke.maxEnergy), Color.white);
						}
					
						w.lastEmitPosition = wh.point;
						w.lastEmitTime = Time.time;
					
						w.lastSkidmark = skidmarks.AddSkidMark(wh.point + rigidbody.velocity * dt, wh.normal, (skidGroundSpeed * 0.1 + handbrakeSkidding) * Mathf.Clamp01(wh.force / wheel.suspensionSpring.spring), w.lastSkidmark);
						//sound.Skid(true, Mathf.Clamp01(skidGroundSpeed * 0.1));
					}
					else
					{
						w.lastSkidmark = -1;
						//sound.Skid(false, 0);
					}
				}
			}
		}
		else
		{
			// If the wheel is not touching the ground we set the position of the wheel graphics to
			// the wheel's transform position + the range of the suspension.
			w.wheelGraphic.position = wheel.transform.position + (-wheel.transform.up * suspensionRange);
			if(w.steerWheel)
				w.wheelVelo *= 0.9;
			else
				w.wheelVelo *= 0.9 * (1 - throttle);
			
			if(skidmarks)
			{
				w.lastSkidmark = -1;
				//sound.Skid(false, 0);
			}
		}
		// If the wheel is a steer wheel we apply two rotations:
		// *Rotation around the Steer Column (visualizes the steer direction)
		// *Rotation that visualizes the speed
		if(w.steerWheel)
		{
			var ea : Vector3 = w.wheelGraphic.parent.localEulerAngles;
			ea.y = steer * maximumTurn;
			w.wheelGraphic.parent.localEulerAngles = ea;
			w.tireGraphic.Rotate(Vector3.right * (w.groundSpeed.z / wheelRadius) * Time.deltaTime * Mathf.Rad2Deg);
		}
		else if(!handbrake && w.driveWheel)
		{
			// If the wheel is a drive wheel it only gets the rotation that visualizes speed.
			// If we are hand braking we don't rotate it.
			w.tireGraphic.Rotate(Vector3.right * (w.groundSpeed.z / wheelRadius) * Time.deltaTime * Mathf.Rad2Deg);
		}
	}
}

function UpdateGear(relativeVelocity : Vector3)
{
	currentGear = 0;
	for(var i = 0; i < numberOfGears - 1; i++)
	{
		if(relativeVelocity.z > gearSpeeds[i])
			currentGear = i + 1;
	}
}

/**************************************************/
/* Functions called from FixedUpdate()            */
/**************************************************/

function UpdateDrag(relativeVelocity : Vector3)
{
	var relativeDrag : Vector3 = new Vector3(	-relativeVelocity.x * Mathf.Abs(relativeVelocity.x), 
												-relativeVelocity.y * Mathf.Abs(relativeVelocity.y), 
												-relativeVelocity.z * Mathf.Abs(relativeVelocity.z) );
	
	var drag = Vector3.Scale(dragMultiplier, relativeDrag);
		
	if(initialDragMultiplierX > dragMultiplier.x) // Handbrake code
	{			
		drag.x /= (relativeVelocity.magnitude / (topSpeed / ( 1 + 2 * handbrakeXDragFactor ) ) );
		drag.z *= (1 + Mathf.Abs(Vector3.Dot(rigidbody.velocity.normalized, transform.forward)));
		drag += rigidbody.velocity * Mathf.Clamp01(rigidbody.velocity.magnitude / topSpeed);
	}
	else // No handbrake
	{
		drag.x *= topSpeed / relativeVelocity.magnitude;
	}
	
	if(Mathf.Abs(relativeVelocity.x) < 5 && !handbrake)
		drag.x = -relativeVelocity.x * dragMultiplier.x;
		

	rigidbody.AddForce(transform.TransformDirection(drag) * rigidbody.mass * Time.deltaTime);
}

function UpdateFriction(relativeVelocity : Vector3)
{
	var sqrVel : float = relativeVelocity.x * relativeVelocity.x;
	
	// Add extra sideways friction based on the car's turning velocity to avoid slipping
	wfc.extremumValue = Mathf.Clamp(300 - sqrVel, 0, 300);
	wfc.asymptoteValue = Mathf.Clamp(150 - (sqrVel / 2), 0, 150);
		
	for(var w : Wheel in wheels)
	{
		w.collider.sidewaysFriction = wfc;
		w.collider.forwardFriction = wfc;
	}
}

function CalculateEnginePower(relativeVelocity : Vector3)
{
	if(throttle == 0)
	{
		currentEnginePower -= Time.deltaTime * 200;
	}
	else if( HaveTheSameSign(relativeVelocity.z, throttle) )
	{
		normPower = (currentEnginePower / engineForceValues[engineForceValues.Length - 1]) * 2;
		currentEnginePower += Time.deltaTime * 200 * EvaluateNormPower(normPower);
	}
	else
	{
		currentEnginePower -= Time.deltaTime * 300;
	}
	
	if(currentGear == 0)
		currentEnginePower = Mathf.Clamp(currentEnginePower, 0, engineForceValues[0]);
	else
		currentEnginePower = Mathf.Clamp(currentEnginePower, engineForceValues[currentGear - 1], engineForceValues[currentGear]);
}

function CalculateState()
{
	canDrive = false;
	canSteer = false;
	
	for(var w : Wheel in wheels)
	{
		if(w.collider.isGrounded)
		{
			if(w.steerWheel)
				canSteer = true;
			if(w.driveWheel)
				canDrive = true;
		}
	}
}

function ApplyThrottle(canDrive : boolean, relativeVelocity : Vector3)
{
	if(canDrive)
	{
		var throttleForce : float = 0;
		var brakeForce : float = 0;
		
		if (HaveTheSameSign(relativeVelocity.z, throttle)) 
		{
			if (!handbrake)
				throttleForce = Mathf.Sign(throttle) * currentEnginePower * rigidbody.mass;
		}
		else
			brakeForce = Mathf.Sign(throttle) * engineForceValues[0] * rigidbody.mass;
		
		rigidbody.AddForce(transform.forward * Time.deltaTime * (throttleForce + brakeForce));
	}
}

function ApplySteering(canSteer : boolean, relativeVelocity : Vector3)
{
	if(canSteer)
	{
		var turnRadius : float = 3.0 / Mathf.Sin((90 - (steer * 30)) * Mathf.Deg2Rad);
		var minMaxTurn : float = EvaluateSpeedToTurn(rigidbody.velocity.magnitude);
		var turnSpeed : float = Mathf.Clamp(relativeVelocity.z / turnRadius, -minMaxTurn / 10, minMaxTurn / 10);
		
		transform.RotateAround(transform.position + transform.right * turnRadius * steer, 
								transform.up, 
								turnSpeed * Mathf.Rad2Deg * Time.deltaTime * steer);
		
		var debugStartPoint = transform.position + transform.right * turnRadius * steer;
		var debugEndPoint = debugStartPoint + Vector3.up * 5;
		
		Debug.DrawLine(debugStartPoint, debugEndPoint, Color.red);
		
		if(initialDragMultiplierX > dragMultiplier.x) // Handbrake
		{
			var rotationDirection : float = Mathf.Sign(steer); // rotationDirection is -1 or 1 by default, depending on steering
			if(steer == 0)
			{
				if(rigidbody.angularVelocity.y < 1) // If we are not steering and we are handbraking and not rotating fast, we apply a random rotationDirection
					rotationDirection = Random.Range(-1.0, 1.0);
				else
					rotationDirection = rigidbody.angularVelocity.y; // If we are rotating fast we are applying that rotation to the car
			}
			// -- Finally we apply this rotation around a point between the cars front wheels.
			transform.RotateAround( transform.TransformPoint( (	frontWheels[0].localPosition + frontWheels[1].localPosition) * 0.5), 
																transform.up, 
																rigidbody.velocity.magnitude * Mathf.Clamp01(1 - rigidbody.velocity.magnitude / topSpeed) * rotationDirection * Time.deltaTime * 2);
		}
	}
}

/**************************************************/
/*               Utility Functions                */
/**************************************************/

function Convert_Miles_Per_Hour_To_Meters_Per_Second(value : float) : float
{
	return value * 0.44704;
}

function Convert_Meters_Per_Second_To_Miles_Per_Hour(value : float) : float
{
	return value * 2.23693629;	
}

function HaveTheSameSign(first : float, second : float) : boolean
{
	if (Mathf.Sign(first) == Mathf.Sign(second))
		return true;
	else
		return false;
}

function EvaluateSpeedToTurn(speed : float)
{
	if(speed > topSpeed / 2)
		return minimumTurn;
	
	var speedIndex : float = 1 - (speed / (topSpeed / 2));
	return minimumTurn + speedIndex * (maximumTurn - minimumTurn);
}

function EvaluateNormPower(normPower : float)
{
	if(normPower < 1)
		return 10 - normPower * 9;
	else
		return 1.9 - normPower * 0.9;
}

function GetGearState()
{
	var relativeVelocity : Vector3 = transform.InverseTransformDirection(rigidbody.velocity);
	var lowLimit : float = (currentGear == 0 ? 0 : gearSpeeds[currentGear-1]);
	return (relativeVelocity.z - lowLimit) / (gearSpeeds[currentGear - lowLimit]) * (1 - currentGear * 0.1) + currentGear * 0.1;
}