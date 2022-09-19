using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour {

    public Sprite[] stars;


    public void starfunction(int inputnumber) {
        GetComponent<SpriteRenderer>().sprite = stars[inputnumber];
    }

    public void star0() {
        GetComponent<SpriteRenderer>().sprite = stars[0];
    }
    public void star1() {
        GetComponent<SpriteRenderer>().sprite = stars[1];
    }
    public void star2() {
        GetComponent<SpriteRenderer>().sprite = stars[2];
    }
    public void star3() {
        GetComponent<SpriteRenderer>().sprite = stars[3];
    }
}
