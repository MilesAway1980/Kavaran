using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitWorld : MonoBehaviour {

	Map worldMap = null;

	// Use this for initialization
	void Start () {
		worldMap = gameObject.AddComponent<Map> ();
		MapReader.LoadMap (worldMap, "world.map");


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
