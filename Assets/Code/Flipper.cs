using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

    private Egg eggcode;
    private Animator myanimator;
    private Rigidbody2D eggRB;

    public AudioClip soundeffect;

    void Start() {

        eggRB = GameObject.Find("Egg").GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        eggcode = GameObject.Find("Egg").GetComponent<Egg>();
    }


    void Update() {


    }
    /*void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Egg" && eggcode.tempdeath == false) {
            Death();
        }
    }
    */
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Egg" && eggcode.tempdeath == false) {
            //eggRB.velocity = new Vector2(eggRB.velocity.x, 0);
            eggRB.AddForce(new Vector2(0, 1000));
            Death();
        }

    }

    public void Death() {
        AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.4f);
        myanimator.SetTrigger("hit");
    }

}
