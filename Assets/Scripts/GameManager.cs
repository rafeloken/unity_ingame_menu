using UnityEngine;

// This is about as basic of a "game manager" class as it gets.
public class GameManager : MonoBehaviour {
    // Reference to the InGameMenu script.
    InGameMenu igm;

    void Awake() {
        // Assumes this script is on the same object as the InGameMenu script.
        igm = gameObject.GetComponent<InGameMenu>();
    }

    void Update() {
        // Monitor for 'm' being pressed.
        if(Input.GetKeyDown(KeyCode.M)) {
            // Toggle the menu.
            igm.enabled = !igm.enabled;
        }
    }
}
