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
       

    // Start is called before the first frame update
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

            // button.transform.localPosition -= new Vector3(0, 0.1f, 0);

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

