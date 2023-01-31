using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDrone : MonoBehaviour
{

	Vector2 rotation = Vector2.zero;
	public float speed = 3; //the sensibility

	void Update()
	{
		rotation.y += Input.GetAxis("Mouse X");
		rotation.x += -Input.GetAxis("Mouse Y");
		transform.eulerAngles = (Vector2)rotation * speed;
	}
}
