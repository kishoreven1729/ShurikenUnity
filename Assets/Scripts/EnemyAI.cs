using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    public enum EnemyState
    {
        Idle,
        Patrol,
        Attack,
        Die
    }

    public EnemyState state;
    public GameObject player;
    public float speed;
    public float acceleration;
    public float range;
    private Vector3 initPosition;
    public float[] boundaries;
    private float currentSpeed;
    private float targetSpeed;


    // Use this for initialization
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player");
        initPosition = transform.position;
        boundaries [0] = initPosition.x - range;
        boundaries [1] = initPosition.y + range;

        StartCoroutine("CheckState");
    }


    IEnumerator CheckState()
    {
        while (true)
        {

            switch (state)
            {
                case EnemyState.Idle:
                    break;
                case EnemyState.Patrol:
                    Patrol();
                    break;
                case EnemyState.Attack:
                    break;
                case EnemyState.Die:
                    break;
            }


        }
    }

    void Idle()
    {

    }

    void Patrol()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        transform.Translate(new Vector3(currentSpeed, 0, 0));
    }

    void Attack()
    {

    }

    void Die()
    {

    }


}
