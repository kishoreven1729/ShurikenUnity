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
<<<<<<< HEAD
	public Transform	target;
=======
    public GameObject	target;
>>>>>>> 546c1415fb0a5867417863f9de0c91e547a8322d
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

<<<<<<< HEAD
		target = GameObject.FindGameObjectWithTag("Player").transform;
=======
        target = GameObject.FindGameObjectWithTag("Player");
>>>>>>> 546c1415fb0a5867417863f9de0c91e547a8322d
	}
	#endregion
	
	#region Loop
	void Update() 
	{
<<<<<<< HEAD
		if(target != null)
		{
			Vector3 cameraTargetPosition = target.position;
=======
        Vector3 cameraTargetPosition = target.transform.position;
>>>>>>> 546c1415fb0a5867417863f9de0c91e547a8322d

			Vector3 cameraPosition = transform.position;

			cameraTargetPosition.z = cameraPosition.z;

			cameraTargetPosition = Vector3.Slerp(cameraPosition, cameraTargetPosition, smooth * Time.deltaTime);

			transform.position = cameraTargetPosition;
		}
	}
	#endregion

	#region Methods
<<<<<<< HEAD
	public void ChangeTargetToShuriken()
	{
		target = GameObject.FindGameObjectWithTag("Shuriken").transform;
	}

	public void ChangeTargetToCharacter()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
=======

    public void SetTarget(GameObject g)
    {
        target = g;
    }

>>>>>>> 546c1415fb0a5867417863f9de0c91e547a8322d
	#endregion
}
