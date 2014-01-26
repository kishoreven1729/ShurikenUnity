#region References
using UnityEngine;
using System.Collections;

#endregion

public class CharacterFollow : MonoBehaviour
{
    #region Private Variables
    private Vector2     _defaultCharacterPosition;

    private Vector2     _initialCameraPosition;
    #endregion

    #region Public Variables
    public Transform    target;
    public float        smooth;
    public static CharacterFollow characterFollowInstance;
    public float        yOffset;
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

        _initialCameraPosition = target.position;
        _initialCameraPosition.y += yOffset;
    }
    #endregion
    
    #region Loop
    void Update()
    {

        if (target != null)
        {
            Vector3 cameraTargetPosition = target.position;

            if(target.tag == "Player")
            {
                cameraTargetPosition.y += yOffset;
            }
       

            if(cameraTargetPosition.y < _initialCameraPosition.y)
            {
                cameraTargetPosition.y = _initialCameraPosition.y;
            }

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
