using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2GameControllerClass : MonoBehaviour {
	public int bronzePlayer;
	int silverPlayer;
	int miningSpeed;
	int bronzeSupply;
	int silverSupply;
	int timeToMine;
	float xPosition;

	public GameObject oreCube;
	Vector3 cubePosition;
	GameObject currentCube;



	// Use this for initialization
	void Start () {
		bronzePlayer = 0;
		silverPlayer = 0;
		bronzeSupply = 3;
		silverSupply = 2;

		miningSpeed = 3;
		timeToMine = 1;

		xPosition = 0f;


	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > timeToMine) {
			//mine some ore and update how many ore the player has
			//only mine bronze if we have at least 1 in the supply
			if (bronzeSupply >= 1) {
				bronzeSupply -= 1;
				bronzePlayer += 1;

				cubePosition += new Vector3 (xPosition, 0f, 0f);
				currentCube = (GameObject) Instantiate (oreCube, cubePosition, Quaternion.identity);
				xPosition = 2;

				currentCube.GetComponent<Renderer> ().material.color = Color.red;
			}


			//only mine silver if there is no bronze supply and we have at least one silver
			else if (bronzeSupply == 0 && silverSupply > 0) {
				silverSupply -= 1;
				silverPlayer += 1;
			}
			
			//make sure we wait another miningSpeed seconds before mining again

			print ("Bronze: "+bronzePlayer + "... Silver: "+silverPlayer);


			timeToMine += miningSpeed;


	}
}
}
