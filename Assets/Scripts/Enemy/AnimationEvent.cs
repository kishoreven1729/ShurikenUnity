using UnityEngine;
using System.Collections;

public class AnimationEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Destroy()
    {
        Destroy(gameObject);
    }
}
