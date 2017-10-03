using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalGameControllerPersonal : MonoBehaviour {

	public Text displayScore;
	int bronzePoints;
	int silverPoints;
	int goldPoints;
	int kryptonitePoints;
	int score;

	int bronzeSupply;
	int silverSupply;
	int goldSupply;
	int kryptoniteSupply;

	public int spawnSpeed;
	int spawnTime;
	int lastSpawn;

	float bronzeXPosition;
	float silverXPosition;
	float goldXPosition;
	float kryptoniteXPosition;

	public GameObject oreCube;
	GameObject bronzeCube;
	GameObject silverCube;
	GameObject goldCube;
	GameObject kryptoniteCube;


	// I wanted the silver cubes to spawn below the bronze cubes, created separate positions to "refresh" cube position for silver spawning.
	Vector3 bronzeCubePosition;
	Vector3 silverCubePosition;
	Vector3 goldCubePosition;
	Vector3 kryptoniteCubePosition;



	// Use this for initialization
	void Start () {
		bronzePoints = 1;
		silverPoints = 10;
		goldPoints = 100;
		kryptonitePoints = 1000;

		bronzeSupply = 0;
		silverSupply = 0;
		goldSupply = 0;
		kryptoniteSupply = 0;

		spawnSpeed = 3;
		spawnTime = 1;


		bronzeCubePosition = new Vector3 (-8f,-3f,0f);
		silverCubePosition = new Vector3 (-8f,-1f,0f);
		goldCubePosition = new Vector3 (-8f,1f,0f);
		kryptoniteCubePosition = new Vector3 (-8f, 3f, 0f);

	
	}

	// Update is called once per frame
	void Update () {
		// Need a way to keep track of what type of ore was last spawned
		// Need a way to keep track of what type of ore each new oreCube is
		// Need a way to click on cubes to mine them, add points to a total score, and display how much the cube added
		// Need a way to indicate that cubes are clickable
		// Need to display count up timer
		// Need to change the cube once it is mined (I would like to have it move to the side)


		if (Time.time > spawnTime) {
			//I wonder if there is a way of saying "or" or if I need to create 3 seperate if statements for dif krypt spawn req??
			//I asked Sabrina and found out that || is "or" 
			if (kryptoniteSupply < 2 && (goldSupply >= 1 || silverSupply >= 1) 
				&& (goldSupply == silverSupply || goldSupply == silverSupply + kryptoniteSupply || silverSupply == goldSupply + kryptoniteSupply)
				&& (lastSpawn == 1 || lastSpawn == 2 || lastSpawn == 3)) {
				kryptoniteSupply += 1;

				kryptoniteCubePosition += new Vector3 (kryptoniteXPosition, 0f, 0f);
				kryptoniteCube = (GameObject)Instantiate (oreCube, kryptoniteCubePosition, Quaternion.identity);
				kryptoniteXPosition = 2;

				kryptoniteCube.GetComponent<Renderer> ().material.color = Color.green;

				lastSpawn = 4;
			}
			// trying to figure out a way to stipulate that the last cube spawned needs to be either silver or bronze
			// could just stipulate that goldSupply == 0, but I want to be able to spawn more than one gold in total, just right after one another
		

			else if (bronzeSupply == 2 && silverSupply == 2 && (lastSpawn == 1 || lastSpawn == 2)) {
				goldSupply += 1;

				goldCubePosition += new Vector3 (goldXPosition, 0f, 0f);
				goldCube = (GameObject)Instantiate (oreCube, goldCubePosition, Quaternion.identity);
				goldXPosition = 2;

				goldCube.GetComponent<Renderer> ().material.color = Color.yellow;

				lastSpawn = 3;
			}

			else if (bronzeSupply < 4) {
				bronzeSupply += 1;

				bronzeCubePosition += new Vector3 (bronzeXPosition, 0f, 0f);
				bronzeCube = (GameObject) Instantiate (oreCube, bronzeCubePosition, Quaternion.identity);
				bronzeXPosition = 2;

				bronzeCube.GetComponent<Renderer> ().material.color = Color.red;

				lastSpawn = 1;
			}
				

			else if (bronzeSupply >= 4) {
				silverSupply += 1;

				silverCubePosition += new Vector3 (silverXPosition, 0f, 0f);
				silverCube = (GameObject) Instantiate (oreCube, silverCubePosition, Quaternion.identity);
				silverXPosition = 2;

				silverCube.GetComponent<Renderer> ().material.color = Color.white;

				lastSpawn = 2;
			}

		
			spawnTime += spawnSpeed;
		}


	}
}
