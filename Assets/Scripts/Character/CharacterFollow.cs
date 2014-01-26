#region References
using UnityEngine;
using System.Collections;
#endregion

public class CharacterFollow : MonoBehaviour 
{
	#region Private Variables
	private Vector2		_defaultCharacterPosition;
	#endregion

	#region Public Variables
	public Transform	target;
	public float		smooth;
	public static CharacterFollow characterFollowInstance;
	#endregion

	#region Constructor
	void Awake()
	{
		characterFollowInstance = this;
	}
	         
	void Start() 
	{
		_defaultCharacterPosition = Vector2.zero;

		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	#endregion
	
	#region Loop
	void Update() 
	{
		if(target != null)
		{
			Vector3 cameraTargetPosition = target.position;

			Vector3 cameraPosition = transform.position;

			cameraTargetPosition.z = cameraPosition.z;

			cameraTargetPosition = Vector3.Slerp(cameraPosition, cameraTargetPosition, smooth * Time.deltaTime);

			transform.position = cameraTargetPosition;
		}
	}
	#endregion

	#region Methods
	public void ChangeTargetToShuriken()
	{
		target = GameObject.FindGameObjectWithTag("Shuriken").transform;
	}

	public void ChangeTargetToCharacter()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	#endregion
}
