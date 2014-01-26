using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public GameObject[] checkPoints;
    public int currentCheckPoint = 0;

    public int CurrentCheckPoint
    {
        get
        {
            return currentCheckPoint;
        }
        set
        {
            currentCheckPoint = value;
        }
    }

    void Awake ()
    {
        if (Instance != null && Instance != this) {
            Destroy (gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad (gameObject);
        }
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
