using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StarsImage : MonoBehaviour {

    public Sprite[] stars;


    public void starfunction(int inputnumber) {
        GetComponent<Image>().sprite = stars[inputnumber];
    }


    public void star0() {
        GetComponent<Image>().sprite = stars[0];
    }
    public void star1() {
        GetComponent<Image>().sprite = stars[1];
    }
    public void star2() {
        GetComponent<Image>().sprite = stars[2];
    }
    public void star3() {
        GetComponent<Image>().sprite = stars[3];
    }
}
