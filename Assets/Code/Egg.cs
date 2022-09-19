using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class Egg : MonoBehaviour {

    private MyStaticClass MyStaticClasscode;
    private Main maincode;
    private Clamp clampcode;


    public GameObject eggshadowholder;
    private ShadowCaster2D eggshadowcaster2dcode;

    private Rigidbody2D eggRB;
    private Vector3 startingpos;

    public GameObject smokepuff;

    public GameObject tophalfegg;
    public GameObject bottomhalfegg;
    private GameObject holder;
    public bool tempdeath;

    private GameObject eggtrail;
    private GameObject EggObject;
    private TrailRenderer eggtrailrenderer;

    private Vector3 theScale;

    public AudioClip soundeffect;
    public AudioClip soundeffect2;
    public AudioClip soundeffect3;
    public AudioClip soundeffect4;
    public AudioClip soundeffect5;

    void Start() {

        EggObject = GameObject.Find("Egg");
        eggtrail = EggObject.transform.Find("EggTrail").gameObject;
        eggtrailrenderer = eggtrail.GetComponent<TrailRenderer>();
        eggshadowcaster2dcode = eggshadowholder.GetComponent<ShadowCaster2D>();
        maincode = GameObject.Find("UI Canvas NonChange").GetComponent<Main>();
        clampcode = GameObject.Find("Clamp").GetComponent<Clamp>();
        eggRB = GetComponent<Rigidbody2D>();
        ///
        theScale = transform.localScale;
        tempdeath = false;
        startingpos = this.transform.position;
        ////////
        if (MyStaticClass.toggletrail == true) {
            TurnonTrail();
        }
        if (MyStaticClass.toggletrail == false) {
            TurnoffTrail();
        }
    }


    void Update() {

        //Debug.Log(eggRB.velocity);
        GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, 12);

        if (this.transform.position.y < -7) {
            Death();
        }

    }



    public void Death() {

        AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.4f);

        maincode.GameStoppedPlaying();

        Instantiate(smokepuff, startingpos, transform.rotation);

        clampcode.Switcher2();

        eggRB.rotation = 0;
        eggRB.velocity = new Vector2(0, 0);
        eggRB.angularVelocity = 0f;

        eggRB.isKinematic = true;

        transform.localScale = theScale;

        this.transform.position = startingpos;

        GetComponent<SpriteRenderer>().enabled = true;
        eggshadowcaster2dcode.enabled = true;

        if (MyStaticClass.toggletrail == true) {
            eggtrailrenderer.Clear();
            eggtrail.SetActive(true);
        }
    }

    public void TempDeath() {

        AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.2f);

        if (MyStaticClass.toggletrail == true) {
            eggtrail.SetActive(false);
            eggtrailrenderer.Clear();
        }

        tempdeath = true;

        holder = Instantiate(tophalfegg, transform.position, transform.rotation);
        holder.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 200));
        holder.GetComponent<Rigidbody2D>().AddTorque(-60);

        holder = Instantiate(bottomhalfegg, transform.position, transform.rotation);
        holder.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, 200));
        holder.GetComponent<Rigidbody2D>().AddTorque(60);


        eggshadowcaster2dcode.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void TurnonTrail() {
        eggtrailrenderer.Clear();
        eggtrail.SetActive(true);
    }
    public void TurnoffTrail() {
        eggtrailrenderer.Clear();
        eggtrail.SetActive(false);
    }


    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "WhiteWall" && tempdeath == false) {
            AudioSource.PlayClipAtPoint(soundeffect3, Camera.main.transform.position, 0.45f);
        }
        if (col.gameObject.tag == "Light" && tempdeath == false) {
            AudioSource.PlayClipAtPoint(soundeffect4, Camera.main.transform.position, 0.45f);
        }
        if (col.gameObject.tag == "XSpinner" && tempdeath == false) {
            AudioSource.PlayClipAtPoint(soundeffect5, Camera.main.transform.position, 0.45f);
        }
    }

}
