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
    private static int ruleStep = 1;

    public void Start() {
    }
    public void PlayButton(string scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
    public void RulesButton()
    {
        RulesMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void CreditsButton() {
        CreditsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void MainMenuButton() {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        RulesMenu.SetActive(false);
    }
    public void BackButton() {
        RulesMenu.transform.Find("NextButton").gameObject.SetActive(true);
        RulesMenu.transform.Find("PlayButton").gameObject.SetActive(false);
        if (ruleStep == 1) {
            MainMenuButton();
        } else {
            ruleStep -= 1;
            loadRules();
        }
    }
    public void QuitButton() {
        Application.Quit();
    }
    public void NextButton() {
        ruleStep += 1;
        loadRules();
        // Last step
        if (ruleStep >= 4) {
            RulesMenu.transform.Find("NextButton").gameObject.SetActive(false);
            RulesMenu.transform.Find("PlayButton").gameObject.SetActive(true);
        }
    }

    private void loadRules() {
        RulesImage.sprite = Resources.Load<Sprite>("Rules/Rules" + ruleStep);
    }
    
}
