using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    public int id;
    public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("Set checkpoint to: " + id);
            GameManager.Instance.CurrentCheckPoint = id;
        }
    }

    public void Spawn()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
