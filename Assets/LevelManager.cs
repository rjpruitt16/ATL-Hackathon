using UnityEngine;
using System;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public GameObject[] levels;
    Boolean playerInMiddle;
    float wCap;

	// Use this for initialization
	void Start () {
        levels = GameObject.FindGameObjectsWithTag("Stage");

	
	}

    public static void clampW(Vector3 position, float min, float max)
    {
        if (position.x < min) position.x = min;
        else if (position.x > max) position.x = max;
    } 
	
    // Update is called once per frame
    void Update () {
	
	}
}
