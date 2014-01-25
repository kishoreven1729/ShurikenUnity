#region References
using UnityEngine;
using System.Collections;
#endregion

public class ShurikenControl : MonoBehaviour 
{
	#region Private Variables
	private float		_shurikenLifespan;
	private float		_shurikenDisappearanceTime;
	#endregion

	#region Public Variables
	public Vector2		finalShurikenForce;
	public Vector2		_shurikenForce;
	#endregion

	#region Constructor
	void Awake()
	{
		_shurikenForce = new Vector2(750.0f, 350.0f);

		_shurikenLifespan = 2.5f;

		_shurikenDisappearanceTime = -1.0f;
	}

	void Start() 
	{	
	}
	#endregion
	
	#region Loop
	void Update() 
	{
		if(_shurikenDisappearanceTime > 0.0f)
		{
			if(Time.time > _shurikenDisappearanceTime)
			{
				DestoryShuriken();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag("Ground"))
		{
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
		Vector2 shurikenShootingForce = new Vector2(direction.x * _shurikenForce.x, direction.y * _shurikenForce.y);

		rigidbody2D.AddForce(shurikenShootingForce);

		_shurikenDisappearanceTime = Time.time + _shurikenLifespan;
	}
	#endregion
}
