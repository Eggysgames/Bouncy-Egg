using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

    private Rigidbody2D RB;



    void Start() {

        RB = GetComponent<Rigidbody2D>();


    }


    void Update() {

  

    }


    public void Nudge() {
        RB.AddForce(new Vector2(-200, 0));
    }
}
