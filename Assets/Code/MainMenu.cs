using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    private CapsuleFader capsulefadercode;
    private string GrabSceneName;

    public TextMeshProUGUI ContinueGameText;
    public Button ContinueGameButton;
    private int conhold;

    void Start() {
        GrabSceneName = SceneManager.GetActiveScene().name;
        capsulefadercode = GameObject.Find("CapsuleFader").GetComponent<CapsuleFader>();

        conhold = PlayerPrefs.GetInt("Levelsunlocked");

        if (conhold <= 1 && GrabSceneName == "-1 Main Menu") {
            ContinueGameText.color = new Color(1, 1, 1, 0.2f);
            ContinueGameButton.GetComponent<Button>().enabled = false;
        }

    }



    public void PlayGame() {
        capsulefadercode.levelchange = 1;
        capsulefadercode.StartFadeIn();
    }

    public void ContinueGame() {

        capsulefadercode.levelchange = 6;
        capsulefadercode.levelnumber = conhold;
        capsulefadercode.StartFadeIn();

        ///Check Player prefs for current scene to go too
        //capsulefadercode.levelchange = 1;
        //capsulefadercode.StartFadeIn();
    }

    public void ReturnToMainMenu() {
        capsulefadercode.levelchange = 2;
        capsulefadercode.StartFadeIn();
    }

    public void LevelSelect() {
        capsulefadercode.levelchange = 3;
        capsulefadercode.StartFadeIn();
    }

    public void Credits() {
        capsulefadercode.levelchange = 4;
        capsulefadercode.StartFadeIn();
    }



}
