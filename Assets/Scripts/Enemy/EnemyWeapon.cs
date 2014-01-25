using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {

    public float lifeSpan = 3f;

    public float rotateSpeed = 2f;

    public float speed = 1f;

    public int damage = 1;

    public Transform sprite;

    public GameObject explosionPrefab;


	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        sprite.RotateAround(Vector3.forward, rotateSpeed * Time.deltaTime);
	
	}

    void OnTriggerEnter2D(Collider2D other) {

        print(other.gameObject);
        if (other.tag == "Player")
        {
            other.gameObject.SendMessage("OnDamage", damage);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
