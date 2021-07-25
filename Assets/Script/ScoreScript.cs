using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get scores
        int bestScore = PlayerPrefs.GetInt("bestScore");
        int score = DogBehaviour.score;
        // New best score?
        if (score > bestScore) {
            // Replace and save
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
            PlayerPrefs.Save();
        }
        // Print values!
        Text scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "Score: " + score + "\nBest: " + bestScore;
    }

    public void SwitchScene(string scene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    public void QuitButton() {
        Application.Quit();
    }

}
