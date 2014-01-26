using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    public int id;
    public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
        GameManager.Instance.CheckPoints.Add(id, gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.CurrentCheckPoint < id)
            {
                print("Set checkpoint to: " + id);
                GameManager.Instance.CurrentCheckPoint = id;
            }
        }
    }

    public void Spawn()
    {
        GameObject go = Instantiate(playerPrefab, transform.position, Quaternion.identity) as GameObject;
        Camera.main.SendMessage("SetTarget", go);
    }
}
