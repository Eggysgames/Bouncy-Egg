using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class BreakableBox : MonoBehaviour {

    private Egg eggcode;
    private Main maincode;

    private Animator myanimator;
    private BoxCollider2D thiscollider;
    private ShadowCaster2D shadowcaster2dcode;

    public GameObject piece1;
    public GameObject piece2;

    private GameObject holder;

    public AudioClip soundeffect;

    void Start() {

        shadowcaster2dcode = GetComponent<ShadowCaster2D>();
        maincode = GameObject.Find("UI Canvas NonChange").GetComponent<Main>();
        eggcode = GameObject.Find("Egg").GetComponent<Egg>();
        thiscollider = GetComponent<BoxCollider2D>();
        myanimator = GetComponent<Animator>();

    }


    void Update() {
        if (maincode.Gameplaying == false) {
            ResetThis();
        }
        if (maincode.Gameplaying == true) {
            myanimator.SetBool("hit2", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Egg" && eggcode.tempdeath == false) {
            Death();
        }
    }

    public void StopThis() {
        thiscollider.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Death() {

        shadowcaster2dcode.enabled = false;

        AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.45f);
        GetComponent<SpriteRenderer>().enabled = false;
        thiscollider.enabled = false;

        int myrot = Random.Range(10, 20);
        int myforce = Random.Range(50, 200);

        holder = Instantiate(piece2, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        holder.GetComponent<Rigidbody2D>().AddForce(new Vector2(myforce, myforce));
        holder.GetComponent<Rigidbody2D>().AddTorque(-myrot);

        holder = Instantiate(piece1, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        holder.GetComponent<Rigidbody2D>().AddForce(new Vector2(-myforce, myforce));
        holder.GetComponent<Rigidbody2D>().AddTorque(myrot);


        myanimator.SetTrigger("hit");
    }

    public void ResetThis() {
        shadowcaster2dcode.enabled = true;
        thiscollider.enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        myanimator.SetBool("hit2", true);
    }

}


