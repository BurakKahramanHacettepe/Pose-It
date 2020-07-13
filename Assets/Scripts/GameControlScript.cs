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

    public TextMeshProUGUI score_text;
    public int score;

    public GameObject restartPanel;

    private void Update()
    {
        score = Mathf.CeilToInt(Mathf.Floor(-Conveyor.transform.position.z/10f)/2f);
        score_text.text = score.ToString();
    }

    public void Lose()
    {
        Rig.SetActive(false);

        StartCoroutine("SlowDownBelt");
        Skeleton.GetComponent<Rigidbody>().isKinematic = false;
        foreach (var item in Skeleton.GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = false;
        }
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
