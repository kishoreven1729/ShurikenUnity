using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{

    public enum MoveType
    {
        Horizonal,
        Vertical
    }

    public MoveType type = MoveType.Horizonal;
    public float maxSpeed;
    public float currentSpeed;
    public float moveRange;
    public float[] boundaries;
    private Vector3 initPosition;

    // Use this for initialization
    void Start()
    {
        initPosition = transform.position;

        if (type == MoveType.Horizonal)
        {
            boundaries [0] = initPosition.x - moveRange;
            boundaries [1] = initPosition.x + moveRange;
        } else
        {
            boundaries [0] = initPosition.y - moveRange;
            boundaries [1] = initPosition.y + moveRange;
        }
        
        currentSpeed = maxSpeed;
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (type == MoveType.Horizonal)
        {
            transform.Translate(new Vector3(currentSpeed * Time.deltaTime, 0, 0));
        }
        else
        {
            transform.Translate(new Vector3(0, currentSpeed * Time.deltaTime, 0));
        }

        if (OutOfBound())
        {
            currentSpeed *= -1f;
        }
    }

    bool OutOfBound()
    {
        if (type == MoveType.Horizonal)
        {
            if (transform.position.x < boundaries [0])
                return true;
            if (transform.position.x > boundaries [1])
                return true;
            return false;
        }
        else
        {
            if (transform.position.y < boundaries [0])
                return true;
            if (transform.position.y > boundaries [1])
                return true;
            return false;
        }
    }
}
