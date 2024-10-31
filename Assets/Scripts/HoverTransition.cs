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

    // Update is called once per frame
    void Update()
    {
        if (isHovering)
        {
            currTime += Time.deltaTime;
            // currTime += 0.2f;

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
