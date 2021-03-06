using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float timer = 61.0f;
    public Text timeText;
    public string scene;

    void Update()
    {
        timer -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (timer <= 6)
        {
            timeText.color = new Color(1, 0, 0, 1);
        }
        if (timer <= 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }
}