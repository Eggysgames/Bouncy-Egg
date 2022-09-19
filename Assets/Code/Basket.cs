using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

    private Egg eggcode;

    private bool endgametimerswitch;
    private float endgametimer;
    private bool runonce;
    private bool runonce2;

    public GameObject endeffect;

    public AudioClip soundeffect;

    void Start() {

        eggcode = GameObject.Find("Egg").GetComponent<Egg>();

        runonce = false;
        runonce2 = false;
        endgametimerswitch = false;
        endgametimer = 0;

    }

    void Update() {

        if (endgametimerswitch == true) {
            MyStaticClass.paused = true;
            endgametimer += 1 * Time.fixedDeltaTime;
        }

        if (endgametimer > 1.5 && runonce == false) {
            AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.4f);
            endeffect.SetActive(true);
            runonce = true;
        }
        if (endgametimer > 2.5 && runonce2 == false) {
            MyStaticClass.endlevel = true;
            runonce2 = true;
        }
    }


    private void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Egg" && eggcode.tempdeath == false) {

            endgametimerswitch = true;
        }

    }

}
