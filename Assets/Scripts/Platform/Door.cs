using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject[] switches;
    public float moveOffset = 1f;


	// Use this for initialization
	void Start () {

        for (int i = 0; i < switches.Length; i++)
        {
            switches[i].GetComponent<Switch>().door = gameObject;
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckCondition()
    {
        if (FitsCondition())
        {
            Open();
        }
    }

    bool FitsCondition()
    {
        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].GetComponent<Switch>().state == Switch.SwitchState.Off)
                return false;
        }
        return true;
    }

    void Open ()
    {
        print("Open");
        transform.Translate(new Vector3(0f, moveOffset, 0f));
    }

}
