#region References
using UnityEngine;
using System.Collections;
#endregion

public class CharacterControl : MonoBehaviour 
{
	#region Enum
	public enum CharacterState
	{
		Idle,
		Run,
		Dash,
		Dead
	}
	#endregion

	#region Private Variables
	private Animator		_characterAnimator;

	private bool			_characterControlEnabled;

	private float			_dashTime;
	private float			_dashEndTime;

	private Transform		_thrownShuriken;
	private bool			_isShurikenThrown;
	private Transform		_shurikenSpawnPoint;

	
	private int				_maxCharacterHealth;
	#endregion

	#region Public Variables
	public float 			dashFactor;
	public float			movementSpeed;
	public Vector2			movementDirection;

	public CharacterState	currentCharacterState;

	public Transform		shurikenPrefab;

    public int             characterHealth;
	#endregion

	#region Constructor
	void Start() 
	{
		_characterAnimator = GetComponent<Animator>();

//		movementSpeed = 10.0f;
		movementDirection = Vector2.zero;

		currentCharacterState = CharacterState.Idle;
		CharacterIdle();

		/*Dash Parameters*/
		dashFactor = 2.0f;
		_dashTime = 0.3f;
		_dashEndTime = 0.0f;

		/*Shuriken Parameters*/
		_isShurikenThrown = false;
		_shurikenSpawnPoint = transform.Find("ShurikenSpawnPoint");

		/*Character Parameters*/
		_maxCharacterHealth = 3;
		characterHealth = _maxCharacterHealth;

		_characterControlEnabled = true;
	}
	#endregion
	
	#region Loop
	void Update()
	{
		if(currentCharacterState != CharacterState.Dead)
		{
			if(_isShurikenThrown == true)
			{
				if(_thrownShuriken != null)
				{
					if(Input.GetButtonDown("Fire2"))
					{
						transform.position = new Vector3(_thrownShuriken.position.x, _thrownShuriken.position.y, transform.position.z);

						if(currentCharacterState != CharacterState.Dash)
						{
							CharacterIdle();
						}

						_isShurikenThrown = false;

						_thrownShuriken.SendMessage("DestoryShuriken", SendMessageOptions.DontRequireReceiver);
					}
				}
				else
				{
					_isShurikenThrown = false;
				}
			}
		}

		if(_characterControlEnabled == true)
		{		
			movementDirection = Vector2.zero;
			currentCharacterState = CharacterState.Idle;

			if(Input.GetKey(KeyCode.D))
			{
				movementDirection.x = 1.0f;
				currentCharacterState = CharacterState.Run;
			}
			if(Input.GetKey(KeyCode.A))
			{
				movementDirection.x = -1.0f;
				currentCharacterState = CharacterState.Run;
			}

			if(Input.GetKey(KeyCode.LeftShift))
			{
				if(movementDirection != Vector2.zero)
				{
					_characterControlEnabled = false;

					_dashEndTime = Time.time + _dashTime;

					currentCharacterState = CharacterState.Dash;
				}
			}

			if(Input.GetButtonDown("Fire1"))
			{
				if(_thrownShuriken == null)
				{
					CharacterShoot();
				}
			}

			UpdateCharacterState();
		}
		else
		{
			switch(currentCharacterState)
			{
			case CharacterState.Dash:
				if(Time.time > _dashEndTime)
				{
					_characterControlEnabled = true;
				}
				break;
			case CharacterState.Dead:
                    print("I m dead!");
				break;
			}
		}
	}

    void OnCollisionEnter2D(Collision2D coll) {

        print(coll.gameObject);
        if (coll.gameObject.tag == "Enemy")
        {
            print("HitTheEnemy!!");
            coll.gameObject.SendMessage("OnDamage");
        }
        
    }

	#endregion

	#region Methods
	public void UpdateCharacterState()
	{
		switch(currentCharacterState)
		{
		case CharacterState.Idle:
			CharacterIdle();
			break;
		case CharacterState.Run:
			CharacterRun();
			break;
		case CharacterState.Dash:
			CharacterDash();
			break;
		case CharacterState.Dead:
			break;
		}
	}

	private void CharacterRun()
	{
		Vector3 velocity = movementDirection * movementSpeed;

		ResetParameters();

		_characterAnimator.SetBool("Run", true);

		rigidbody2D.velocity = velocity;

		transform.localScale = new Vector3(movementDirection.x, 1, 1);
	}

	private void CharacterIdle()
	{
		ResetParameters();
		
		_characterAnimator.SetBool("Idle", true);

		Vector2 characterVelocity = rigidbody2D.velocity;
		characterVelocity.x = 0.0f;

		rigidbody2D.velocity = characterVelocity;
	}

	private void CharacterDash()
	{
		Vector3 velocity = movementDirection * movementSpeed * dashFactor;

		ResetParameters();
		
		_characterAnimator.SetBool("Dash", true);
		
		rigidbody2D.velocity = velocity;

		transform.localScale = new Vector3(movementDirection.x, 1, 1);
	}

	private void CharacterDead()
	{
		ResetParameters();
		
		_characterAnimator.SetBool("Dead", true);
		
		rigidbody2D.Sleep();
	}

	private void CharacterShoot()
	{
		_isShurikenThrown = true;

		Vector2 character2DPosition = new Vector2(transform.position.x, transform.position.y);
		Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
		Vector2 mousePosition2D = new Vector2(mousePosition3D.x, mousePosition3D.y);


//		Debug.Log("Character2DPosition: " + character2DPosition);
//		Debug.Log("MousePosition: " + mousePosition2D);

		Vector2 shurikenDirection = mousePosition2D - character2DPosition;
		shurikenDirection.Normalize();

		if(shurikenDirection.x < 0.0f)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else
		{
			transform.localScale = new Vector3(1, 1, 1);
		}

		_thrownShuriken = Instantiate(shurikenPrefab, _shurikenSpawnPoint.position, Quaternion.identity) as Transform;
		_thrownShuriken.name = "Shuriken";

		_thrownShuriken.SendMessage("SetupShot", shurikenDirection, SendMessageOptions.DontRequireReceiver);
	}

	private void ResetParameters()
	{
		_characterAnimator.SetBool("Idle", false);
		_characterAnimator.SetBool("Run", false);
		_characterAnimator.SetBool("Dash", false);
		_characterAnimator.SetBool("Dead", false);
	}
	#endregion

	#region Public Methods
	public void OnDamage(int damage)
	{
		characterHealth--;

		if(characterHealth <= 0)
		{
			currentCharacterState = CharacterState.Dead;

            _characterControlEnabled = false;

			characterHealth = _maxCharacterHealth;
		}
	}
	#endregion
}
