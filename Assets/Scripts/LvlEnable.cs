using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag=="Levels")
        {
            StartCoroutine("ColorUP",other.gameObject);
        }
    }

    private IEnumerator ColorUP(GameObject obj)
    {
        Color w = new Vector4(1, 1, 1, 0f);
        Color w1 = new Vector4(0, 1, 1, 0f);
        float alp = 0.0f;
        while (alp != 1.0f)
        {
            alp += 0.05f;
            alp = Mathf.Clamp(alp, 0f, 1f);
            w.a = alp;
            w1.a = alp;
            obj.GetComponent<Renderer>().material.color = w;
            obj.GetComponent<Outline>().OutlineColor = w1;
            yield return new WaitForSeconds(.05f);
        }

    }
}
