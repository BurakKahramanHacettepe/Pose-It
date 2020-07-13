using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FadeOut : MonoBehaviour
{
    private float Speed = 5f;

    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;

    private float alpha = 1f;
    private Color fade = new Color(0,1,0,1);

    void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (transform.position.z <= 0f)
        {
            alpha -= Speed * Time.deltaTime;
            alpha = Mathf.Clamp(alpha, 0f, 1f);
            fade.a = alpha;
            _renderer.GetPropertyBlock(_propBlock);
            // Assign our new value.
            _propBlock.SetColor("_Color", fade);
            // Apply the edited values to the renderer.
            _renderer.SetPropertyBlock(_propBlock);

            GetComponent<Outline>().OutlineColor = fade;

            // Put the game object in the ignore raycast layer (2)
            gameObject.layer = 2;

            Invoke("Destruction", 0.2f);

        }
        
    }

    void Destruction()
    {
        Destroy(gameObject);
    }
}