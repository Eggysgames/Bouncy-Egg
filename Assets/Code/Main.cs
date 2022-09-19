using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    private Egg eggcode;
    private Clamp clampcode;
    private Lamp lampcode;
    private CapsuleFader capsulefadercode;
    public Stars starscode;

    public GameObject Egg;
    public GameObject ReleaseButton;
    public GameObject ResetButton;
    public GameObject endlevelobject;
    public Text ReleaseButtonText;
    public Text ResetButtonText;

    public TextMeshProUGUI gamecompletetext;

    public bool Gameplaying;
    private float gametimer;
    private string scenename;

    public AudioClip soundeffect;

    void Start() {

        eggcode = GameObject.Find("Egg").GetComponent<Egg>();
        lampcode = GameObject.Find("Dangle Light").GetComponent<Lamp>();
        clampcode = GameObject.Find("Clamp").GetComponent<Clamp>();
        capsulefadercode = GameObject.Find("CapsuleFader").GetComponent<CapsuleFader>();
        /////////
        ReleaseButton.GetComponent<Button>().interactable = true;
        ResetButton.GetComponent<Button>().interactable = false;
        ResetButtonText.GetComponent<Text>().canvasRenderer.SetAlpha(0.09f);
        ResetButton.GetComponent<Image>().canvasRenderer.SetAlpha(0.09f);

        scenename = SceneManager.GetActiveScene().name;
        Gameplaying = false;
        gametimer = 0;

    }


    void Update() {

        if (MyStaticClass.endlevel == false) {
            gametimer += 1 * Time.deltaTime;
            //Debug.Log(gametimer);
        }

        if (MyStaticClass.endlevel == true) {
            MyStaticClass.paused = true;
            endlevelobject.SetActive(true);
            gamecompletetext.text = "Level Completed in " + Mathf.Round(gametimer) + " Seconds";


            int intholder = int.Parse(scenename);
            intholder += 1;

            int checkholder = PlayerPrefs.GetInt("Levelsunlocked");

            if (intholder > checkholder) {
                PlayerPrefs.SetInt("Levelsunlocked", intholder);
            }

            if (gametimer >= 0 && gametimer <= 30) {
                starscode.star3();
                PlayerPrefs.SetInt(scenename+"stars", 3);
            }
            if (gametimer > 30 && gametimer <= 60) {
                starscode.star2();
                PlayerPrefs.SetInt(scenename + "stars", 2);
            }
            if (gametimer >= 60 && gametimer <= 120) {
                starscode.star1();
                PlayerPrefs.SetInt(scenename + "stars", 1);
            }
            if (gametimer >= 121) {
                starscode.star0();
                PlayerPrefs.SetInt(scenename + "stars", 0);
            }

        }

        if (Gameplaying == true) {
            if (MyStaticClass.paused == true) {
                ResetButton.GetComponent<Button>().interactable = false;
            }
            if (MyStaticClass.paused == false) {
                ResetButton.GetComponent<Button>().interactable = true;
            }
        }
        if (Gameplaying == false) {
            if (MyStaticClass.paused == true) {
                ReleaseButton.GetComponent<Button>().interactable = false;
            }
            if (MyStaticClass.paused == false) {
                ReleaseButton.GetComponent<Button>().interactable = true;
            }
        }

    }

    public void ReleaseButtonPress() {
        if (MyStaticClass.paused == false) {
            AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.15f);
            GameIsPlaying();
            Egg.GetComponent<Rigidbody2D>().isKinematic = false;
            clampcode.Switcher();
            lampcode.Nudge();
        }
    }

    public void ResetButtonPress() {
        if (MyStaticClass.paused == false) {
            ResetGame();
        }
    }

     public void ResetGame() {
        GameStoppedPlaying();
        eggcode.Death();
        
    }

    public void GameIsPlaying() {
        Gameplaying = true;
        ReleaseButton.GetComponent<Button>().interactable = false;
        ReleaseButtonText.GetComponent<Text>().canvasRenderer.SetAlpha(0.09f);
        ReleaseButton.GetComponent<Image>().canvasRenderer.SetAlpha(0.09f);
        //////////////
        ResetButton.GetComponent<Button>().interactable = true;
        ResetButtonText.GetComponent<Text>().canvasRenderer.SetAlpha(1f);
        ResetButton.GetComponent<Image>().canvasRenderer.SetAlpha(1f);
    }

    public void GameStoppedPlaying() {
        clampcode.LightFlash();
        eggcode.tempdeath = false;
        Gameplaying = false;
        ReleaseButton.GetComponent<Button>().interactable = true;
        ReleaseButtonText.GetComponent<Text>().canvasRenderer.SetAlpha(1f);
        ReleaseButton.GetComponent<Image>().canvasRenderer.SetAlpha(1f);
        ///////////////
        ResetButton.GetComponent<Button>().interactable = false;
        ResetButtonText.GetComponent<Text>().canvasRenderer.SetAlpha(0.09f);
        ResetButton.GetComponent<Image>().canvasRenderer.SetAlpha(0.09f);
    }

    public void NextLevel() {
        capsulefadercode.levelchange = 5;
        capsulefadercode.StartFadeIn();

    }


}
