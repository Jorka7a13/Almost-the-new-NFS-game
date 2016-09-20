

var target : Transform;
var distance = 7.0;
var height = 1.75;
var smoothLag = 0;
var maxSpeed = 900000;
var snapLag = 0;
var clampHeadPositionScreenSpace = 0.75;
var lineOfSightMask : LayerMask = 0;
var headOffset = Vector3.zero;
var centerOffset = Vector3.zero;

private var isSnapping = false;
private var velocity = Vector3.zero;
private var targetHeight = 100000.0;

function Apply (dummyTarget : Transform, dummyCenter : Vector3)
{	
	var targetCenter = target.position + centerOffset;
	var targetHead = target.position + headOffset;

	targetHeight = targetCenter.y + height;


	if (Input.GetButton("Fire2") && !isSnapping)
	{
		velocity = Vector3.zero;
		isSnapping = true;
	}

	if (isSnapping)
	{
		ApplySnapping (targetCenter);
	}
	else
	{
		ApplyPositionDamping (Vector3(targetCenter.x, targetHeight, targetCenter.z));
	}
	
	SetUpRotation(targetCenter, targetHead);
}


function LateUpdate ()
{
	if (target)
		Apply (null, Vector3.zero);	
}

function ApplySnapping (targetCenter : Vector3)
{
	var position = transform.position;
	var offset = position - targetCenter;
	offset.y = 0;
	var currentDistance = offset.magnitude;

	var targetAngle = target.eulerAngles.y;
	var currentAngle = transform.eulerAngles.y;

	currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, velocity.x, snapLag);
	currentDistance = Mathf.SmoothDamp(currentDistance, distance, velocity.z, snapLag);

	var newPosition = targetCenter;
	newPosition += Quaternion.Euler(0, currentAngle, 0) * Vector3.back * currentDistance;

	newPosition.y = Mathf.SmoothDamp (position.y, targetCenter.y + height, velocity.y, smoothLag, maxSpeed);

	newPosition = AdjustLineOfSight(newPosition, targetCenter);
	
	transform.position = newPosition;
	
	// We are close to the target, so we can stop snapping now!
	if (AngleDistance (currentAngle, targetAngle) < 3.0)
	{
		isSnapping = false;
		velocity = Vector3.zero;
	}
}

function AdjustLineOfSight (newPosition : Vector3, target : Vector3)
{
	var hit : RaycastHit;
	if (Physics.Linecast (target, newPosition, hit, lineOfSightMask.value))
	{
		velocity = Vector3.zero;
		return hit.point;
	}
	return newPosition;
}

function ApplyPositionDamping (targetCenter : Vector3)
{
	// We try to maintain a constant distance on the x-z plane with a spring.
	// Y position is handled with a seperate spring
	var position = transform.position;
	var offset = position - targetCenter;
	offset.y = 0;
	var newTargetPos = offset.normalized * distance + targetCenter;
	
	var newPosition : Vector3;
	newPosition.x = Mathf.SmoothDamp (position.x, newTargetPos.x, velocity.x, smoothLag, maxSpeed);
	newPosition.z = Mathf.SmoothDamp (position.z, newTargetPos.z, velocity.z, smoothLag, maxSpeed);
	newPosition.y = Mathf.SmoothDamp (position.y, targetCenter.y, velocity.y, smoothLag, maxSpeed);
	
	newPosition = AdjustLineOfSight(newPosition, targetCenter);
	
	transform.position = newPosition;
}

function SetUpRotation (centerPos : Vector3, headPos : Vector3)
{

	var cameraPos = transform.position;
	var offsetToCenter = centerPos - cameraPos;
	

	var yRotation = Quaternion.LookRotation(Vector3(offsetToCenter.x, 0, offsetToCenter.z));

	var relativeOffset = Vector3.forward * distance + Vector3.down * height;
	transform.rotation = yRotation * Quaternion.LookRotation(relativeOffset);

	
	var centerRay = camera.ViewportPointToRay(Vector3(.5, 0.5, 1));
	var topRay = camera.ViewportPointToRay(Vector3(.5, clampHeadPositionScreenSpace, 1));

	var centerRayPos = centerRay.GetPoint(distance);
	var topRayPos = topRay.GetPoint(distance);
	
	var centerToTopAngle = Vector3.Angle(centerRay.direction, topRay.direction);
	
	var heightToAngle = centerToTopAngle / (centerRayPos.y - topRayPos.y);

	var extraLookAngle = heightToAngle * (centerRayPos.y - centerPos.y);
	if (extraLookAngle < centerToTopAngle)
	{
		extraLookAngle = 0;
	}
	else
	{
		extraLookAngle = extraLookAngle - centerToTopAngle;
		transform.rotation *= Quaternion.Euler(-extraLookAngle, 0, 0);
	}
}

function AngleDistance (a : float, b : float)
{
	a = Mathf.Repeat(a, 360);
	b = Mathf.Repeat(b, 360);
	
	return Mathf.Abs(b - a);
}

function GetCenterOffset ()
{
	return centerOffset;
}

function SetTarget (t : Transform)
{
	target = t;
}

@script AddComponentMenu ("Third Person Camera/Spring Follow Camera")