using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    public int id;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Set checkpoint to: " + id);
            GameManager.Instance.CurrentCheckPoint = id;
        }
    }
}
