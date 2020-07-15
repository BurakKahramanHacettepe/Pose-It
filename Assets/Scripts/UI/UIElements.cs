using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIElements : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        gameObject.transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject,Vector3.one,0.5f).setIgnoreTimeScale(true);
    }

    // Update is called once per frame

    
    
   

    
}
