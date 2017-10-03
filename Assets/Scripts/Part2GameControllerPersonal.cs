using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2GameControllerPersonal : MonoBehaviour {

	int playerBronze;
	int playerSilver;

	int bronzeSupply;
	int silverSupply;

	int miningSpeed;
	int mineTime;

	float bronzeXPosition;
	float silverXPosition;

	public GameObject oreCube;
	GameObject currentCube;

	// I wanted the silver cubes to spawn below the bronze cubes, created separate positions to "refresh" cube position for silver spawning.
	Vector3 bronzeCubePosition;
	Vector3 silverCubePosition;




	// Use this for initialization
	void Start () {
		playerBronze = 0;
		playerSilver = 0;

		bronzeSupply = 3;
		silverSupply = 2;

		miningSpeed = 3;
		mineTime = 1;

		bronzeXPosition = 0f;
		silverXPosition = 0f;

		//creating separate cube positions solved my refreshing problem, this states that the silver cubes will spawn below the bronze cubes
		silverCubePosition += new Vector3 (0f, 2f, 0f);
	}
	
	// Update is called once per frame
	void Update () {



		if (Time.time > mineTime) {
			
			if (bronzeSupply >= 1) {
				bronzeSupply -= 1;
				playerBronze += 1;

				bronzeCubePosition += new Vector3 (bronzeXPosition, 0f, 0f);
				currentCube = (GameObject) Instantiate (oreCube, bronzeCubePosition, Quaternion.identity);
				bronzeXPosition = 2;

				currentCube.GetComponent<Renderer> ().material.color = Color.red;
			}
			else if (bronzeSupply == 0 && silverSupply >= 1) {
				silverSupply -= 1;
				playerSilver += 1;

				silverCubePosition += new Vector3 (silverXPosition, 0f, 0f);
				currentCube = (GameObject) Instantiate (oreCube, silverCubePosition, Quaternion.identity);
				silverXPosition = 2;

				currentCube.GetComponent<Renderer> ().material.color = Color.white;
			}
		
			print ("Bronze: " + playerBronze + "... Silver: " + playerSilver);
			mineTime += miningSpeed;
		}


	}
}
