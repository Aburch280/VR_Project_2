using UnityEngine;
using UnityEngine.SceneManagement;  // To handle scene loading

public class ButtonPressTransition : MonoBehaviour
{
    public Transform pressTransform;  // Assign the transform of the pressable part of the button
    public float pressDepth = 0.1f;   // Depth of button press movement
    public string nextSceneName;      // Name of the next scene to load
    private Vector3 initialPosition;  // Stores initial position of the press part
    private int pressCount = 0;       // Counts the button presses
    // private bool alreadyHit = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the button is the hand capsule
        if (other.CompareTag("Hand"))
        {
            PressButton();
            // alreadyHit = true;

        }
    }

    private void PressButton()
    {
        pressCount++;

        // Animate the press part by moving it down
        pressTransform.localPosition = initialPosition - new Vector3(0, pressDepth, 0);

        // Check if the press count has reached 3
        if (pressCount >= 5)
        {
            TransitionScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            // Reset the button to the initial position after releasing
            pressTransform.localPosition = initialPosition;
            // alreadyHit = false;
        }
    }

    private void TransitionScene()
    {
        Debug.Log("Transitioning to scene: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}

// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class ButtonPressTransition : MonoBehaviour
// {
//     public Transform pressTransform;  // The transform of the pressable part of the button
//     public float pressDepth = 0.1f;   // The distance the button moves when pressed
//     public string nextSceneName;      // The name of the next scene to load
//     private Vector3 initialPosition;  // Initial position of the pressable part
//     private int pressCount = 0;       // Counts how many times the button is
//     private bool alreadyHit = false;


//     private void Start()
//     {
//         initialPosition = pressTransform.localPosition;
//     }

//     private void OnCollisionEnter(Collision other)
//     {
//         // Check if the object colliding with the button is the hand capsule
//         if (other.gameObject.CompareTag("Hand") && !alreadyHit)
//         {
//             PressButton();
//             alreadyHit = true;
//         }
//     }

//     private void PressButton()
//     {
//         pressCount++;
        
//         // Animate the press part by moving it down
//         pressTransform.localPosition = initialPosition - new Vector3(0, pressDepth, 0);

//         // Check if press count has reached 3
//         if (pressCount >= 3)
//         {
//             TransitionScene();
//         }
//     }

//     private void OnCollisionExit(Collision other)
//     {
//         if (other.gameObject.CompareTag("Hand"))
//         {
//             // Reset the button position after the hand leaves the collider
//             pressTransform.localPosition = initialPosition;
//             alreadyHit = false;
//         }
//     }

//     private void TransitionScene()
//     {
//         Debug.Log("Loading scene: " + nextSceneName);
//         SceneManager.LoadScene(nextSceneName);
//     }
// }


