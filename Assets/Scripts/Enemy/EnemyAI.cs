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
    public Transform detectingPoint;
    public Transform weaponPoint;
    public float maxSpeed;
    public float moveRange = 1f;
//    public float attackRange = 1f;
    public float fireInterval = 1f;

    public float Range
    {
        get
        {
            return moveRange;
        }
        set
        {
            moveRange = value;
        }
    }

    private Vector3 initPosition;
    public float[] boundaries;
    public float currentSpeed;
    public Vector2 checkRect;
    public GameObject weaponPrefab;


    // Use this for initialization
    void Start()
    {
//      print("Start");
        player = GameObject.FindGameObjectWithTag("Player");

        initPosition = transform.position;

        boundaries [0] = initPosition.x - moveRange;
        boundaries [1] = initPosition.x + moveRange;

        currentSpeed = maxSpeed;

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

            yield return new WaitForEndOfFrame();
        }
    }

    void Idle()
    {

    }

    void Patrol()
    {
        Move();
        FindEnemy();
    }

    void Move()
    {
        transform.Translate(new Vector3(currentSpeed * Time.deltaTime, 0, 0));
        if (OutOfBound())
        {
            currentSpeed *= -1f;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 v = transform.localScale;
        v.x *= -1f;
        transform.localScale = v;
    }

    void FindEnemy()
    {
        if (EnemyIsInRange())
        {
            Fire();
        }
    }

    void Fire()
    {
        InvokeRepeating("ThrowWeapon", .1f, fireInterval);
        state = EnemyState.Attack;
    }

    void StopFire()
    {
        CancelInvoke("ThrowWeapon");
        state = EnemyState.Patrol;
    }

    void ThrowWeapon()
    {
        Instantiate(weaponPrefab, transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
    }

    bool EnemyIsInRange()
    {
//        if (player == null)
//            player = GameObject.FindGameObjectWithTag("Player");
//        if ((player.transform.position - transform.position).magnitude < attackRange)
//            return true;
//        return false;
//        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.transform.position, transform.right, attackRange);

        Vector2 v = new Vector2(detectingPoint.position.x, detectingPoint.position.y);
        print(v);

        Collider2D c2d = Physics2D.OverlapArea(v - checkRect, v + checkRect);

//        if(c2d.gameObject != null && c2d.tag == "Player")
        if (c2d != null && c2d.tag == "Player")
            return true;

        return false;
    }

    void Attack()
    {
        if (!EnemyIsInRange())
        {
            StopFire();
        }
    }

    void Die()
    {

    }

    bool OutOfBound()
    {
        if (transform.position.x < boundaries [0])
            return true;
        if (transform.position.x > boundaries [1])
            return true;
        return false;
    }

    void OnDrawGizmos()
    {
//        Gizmos.color = Color.gray;
//        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
//        Gizmos.DrawRay(raycastPoint.transform.position, transform.right);
        Gizmos.DrawWireCube(detectingPoint.position, new Vector3(2f * checkRect.x, 2f * checkRect.y, 0f));
    }
}
