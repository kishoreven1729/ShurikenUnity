#region References
using UnityEngine;
using System.Collections;
#endregion

public class ShurikenControl : MonoBehaviour 
{
	#region Private Variables
	private float		_shurikenForce;
	#endregion

	#region Public Variables
	#endregion

	#region Constructor
	void Awake()
	{
		_shurikenForce = 750.0f;
	}

	void Start() 
	{	
	}
	#endregion
	
	#region Loop
	void Update() 
	{	
	}

	void OnCollision2DEnter(Collision2D collision)
	{
		Debug.Log("Coillision Detected");

		if(collision.collider.CompareTag("Ground"))
		{
			Debug.Log("Collision Detected");

			rigidbody2D.Sleep();

			DestoryShuriken();
		}
	}                      
	#endregion

	#region Methods
	public void DestoryShuriken()
	{
		Destroy(transform.gameObject);
	}

	public void SetupShot(Vector2 direction)
	{
		rigidbody2D.AddForce(direction * _shurikenForce);
	}
	#endregion
}
