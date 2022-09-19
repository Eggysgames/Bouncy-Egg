using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XSpinner : MonoBehaviour {

    private Main maincode;

    private float holdrot;

    void Start() {

        maincode = GameObject.Find("UI Canvas NonChange").GetComponent<Main>();
        holdrot = GetComponent<RectTransform>().eulerAngles.z;

    }

    
    void Update() { 
    
        if (maincode.Gameplaying == false) {
            transform.localRotation = Quaternion.Euler(0.0f, 0, 0.0f);
            //GetComponent<RectTransform>().eulerAngles.z = new Vector2(0, 0);
        }
       
        
    }
}