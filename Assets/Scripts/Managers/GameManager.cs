using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
//    public GameObject[] checkPoints;
    public Dictionary<int, GameObject> checkPoints = new Dictionary<int, GameObject>();
    public int currentCheckPoint = 0;
    public bool isWin = false;

    public bool            _shurikenLaunched = false;

    public Dictionary<int, GameObject> CheckPoints
    {
        get
        {
            return checkPoints;
        }
        set
        {
            checkPoints = value;
        }
    }

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

    public void SpawnPlayerAtCheckPoint()
    {
        checkPoints[currentCheckPoint].SendMessage("Spawn");
    }

    public void Win()
    {
        if (!isWin)
        {
            print("win!");
            isWin = true;
        }
    }
}
