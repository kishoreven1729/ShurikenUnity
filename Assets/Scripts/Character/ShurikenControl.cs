#region References
using UnityEngine;
using System.Collections;
#endregion

public class ShurikenControl : MonoBehaviour 
{
	#region Private Variables
	
	private float		_shurikenDisappearanceTime;
    private Vector2     finalShurikenForce;
	#endregion

	#region Public Variables
	
	public float		shurikenForce;
    public float        _shurikenLifespan;
    public float        deflectForce = 10f;
    public float        angularVelocity = 300f;
	#endregion

	#region Constructor
	void Awake()
	{
//		_shurikenForce = new Vector2(750.0f, 350.0f);

//		_shurikenLifespan = 2.5f;

		_shurikenDisappearanceTime = -1.0f;
	}

	void Start() 
	{	
	}
	#endregion
	
	#region Loop
	void Update() 
	{
        rigidbody2D.angularVelocity = angularVelocity;

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
//		if(collision.collider.CompareTag("Ground"))
//		{
//			rigidbody2D.Sleep();
//
//			DestoryShuriken();
//		}

        if(collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Ground"))
        {
            Vector2 n = collision.contacts[0].normal;
            rigidbody2D.velocity = n * deflectForce;
            Debug.DrawRay(collision.transform.position, n * deflectForce);
            Destroy(gameObject, .5f);
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
        Vector2 shurikenShootingForce = direction * shurikenForce;

		rigidbody2D.AddForce(shurikenShootingForce);

		_shurikenDisappearanceTime = Time.time + _shurikenLifespan;
	}
	#endregion
}
