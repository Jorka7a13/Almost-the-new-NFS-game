using UnityEngine;
using System.Collections;

public class CarCamera : MonoBehaviour
{
	public Transform target = null;
	public Transform lotus = null;
	public Transform lambo = null;
	public Transform fca = null;
	public Transform f599 = null;
	
	public float height = 1f;
	public float positionDamping = 3f;
	public float velocityDamping = 3f;
	public float distance = 4f;
	public LayerMask ignoreLayers = -1;

	private RaycastHit hit = new RaycastHit();

	private Vector3 prevVelocity = Vector3.zero;
	private LayerMask raycastLayers = -1;
	
	private Vector3 currentVelocity = Vector3.zero;
	
	public static int _CarSelectionGridInt;
	
	void Start()
	{
		_CarSelectionGridInt=ChooseCar.CarSelectionGridInt;
		raycastLayers = ~ignoreLayers;
	}

	void FixedUpdate(){
	if(_CarSelectionGridInt==0){
	
		currentVelocity = Vector3.Lerp(prevVelocity, target.root.rigidbody.velocity, velocityDamping * Time.deltaTime);
		currentVelocity.y = 0;
		prevVelocity = currentVelocity;
	}
	
		if(_CarSelectionGridInt==1){
	
		currentVelocity = Vector3.Lerp(prevVelocity, lotus.root.rigidbody.velocity, velocityDamping * Time.deltaTime);
		currentVelocity.y = 0;
		prevVelocity = currentVelocity;
	}
	
		if(_CarSelectionGridInt==2){
	
		currentVelocity = Vector3.Lerp(prevVelocity, lambo.root.rigidbody.velocity, velocityDamping * Time.deltaTime);
		currentVelocity.y = 0;
		prevVelocity = currentVelocity;
	}
		if(_CarSelectionGridInt==3){
	
		currentVelocity = Vector3.Lerp(prevVelocity, fca.root.rigidbody.velocity, velocityDamping * Time.deltaTime);
		currentVelocity.y = 0;
		prevVelocity = currentVelocity;
	}
		if(_CarSelectionGridInt==4){
	
		currentVelocity = Vector3.Lerp(prevVelocity, f599.root.rigidbody.velocity, velocityDamping * Time.deltaTime);
		currentVelocity.y = 0;
		prevVelocity = currentVelocity;
	}

	}
	
	void LateUpdate()
	{
		
		if(_CarSelectionGridInt==0){
		float speedFactor = Mathf.Clamp01(target.root.rigidbody.velocity.magnitude / 70.0f);
		camera.fieldOfView = Mathf.Lerp(55, 72, speedFactor);
		float currentDistance = Mathf.Lerp(7.5f, 6.5f, speedFactor);
		
		currentVelocity = currentVelocity.normalized;
		
		Vector3 newTargetPosition = target.position + Vector3.up * height;
		Vector3 newPosition = newTargetPosition - (currentVelocity * currentDistance);
		newPosition.y = newTargetPosition.y;
			
		Vector3 targetDirection = newPosition - newTargetPosition;
		if(Physics.Raycast(newTargetPosition, targetDirection, out hit, currentDistance, raycastLayers))
			newPosition = hit.point;
		
		transform.position = newPosition;
		transform.LookAt(newTargetPosition);
		}
		
		if(_CarSelectionGridInt==1){
		float speedFactor = Mathf.Clamp01(lotus.root.rigidbody.velocity.magnitude / 70.0f);
		camera.fieldOfView = Mathf.Lerp(55, 72, speedFactor);
		float currentDistance = Mathf.Lerp(7.5f, 6.5f, speedFactor);
		
		currentVelocity = currentVelocity.normalized;
		
		Vector3 newTargetPosition = lotus.position + Vector3.up * height;
		Vector3 newPosition = newTargetPosition - (currentVelocity * currentDistance);
		newPosition.y = newTargetPosition.y;
					
		Vector3 targetDirection = newPosition - newTargetPosition;
		if(Physics.Raycast(newTargetPosition, targetDirection, out hit, currentDistance, raycastLayers))
			newPosition = hit.point;
		
		transform.position = newPosition;
		transform.LookAt(newTargetPosition);
		}
		
		if(_CarSelectionGridInt==2){
		float speedFactor = Mathf.Clamp01(lambo.root.rigidbody.velocity.magnitude / 70.0f);
		camera.fieldOfView = Mathf.Lerp(55, 72, speedFactor);
		float currentDistance = Mathf.Lerp(7.5f, 6.5f, speedFactor);
		
		currentVelocity = currentVelocity.normalized;
		
		Vector3 newTargetPosition = lambo.position + Vector3.up * height;
		Vector3 newPosition = newTargetPosition - (currentVelocity * currentDistance);
		newPosition.y = newTargetPosition.y;
					
		Vector3 targetDirection = newPosition - newTargetPosition;
		if(Physics.Raycast(newTargetPosition, targetDirection, out hit, currentDistance, raycastLayers))
			newPosition = hit.point;
		
		transform.position = newPosition;
		transform.LookAt(newTargetPosition);
		}
		
		
		if(_CarSelectionGridInt==3){
		float speedFactor = Mathf.Clamp01(fca.root.rigidbody.velocity.magnitude / 70.0f);
		camera.fieldOfView = Mathf.Lerp(55, 72, speedFactor);
		float currentDistance = Mathf.Lerp(7.5f, 6.5f, speedFactor);
		
		currentVelocity = currentVelocity.normalized;
		
		Vector3 newTargetPosition = fca.position + Vector3.up * height;
		Vector3 newPosition = newTargetPosition - (currentVelocity * currentDistance);
		newPosition.y = newTargetPosition.y;
			
		Vector3 targetDirection = newPosition - newTargetPosition;
			
		if(Physics.Raycast(newTargetPosition, targetDirection, out hit, currentDistance, raycastLayers))
			newPosition = hit.point;
		
		transform.position = newPosition;
		transform.LookAt(newTargetPosition);
		}
		
		if(_CarSelectionGridInt==4){
		float speedFactor = Mathf.Clamp01(f599.root.rigidbody.velocity.magnitude / 70.0f);
		camera.fieldOfView = Mathf.Lerp(55, 72, speedFactor);
		float currentDistance = Mathf.Lerp(7.5f, 6.5f, speedFactor);
		
		currentVelocity = currentVelocity.normalized;
		
		Vector3 newTargetPosition = f599.position + Vector3.up * height;
		Vector3 newPosition = newTargetPosition - (currentVelocity * currentDistance);
		newPosition.y = newTargetPosition.y;
			
		Vector3 targetDirection = newPosition - newTargetPosition;
		if(Physics.Raycast(newTargetPosition, targetDirection, out hit, currentDistance, raycastLayers))
			newPosition = hit.point;
		
		transform.position = newPosition;
		transform.LookAt(newTargetPosition);
		}

		

	
	}
}
