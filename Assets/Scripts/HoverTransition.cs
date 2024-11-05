using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class HoverTransition : MonoBehaviour
{
    private float hoverTime = 4f;
    public string nextSceneName;
    private bool isHovering = false;
    private float currTime = 0f;

    public Renderer buttonRenderer;  
    private Color defaultColor;
    public Color progressColor = Color.green;

    public float flashSpeed = 5f;

    void Start()
    {
        if (buttonRenderer != null)
        {
            defaultColor = buttonRenderer.material.color;
        }
    }

    void Update()
    {
        if (isHovering)
        {
            currTime += Time.deltaTime;

            float progress = currTime / hoverTime;

            if (buttonRenderer != null)
            {
                float lerpValue = Mathf.PingPong(Time.time * flashSpeed, 1.0f);
                buttonRenderer.material.color = Color.Lerp(defaultColor, progressColor, lerpValue * progress);
            }

            if (currTime >= hoverTime)
            {
                TransitionScene();
            }
        }
    }

    private void OnTriggerEnter()
    {
        isHovering = true;
    }

    private void OnTriggerExit()
    {
        isHovering = false;
        currTime = 0f;

        if (buttonRenderer != null)
            {
                buttonRenderer.material.color = defaultColor;
            }
    }

    private void TransitionScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
