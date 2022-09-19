using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

    private Main maincode;
    private Egg eggcode;

    private Rigidbody2D eggRB;
    private Animator myanimator;
    private bool isPressed;

    private GameObject TopPosition;
    private GameObject LeftPosition;
    private GameObject RightPosition;
    private GameObject BottomPosition;

    private float thisPosX;
    private float thisPosY;
    private Vector2 MousePosition;
    private Vector2 objPosition;

    public bool isSpring;
    public bool isConveyer;
    public bool isWall;
    public GameObject SelectionArrows;
    public GameObject left;
    public GameObject right;

    public AudioClip soundeffect;
    public AudioClip soundeffect2;
    public AudioClip soundeffect3;
    private float diffy;
    private bool exitfade;
    private float exitfadetimer;

    void Start() {

        eggRB = GameObject.Find("Egg").GetComponent<Rigidbody2D>();
        eggcode = GameObject.Find("Egg").GetComponent<Egg>();
        maincode = GameObject.Find("UI Canvas NonChange").GetComponent<Main>();
        TopPosition = GameObject.Find("TopPosition");
        LeftPosition = GameObject.Find("LeftPosition");
        RightPosition = GameObject.Find("RightPosition");
        BottomPosition = GameObject.Find("BottomPosition");
        myanimator = GetComponent<Animator>();
        //////
        isPressed = false;
        SelectionArrows.SetActive(false);
        diffy = 0;
        if (isWall) {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
        }
    }


    void Update() {

        float diff = this.transform.position.x - left.transform.position.x;

        if (left.transform.position.y > right.transform.position.y) {
            diffy = this.transform.position.y - left.transform.position.y;
        }
        else if (left.transform.position.y < right.transform.position.y) {
            diffy = this.transform.position.y - right.transform.position.y;
        }

        if (isPressed && MyStaticClass.paused == false) {
            MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.position = new Vector3(objPosition.x + thisPosX, objPosition.y + thisPosY, this.transform.position.z);
        }

        if (this.transform.position.y >= TopPosition.transform.position.y + diffy) {
            this.transform.position = new Vector3(this.transform.position.x, TopPosition.transform.position.y + diffy, this.transform.position.z);
        }
        if (this.transform.position.y <= BottomPosition.transform.position.y - diffy) {
            this.transform.position = new Vector3(this.transform.position.x, BottomPosition.transform.position.y - diffy, this.transform.position.z);
        }
        if (this.transform.position.x <= LeftPosition.transform.position.x + diff) {
            this.transform.position = new Vector3(LeftPosition.transform.position.x + diff, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x >= RightPosition.transform.position.x - diff) {
           this.transform.position = new Vector3(RightPosition.transform.position.x - diff, this.transform.position.y, this.transform.position.z);
        }
        
        if (isWall && exitfade == true) {
            exitfadetimer -= 1*Time.fixedDeltaTime;
            if (exitfadetimer <= 0) {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
                exitfade = false;
            }
        }

    }

    void OnMouseDown() {
        if (maincode.Gameplaying == false && MyStaticClass.paused == false) {
            MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            thisPosX = transform.position.x - objPosition.x;
            thisPosY = transform.position.y - objPosition.y;
            ////////////////
            isPressed = true;
            GetComponent<SpriteRenderer>().color = new Color(150, 0, 0, 0.7f);

        }
    }

    void OnMouseUp() {
        if (MyStaticClass.paused == false && !isWall) {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            isPressed = false;
        }
        if (MyStaticClass.paused == false && isWall) {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
            isPressed = false;
        }
    }

    private void OnMouseOver() {
        if (maincode.Gameplaying == false && MyStaticClass.paused == false) {
            SelectionArrows.SetActive(true);
        }
    }

    private void OnMouseExit() {
        SelectionArrows.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Egg" && eggcode.tempdeath == false) {
            if (isSpring) {
                AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.4f);
                myanimator.SetTrigger("hit");
                //Debug.Log(eggRB.velocity.y);
                if (eggRB.velocity.y < 1) {
                    eggRB.AddForce(new Vector2(0, 100));
                }
                if (eggRB.velocity.y < 2 && eggRB.velocity.y > 1) {
                    eggRB.AddForce(new Vector2(0, 200));
                }
                if (eggRB.velocity.y < 3 && eggRB.velocity.y > 2) {
                    eggRB.AddForce(new Vector2(0, 300));
                }
                if (eggRB.velocity.y <6) {
                    eggRB.AddForce(new Vector2(0, 25));
                }
            }
            if (isConveyer) {
                AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.35f);
            }
            if (isWall && col.enabled == true) {
                AudioSource.PlayClipAtPoint(soundeffect3, Camera.main.transform.position, 0.3f);
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
                exitfade = true;
                exitfadetimer = 2;
            }
        }

    }

   
}