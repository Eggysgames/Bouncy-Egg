using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;


public class TNT : MonoBehaviour {

    private Egg eggcode;
    private Main maincode;
    private ShadowCaster2D shadowcaster2dcode;
    private Light2D light2dcode;

    public GameObject lightholderobject;

    public GameObject explosion;
    private bool respawntimer;
    private float timer;

    public AudioClip soundeffect;
    void Start() {

        shadowcaster2dcode = GetComponent<ShadowCaster2D>();
        light2dcode = lightholderobject.GetComponent<Light2D>();

        timer = 0;
        respawntimer = false;
        maincode = GameObject.Find("UI Canvas NonChange").GetComponent<Main>();
        eggcode = GameObject.Find("Egg").GetComponent<Egg>();
    }


    void Update() {
        if (respawntimer && MyStaticClass.paused == false) {
            timer += 1 * Time.fixedDeltaTime;

            //Debug.Log(timer += 1 * Time.fixedDeltaTime);

            if (light2dcode.intensity > 0) {
                light2dcode.intensity -= 0.01f;
            }
            if (light2dcode.intensity <= 0) {
                light2dcode.enabled = false;
            }

        }
        if (timer > 5) {
            ResetThis();
            maincode.ResetGame();
        }

        if (maincode.Gameplaying == false) {
            ResetThis();
        }


    }


    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Egg" && eggcode.tempdeath == false) {
            if (!respawntimer) {
                Death();
            } 
        }

    }

    public void Death() {

        AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.4f);
        Instantiate(explosion, transform.position, transform.rotation);
        respawntimer = true;
        GetComponent<SpriteRenderer>().enabled = false;
        eggcode.TempDeath();
        shadowcaster2dcode.enabled = false;
        light2dcode.intensity = 1;
        light2dcode.enabled = true;

    }

    public void ResetThis() {
        shadowcaster2dcode.enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        respawntimer = false;
        timer = 0;
    }

}
