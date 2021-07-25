using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject RulesMenu;
    public Image RulesImage;
    private int ruleStep = 1;

    public void Start() {
        RulesImage = GetComponent<Image>();
    }
    public void PlayButton(string scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
    public void RulesButton()
    {
        ruleStep = 1;
        RulesImage.sprite = Resources.Load<Sprite>("Rules" + ruleStep);
        // RulesMenu.Find("NextButton").SetActive(true);
        // RulesMenu.Find("PlayButton").SetActive(false);
        RulesMenu.SetActive(true);
        // CreditsMenu.SetActive(false);
        MainMenu.SetActive(false);
    }
    public void CreditsButton() {
        CreditsMenu.SetActive(true);
        MainMenu.SetActive(false);
        // RulesMenu.SetActive(false);
    }
    public void MainMenuButton() {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        RulesMenu.SetActive(false);
    }
    public void BackButton(){
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        RulesMenu.SetActive(false);
    }
    public void QuitButton() {
        Application.Quit();
    }
    public void NextButton() {
        ruleStep += 1;
        // ruleImage = Resources.Load<Sprite>("Rules/Rules" + ruleStep);
        // Last step
        if (ruleStep >= 4) {
            // RulesMenu.Find("NextButton").SetActive(false);
            // RulesMenu.Find("PlayButton").SetActive(true);
        }
    }
    
}
