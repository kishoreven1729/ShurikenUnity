﻿#region References
using UnityEngine;
using System.Collections;
#endregion

public class CharacterFollow : MonoBehaviour 
{
	#region Private Variables
	private Vector2		_defaultCharacterPosition;
	#endregion

	#region Public Variables
    public GameObject	target;
	public float		smooth;
	#endregion

	#region Constructor
	void Start() 
	{
		_defaultCharacterPosition = Vector2.zero;

        target = GameObject.FindGameObjectWithTag("Player");
	}
	#endregion
	
	#region Loop
	void Update() 
	{
        Vector3 cameraTargetPosition = target.transform.position;

		Vector3 cameraPosition = transform.position;

		cameraTargetPosition.z = cameraPosition.z;

		cameraTargetPosition = Vector3.Slerp(cameraPosition, cameraTargetPosition, smooth * Time.deltaTime);

		transform.position = cameraTargetPosition;
	}
	#endregion

	#region Methods

    public void SetTarget(GameObject g)
    {
        target = g;
    }

	#endregion
}
