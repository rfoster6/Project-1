using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalGameControllerPersonal : MonoBehaviour {
	
	//"public static" before variables to allow other scripts to access them


	public static int bronzeSupply;
	public static int silverSupply;
	public static int goldSupply;
	public static int kryptoniteSupply;

	public int spawnSpeed;
	int spawnTime;
	public static OreType lastSpawn;

	float bronzeXPosition;
	float silverXPosition;
	float goldXPosition;
	float kryptoniteXPosition;

	public GameObject oreCube;
	GameObject bronzeCube;
	GameObject silverCube;
	GameObject goldCube;
	GameObject kryptoniteCube;

	public Text displayScore;
	public static int score;


	public Text timerText;
	float seconds;
	float minutes;
	float hours;


			

	// I wanted the silver cubes to spawn above the bronze cubes, created separate positions to "refresh" cube position for silver spawning.
	Vector3 bronzeCubePosition;
	Vector3 silverCubePosition;
	Vector3 goldCubePosition;
	Vector3 kryptoniteCubePosition;



	// Use this for initialization
	void Start () {
		

		bronzeSupply = 0;
		silverSupply = 0;
		goldSupply = 0;
		kryptoniteSupply = 0;

		spawnSpeed = 3;
		spawnTime = 1;

		SetTimerText ();

		bronzeCubePosition = new Vector3 (-8f, -3f, 0f);
		silverCubePosition = new Vector3 (-8f, -1f, 0f);
		goldCubePosition = new Vector3 (-8f, 1f, 0f);
		kryptoniteCubePosition = new Vector3 (-8f, 3f, 0f);

		displayScore.text = "Score:" + score;

	
	}
		

	void SetTimerText (){
		timerText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
	}
		

	void Update () {
		// Update is called once per frame
		// Need a way to keep track of what type of ore each new oreCube is
		// Need a way to click on cubes to mine them, add points to a total score, and display how much the cube added
		// Need a way to indicate that cubes are clickable
		// Need to display count up timer
		// Need to change the cube once it is mined


		if (Time.time > spawnTime) {
			//I wonder if there is a way of saying "or" or if I need to create 3 seperate if statements for dif krypt spawn req??
			//I asked Sabrina and found out that || is "or" 
			if (kryptoniteSupply < 2 && (goldSupply >= 1 || silverSupply >= 1)
			    && (goldSupply == silverSupply || goldSupply == silverSupply + kryptoniteSupply || silverSupply == goldSupply + kryptoniteSupply)
			    && lastSpawn != OreType.kryptonite) {
				kryptoniteSupply += 1;

				kryptoniteCubePosition += new Vector3 (kryptoniteXPosition, 0f, 0f);
				kryptoniteCube = (GameObject)Instantiate (oreCube, kryptoniteCubePosition, Quaternion.identity);
				kryptoniteXPosition = 2;


				kryptoniteCube.GetComponent<Renderer> ().material.color = Color.green;
				kryptoniteCube.GetComponent<CubeBehaviour> ().oreType = OreType.kryptonite;

				lastSpawn = OreType.kryptonite;

			}
			// trying to figure out a way to stipulate that the last cube spawned needs to be either silver or bronze
			// could just stipulate that goldSupply == 0, but I want to be able to spawn more than one gold in total, just right after one another
		

			else if (bronzeSupply == 2 && silverSupply == 2 && lastSpawn != OreType.gold) {
				goldSupply += 1;

				goldCubePosition += new Vector3 (goldXPosition, 0f, 0f);
				goldCube = (GameObject)Instantiate (oreCube, goldCubePosition, Quaternion.identity);
				goldXPosition = 2;


				goldCube.GetComponent<Renderer> ().material.color = Color.yellow;
				goldCube.GetComponent<CubeBehaviour> ().oreType = OreType.gold;

				lastSpawn = OreType.gold;


			} else if (bronzeSupply < 4) {
				bronzeSupply += 1;

				bronzeCubePosition += new Vector3 (bronzeXPosition, 0f, 0f);
				bronzeCube = (GameObject)Instantiate (oreCube, bronzeCubePosition, Quaternion.identity);
				bronzeXPosition = 2;


				bronzeCube.GetComponent<Renderer> ().material.color = Color.red;
				bronzeCube.GetComponent<CubeBehaviour> ().oreType = OreType.bronze;


				lastSpawn = OreType.bronze;
			} else if (bronzeSupply >= 4) {
				silverSupply += 1;

				silverCubePosition += new Vector3 (silverXPosition, 0f, 0f);
				silverCube = (GameObject)Instantiate (oreCube, silverCubePosition, Quaternion.identity);
				silverXPosition = 2;

				silverCube.GetComponent<Renderer> ().material.color = Color.white;
				silverCube.GetComponent<CubeBehaviour> ().oreType = OreType.silver;

				lastSpawn = OreType.silver;
			}

			print ("Score:" + score);
			print ("SpawnSpeed:" + spawnSpeed);
			spawnTime += spawnSpeed;



		}
		SetTimerText ();
		seconds = Mathf.FloorToInt(Time.time % 60f);
		minutes = Mathf.FloorToInt((Time.time / 60f) - (hours*60));
		hours = Mathf.FloorToInt(Time.time / 3600f);

		displayScore.text = "Score:" + score;

		if (Input.GetKeyDown (KeyCode.U)) {
			spawnSpeed++;
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			spawnSpeed--;
		}


		}
		

}





