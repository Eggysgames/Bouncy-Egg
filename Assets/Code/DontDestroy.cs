using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {



	private static DontDestroy instance = null;
	public static DontDestroy Instance {
		get { return instance; }
	}


	void Start () {


		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this; 
		}
		DontDestroyOnLoad (this.gameObject);

	
	}



}
