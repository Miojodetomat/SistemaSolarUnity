using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SocialPlatforms;

public class LookAtTarget : MonoBehaviour {

	static public GameObject target; // the target that the camera should look at
	
	// Update is called once per frame
	void Update () {
		if (target)
		{
			double deltaZ = Camera.main.transform.position.z - target.transform.position.z;
			double deltaY = target.transform.position.y;
			double dist = Math.Sqrt(deltaZ*deltaZ + deltaY*deltaY);
			double radius = target.transform.localScale.x / 2;
			float cameraAngle = (float) Math.Atan(radius/dist) * 2;
			cameraAngle = (float) (cameraAngle * 180 / Math.PI);
			Camera.main.fieldOfView = cameraAngle*20/target.transform.localScale.x;
			transform.LookAt(target.transform);
		}
	}
}
