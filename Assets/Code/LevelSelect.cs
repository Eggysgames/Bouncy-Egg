using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;

public class LevelSelect : MonoBehaviour {

    private CapsuleFader capsulefadercode;
    public TextMeshProUGUI totalstars;
    public Scrollbar slider;

    public Text[] levelbuttons;
    public GameObject[] locks;

    private int holder;
    private int maxholder;

    void Start() {

        capsulefadercode = GameObject.Find("CapsuleFader").GetComponent<CapsuleFader>();
        
        ///Stars
        for (int i=1;i< 41; i++) {
            holder = PlayerPrefs.GetInt(i+"stars");
            maxholder += holder;
        }
        totalstars.text = "Total Stars -" + maxholder + "/120";


        ///Disable Buttons
        foreach (Text myButton in levelbuttons) {
            myButton.GetComponent<Button>().interactable = false;
        }
        levelbuttons[0].GetComponent<Button>().interactable = true;

        ///Set unlocks, stars and levels
        for (int i = 2; i < 41; i++) {
            if (PlayerPrefs.GetInt("Levelsunlocked") >= i) {
                locks[i - 2].SetActive(false);
                levelbuttons[i - 1].GetComponent<Button>().interactable = true;
                //////////////////////////////////////////////////
                int starholder = PlayerPrefs.GetInt(i + "stars");
                GameObject.Find("EndingStars" + i).GetComponent<StarsImage>().starfunction(starholder);
            }
        }

        ///Level 1 only set
        if (PlayerPrefs.GetInt("Levelsunlocked") >= 1) {
            int starholder = PlayerPrefs.GetInt("1stars");
            GameObject.Find("EndingStars1").GetComponent<StarsImage>().starfunction(starholder);
        }

    }
    void Update() {

        slider.size = 0.3f;
        

    }

    public void LoadLevel() {

        string holder = EventSystem.current.currentSelectedGameObject.name;

        capsulefadercode.levelnumber = int.Parse(holder);
        capsulefadercode.levelchange = 6;
        capsulefadercode.StartFadeIn();
    }



}