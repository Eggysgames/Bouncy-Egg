using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour {

    private Main maincode;
    private Egg eggcode;

    private GameObject blackholestart;
    private GameObject blackholeexit;
    private GameObject Egg;
    public GameObject blackholeeffect;
    private bool transferingin;
    private bool transferingout;
    private bool switchitover;

    private Vector2 vecholder;

    public AudioClip soundeffect;
    public AudioClip soundeffect2;

    void Start() {

        maincode = GameObject.Find("UI Canvas NonChange").GetComponent<Main>();
        eggcode = GameObject.Find("Egg").GetComponent<Egg>();
        Egg = GameObject.Find("Egg");
        blackholeexit = GameObject.Find("BlackHoleExit");

        transferingin = false;
        transferingout = false;
        switchitover = false;
    }


    void Update() {

        if (maincode.Gameplaying == false) {
            transferingin = false;
            transferingout = false;
            switchitover = false;
        }


        if (maincode.Gameplaying == true) {

            if (transferingin == true) {

                Vector3 theScale = Egg.transform.localScale;

                theScale.x -= 300f * Time.deltaTime;
                theScale.y -= 300f * Time.deltaTime;

                Egg.transform.localScale = theScale;

                if (Egg.transform.position.x < this.transform.position.x) {
                    Egg.transform.position = new Vector2(Egg.transform.position.x + 0.02f, Egg.transform.position.y);
                }
                if (Egg.transform.position.x > this.transform.position.x) {
                    Egg.transform.position = new Vector2(Egg.transform.position.x - 0.02f, Egg.transform.position.y);
                }

                if (Egg.transform.position.y < this.transform.position.y) {
                    Egg.transform.position = new Vector2(Egg.transform.position.x, Egg.transform.position.y + 0.02f);
                }
                if (Egg.transform.position.y > this.transform.position.y) {
                    Egg.transform.position = new Vector2(Egg.transform.position.x, Egg.transform.position.y - 0.02f);
                }

                if (theScale.x < 0.1f) {
                    transferingin = false;
                    switchitover = true;
                }
            }

            if (switchitover == true) {
                Instantiate(blackholeeffect, blackholeexit.transform.position, transform.rotation);
                Egg.transform.position = blackholeexit.transform.position;
                transferingout = true;
                switchitover = false;
            }

            if (transferingout == true) {

                Vector3 theScale = Egg.transform.localScale;

                theScale.x += 300f * Time.deltaTime;
                theScale.y += 300f * Time.deltaTime;

                Egg.transform.localScale = theScale;

                if (theScale.x >= 56.25017) {

                    AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.2f);

                    Egg.GetComponent<Rigidbody2D>().isKinematic = false;
                    Egg.GetComponent<Rigidbody2D>().velocity = new Vector2(vecholder.x, vecholder.y);
                    transferingout = false;
                   
                }


            }

        }




    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Egg") {

            if (transferingin == false && eggcode.tempdeath == false) {

                AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.2f);

                Instantiate(blackholeeffect, transform.position, transform.rotation);

                vecholder = Egg.GetComponent<Rigidbody2D>().velocity;

                Egg.GetComponent<Rigidbody2D>().isKinematic = true;
                Egg.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

                transferingin = true;
            }
        }

    }



}
