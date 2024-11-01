using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

// public class HoverTransition : MonoBehaviour
// {
//     private float hoverTime = 4f;
//     public string nextSceneName;
//     private bool isHovering = false;
//     private float currTime = 0f;

//     // Update is called once per frame
//     void Update()
//     {
//         if (isHovering)
//         {
//             currTime += Time.deltaTime;
//             // currTime += 0.2f;

//             if (currTime >= hoverTime)
//             {
//                 TransitionScene();
//             }
//         }
//     }

//     private void OnTriggerEnter()
//     {
//         isHovering = true;
//         // Debug.Log("colliding");
//     }

//     private void OnTriggerExit()
//     {
//         isHovering = false;
//         currTime = 0f;
//         // Debug.Log("not colliding");
//     }

//     private void TransitionScene()
//     {
//         SceneManager.LoadScene(nextSceneName);
//     }

//     // private void OnTriggerEnter()
//     // {
//     //     Debug.Log("something happened");
//     // }

// }

public class HoverTransition : MonoBehaviour
{
    private float hoverTime = 4f;
    public string nextSceneName;
    private bool isHovering = false;
    private float currTime = 0f;

    public Renderer buttonRenderer;       // The Renderer component of the button
    private Color defaultColor;
    public Color progressColor = Color.green;

    // Speed at which the color flashes
    public float flashSpeed = 5f;

    void Start()
    {
        if (buttonRenderer != null)
        {
            defaultColor = buttonRenderer.material.color;  // Store the default button color
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isHovering)
        {
            currTime += Time.deltaTime;
            // currTime += 0.2f;

            // Calculate the progress percentage
            float progress = currTime / hoverTime;

            // Make the button color flash as progress continues
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
        // Debug.Log("colliding");
    }

    private void OnTriggerExit()
    {
        isHovering = false;
        currTime = 0f;
        // Debug.Log("not colliding");

        if (buttonRenderer != null)
            {
                buttonRenderer.material.color = defaultColor; // Reset to default color
            }
    }

    private void TransitionScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // private void OnTriggerEnter()
    // {
    //     Debug.Log("something happened");
    // }

}
