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

    public AudioClip ButtonPress;

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

        GetComponent<AudioSource>().PlayOneShot(ButtonPress);

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


