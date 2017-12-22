using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{
	public Vector3 startAngle, endAngle, currentAngle;
	public Vector3 startPosition, endPosition;
	public Transform[] views;
	private Transform previousView;
	public float transitionSpeed; 

	float startTime, totalDistance;
	public float duration = 3.0f;
	public bool repeatable = false;

	Transform currentView;
	private Transform cameraPoint;

	private GameObject camera;

	void Start(){
		camera = Camera.main.gameObject;
		cameraPoint = gameObject.transform.Find ("Cam Point").transform;
		camera.transform.position = cameraPoint.position;
		currentAngle = camera.transform.rotation.eulerAngles;
		//camera.transform.eulerAngles = cameraPoint.rotation.eulerAngles;
	}



	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag.Equals ("Player")) {
			currentAngle = camera.transform.rotation.eulerAngles;
			currentView = cameraPoint;
			startAngle = currentAngle;
			endAngle = cameraPoint.transform.rotation.eulerAngles;
			StartCoroutine (MoveCamera1 (camera.transform.position, cameraPoint.position, 2.0f));


		}
		//Debug.Log ("test");	
	}

	IEnumerator MoveCamera1(Vector3 startPos, Vector3 endPos, float time){
		float i = 0.0f;
		float rate = (1.0f / time) * transitionSpeed;
		while (i < 1.0f) {
			//Debug.Log ("Test " + i);
			i += Time.deltaTime * rate;
			camera.transform.position = Vector3.Lerp(startPos, endPos, i);
			camera.transform.eulerAngles = Vector3.Lerp(startAngle,endAngle , i);
			yield return null;
		}

	}


}

