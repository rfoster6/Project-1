using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("The Game Has Begun!");

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 3) {
			print ("It Has Been Three Seconds!");
		}
	}
}
