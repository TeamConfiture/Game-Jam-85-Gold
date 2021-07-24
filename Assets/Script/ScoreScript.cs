using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
	private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        int score = 10; //TODO
        int bestScore = 100; //TODO
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "Score: " + score + "\nBest: " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
