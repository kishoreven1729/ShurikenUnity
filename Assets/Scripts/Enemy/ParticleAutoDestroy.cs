using UnityEngine;
using System.Collections;

public class ParticleAutoDestroy : MonoBehaviour {

    public float lifeSpan = 1f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
