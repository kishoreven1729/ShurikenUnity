using UnityEngine;
using System.Collections;

public class EnemySpawnPoint : MonoBehaviour {

	public GameObject enemyPrefab;
	public float range;

	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn()
	{
		GameObject go = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
		go.GetComponent<EnemyAI>().Range = range;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.gray;
		Gizmos.DrawWireSphere(transform.position, range);
	}

}
