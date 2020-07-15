using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    private int highscore;
    // Start is called before the first frame update
    void OnEnable()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        GetComponent<TextMeshProUGUI>().text = "HIGH SCORE:\n" + highscore.ToString();
    }

    // Update is called once per frame
    public void UpdateHighScore(int score)
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);

        }

    }
}
