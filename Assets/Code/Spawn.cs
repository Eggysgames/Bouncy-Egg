using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {


	public Rigidbody2D ObjectToSpawn; 
	public Transform WhereToSpawn; 
	public int frequency; 
	public Vector3 random;

	private float spawntime = 0;

	void Update () {


		random = new Vector3 (Random.Range(0,5), 0, 0);

		spawntime += 1 * Time.fixedDeltaTime;

		if (spawntime > frequency) {
			Instantiate (ObjectToSpawn, WhereToSpawn.position+random, WhereToSpawn.rotation);
			spawntime = 0; 
		}
		
	}
}
