using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFadeOut : MonoBehaviour {

	public float deathremovetimer;

	private Color mycolour; 
	private float colourfade = 1;

	public bool shrinkThis;
	private Vector3 theScale;

	void Start () {
		mycolour = GetComponent<SpriteRenderer> ().color;
        mycolour.a = 1f;
		theScale = transform.localScale;
	}


    void Update () {

		if (shrinkThis && theScale.x >0) {
			theScale = transform.localScale;

			theScale.x -= 0.7f * Time.deltaTime;
			theScale.y -= 0.7f * Time.deltaTime;

			transform.localScale = theScale;
		}

			deathremovetimer -= Time.deltaTime;

			if (deathremovetimer <= 0) {
				colourfade -= 0.007f;
				mycolour.a = colourfade;
				GetComponent<SpriteRenderer> ().color = mycolour;
				if (colourfade <= 0) {
					Destroy (gameObject);
				}
			}


		
	}
}
