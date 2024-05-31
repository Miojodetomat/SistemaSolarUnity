using UnityEngine;
using System;

public class RotateAround : MonoBehaviour {

	public Transform target; // the object to rotate around
	public float speed; // the speed of rotation (if translational=Kepler's Third Law Constant)
	public bool isSynchronous;
	private Vector3 axis;
	
	void Start() {
		if (target == null) 
		{
			target = this.gameObject.transform;
			Debug.Log ("RotateAround target not specified. Defaulting to parent GameObject");
		}
		else
		if(!target.Equals(this.transform))
		{
			double deltaY = target.transform.position.y - this.transform.position.y;
			double deltaX = target.transform.position.x - this.transform.position.x;
			double deltaZ = target.transform.position.z - this.transform.position.z;
			if(deltaX != 0)
			{
				//set the axis of the vector perpendicular to the orbit's plane
				//y-axis positive
				double orbitPlaneAngle = Math.Atan(deltaY/deltaX);
				axis = new Vector3((float)Math.Sin(orbitPlaneAngle)*(-1), (float)Math.Cos(orbitPlaneAngle), 0);
			}
			else
			{
				if(target.transform.up.x > 0)
					axis = Vector3.right;
				else
					axis = Vector3.left;
			}

			//Euclidian Distance
			double orbitRadius = Math.Sqrt(deltaX*deltaX + deltaY*deltaY + deltaZ*deltaZ);
			//3rd Kepler's Law when K=speed
			speed = (float) (2*Math.PI/Math.Sqrt(orbitRadius*orbitRadius*orbitRadius)) * speed;
		}
		else
		{
			isSynchronous = true;
			axis = target.transform.up;
		}
	}

	// Update is called once per frame
	void Update () {
		// RotateAround takes three arguments, first is the Vector to rotate around
		// second is a vector that axis to rotate around
		// third is the degrees to rotate, in this case the speed per second
		transform.RotateAround(target.transform.position,axis,speed * Time.deltaTime);
		if(!isSynchronous) //if the orbit is not tidally locked
			transform.RotateAround(this.transform.position,axis,speed*(-1)*Time.deltaTime);
	}
}
