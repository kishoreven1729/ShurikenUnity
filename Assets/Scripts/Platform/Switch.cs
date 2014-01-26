using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    public enum SwitchState
    {
        On,
        Off
    }

    public Sprite switchOn;
    private SpriteRenderer sr;
    public SwitchState state = SwitchState.Off;
    public GameObject door;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player")
        {
            if(state == SwitchState.Off)
            {
            sr.sprite = switchOn;
            state = SwitchState.On;
            door.SendMessage("CheckCondition");
            }
        }
    }

}
