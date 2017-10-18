using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CubeBehaviour : MonoBehaviour {

	int bronzePoints;
	int silverPoints;
	int goldPoints;
	int kryptonitePoints;

	public static bool bdestroyed;
	bool sdestroyed;
	bool gdestroyed;
	bool kdestroyed;

	public OreType oreType;

	void Start () {
		bronzePoints = 1;
		silverPoints = 10;
		goldPoints = 100;
		kryptonitePoints = 1000;



	}
		
		
	void OnMouseEnter () {

		transform.localScale += new Vector3(.1F, .1f, .1f);
	}

	void OnMouseExit () {
		transform.localScale = new Vector3(1F, 1f, 1f);
	}


	 void OnMouseDown () { 
		if (oreType == OreType.bronze) {
			//remove clicked cube from supply and screen
			Destroy (gameObject);
			FinalGameControllerPersonal.bronzeSupply -= 1;
			//add bronzePoints to score
			FinalGameControllerPersonal.score += bronzePoints;
			}



		if (oreType == OreType.silver) {
			//remove clicked cube from supply and screen
			Destroy (gameObject);
			FinalGameControllerPersonal.silverSupply -= 1;
			//add silverPoints to score
			FinalGameControllerPersonal.score += silverPoints;

		}

		if (oreType == OreType.gold) {
			//remove clicked cube from supply and screen
			Destroy (gameObject);
			FinalGameControllerPersonal.goldSupply -= 1;
			//add goldPoints to score
			FinalGameControllerPersonal.score += goldPoints;


		}

		if (oreType == OreType.kryptonite) {
			//remove clicked cube from supply and screen
			Destroy (gameObject);
			FinalGameControllerPersonal.kryptoniteSupply -= 1;
			//add kryptonitePoints to score
			FinalGameControllerPersonal.score += kryptonitePoints;


		}



}

}
