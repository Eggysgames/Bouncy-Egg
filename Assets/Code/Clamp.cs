using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class Clamp : MonoBehaviour { 


    public Sprite[] clampsprites;
    private Light2D light2dcode;
    private bool startfade;

    void Start() {

        light2dcode = GetComponent<Light2D>();

        startfade = false;
        light2dcode.enabled = false;
        

    }


    void Update() {

        if (startfade) {
            if (light2dcode.intensity > 0) {
                light2dcode.intensity -= 0.03f;
            }
            if (light2dcode.intensity <= 0) {
                light2dcode.enabled = false;
            }
        }
    }

    public void LightFlash() {
        light2dcode.intensity = 1f;
        startfade = true;
        light2dcode.enabled = true;
    }

    public void Switcher() {
        GetComponent<SpriteRenderer>().sprite = clampsprites[1];
    }
    public void Switcher2() {
        GetComponent<SpriteRenderer>().sprite = clampsprites[0];
    }
}
