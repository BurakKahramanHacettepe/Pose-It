using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Rig;
    public GameObject Skeleton;
    public GameObject Conveyor;

    public GameObject highscore;
    public TextMeshProUGUI score_text;
    public int score;

    public GameObject restartPanel;

    public bool lost = false;

    private void Update()
    {
        if (!lost)
        {
            score = Mathf.CeilToInt(Mathf.Floor(-Conveyor.transform.position.z / 10f) / 2f);
        }
        GetComponent<SpeedControl>().diff_speed = score / 10f;
        score_text.text = score.ToString();
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
    }
    public void Continue()
    {
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Lose()
    {
        Rig.SetActive(false);

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().shakeDuration = 0.3f;

        lost = true;

        StartCoroutine("SlowDownBelt");
        Skeleton.GetComponent<Rigidbody>().isKinematic = false;
        foreach (var item in Skeleton.GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = false;

        }

        GetComponent<AudioSource>().Play();

        highscore.GetComponent<HighScoreScript>().UpdateHighScore(score);

        Invoke("LaunchBody", 1.0f);
    }

    void LaunchBody()
    {
        Vector3 v = Random.insideUnitSphere;
        v.y = Mathf.Abs(v.y);

        print(v);
        Skeleton.GetComponent<Rigidbody>().AddForce(v * 30000.0f);

        restartPanel.SetActive(true);

    }
    private IEnumerator SlowDownBelt()
    {
        while (Conveyor.GetComponentInParent<GenerateParkour>().speed >= 0.0f)
        {
            Conveyor.GetComponentInParent<GenerateParkour>().speed -= 0.05f;
            Conveyor.GetComponentInParent<GenerateParkour>().speed = Mathf.Clamp(Conveyor.GetComponentInParent<GenerateParkour>().speed, 0, Mathf.Infinity);
            yield return new WaitForSeconds(.05f);
        }

    }

    public void StartGame()
    {
        Conveyor.GetComponent<GenerateParkour>().enabled = true;
        Invoke("StartSpeedControl", 2f);
    }
    void StartSpeedControl()
    {
        GetComponent<SpeedControl>().enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);

    }
}
