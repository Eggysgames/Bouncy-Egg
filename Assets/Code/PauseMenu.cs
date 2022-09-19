using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private Egg eggcode;
    private CapsuleFader capsulefadercode;

    public GameObject fadeobject;
    

    public TextMeshProUGUI soundtext;
    private bool soundeffectsonoroff;
    public TextMeshProUGUI trailtext;
    private bool trailonoroff;
    public bool paused;
    public GameObject settingsbutton;

    //private GameObject trailobject;


    void Start() {

        capsulefadercode = GameObject.Find("CapsuleFader").GetComponent<CapsuleFader>();
        eggcode = GameObject.Find("Egg").GetComponent<Egg>();
        //////////////////////////
        soundeffectsonoroff = true;
        trailonoroff = false;
        paused = false;

    }



    public void ShowPauseMenu() {
        if (MyStaticClass.paused == false) {
            settingsbutton.GetComponent<Button>().interactable = false;
            fadeobject.SetActive(true);
            Time.timeScale = 0;
            MyStaticClass.paused = true;
        }
    }
    public void HidePauseMenu() {
        settingsbutton.GetComponent<Button>().interactable = true;
        fadeobject.SetActive(false);
        Time.timeScale = 1;
        MyStaticClass.paused = false;
    }
    public void SoundToggle() {
        soundeffectsonoroff = !soundeffectsonoroff;
        if (soundeffectsonoroff == false) {
            soundtext.text = "Sound - Off";
            MyStaticClass.soundholdervolume = 0;
            AudioListener.volume = MyStaticClass.soundholdervolume;
            //MyStaticClass.soundholder = false;
        }
        if (soundeffectsonoroff == true) {
            soundtext.text = "Sound - On";
            MyStaticClass.soundholdervolume = 1;
            AudioListener.volume = MyStaticClass.soundholdervolume;
            //MyStaticClass.soundholder = true;
        }
    }
    public void TrailToggle() {
        trailonoroff = !trailonoroff;
        if (trailonoroff == false) {
            trailtext.text = "Trail - Off";
            MyStaticClass.toggletrail = false;
            eggcode.TurnoffTrail();
        }
        if (trailonoroff == true) {
            trailtext.text = "Trail - On";
            MyStaticClass.toggletrail = true;
            eggcode.TurnonTrail();
        }
    }
    public void ReturnToMainMenu() {
        Time.timeScale = 1;
        capsulefadercode.levelchange = 2;
        capsulefadercode.StartFadeIn();
    }
    




}
