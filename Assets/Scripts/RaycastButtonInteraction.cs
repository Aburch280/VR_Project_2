using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class RaycastButtonInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject playerOrigin;
    [SerializeField]
    private LayerMask teleportMask;
    [SerializeField]
    private InputActionReference teleportButtonPress;

    private int pressCount = 0;  
    public string nextSceneName;        

    void Start()
    {
        teleportButtonPress.action.performed += DoRaycast;
    }

    void DoRaycast(InputAction.CallbackContext __) {
        RaycastHit hit;

        bool didHit = Physics.Raycast(
            transform.position,
            transform.forward,
            out hit,
            Mathf.Infinity,
            teleportMask);

        if (didHit) {
            pressCount++;

            if (pressCount >= 3)
            {
                TransitionScene();
            }
        }

    }

    private void TransitionScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}

