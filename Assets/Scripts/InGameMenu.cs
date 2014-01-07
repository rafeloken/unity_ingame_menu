using UnityEngine;

public class InGameMenu : MonoBehaviour {
    // Reference to menu background prefab set in the inspector.
    public GameObject menuBackground;

    // Reference to the background object created when the menu is opened.
    GameObject menuBG;
    // Reference to the main camera to help orient the menu's background quad.
    Transform mainCamera;

    void OnEnable() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        menuBG = (GameObject)Instantiate(menuBackground);

        // The background quad is a prefab set to be oriented so that it takes up
        // the whole screen in relation to the camera's position so we set it's
        // parent to the mainCamera we grabbed above.
        menuBG.transform.parent = mainCamera;
        // By default the transform has us oriented in global space, but the position 
        // is meant to be local so we change that here.
        menuBG.transform.localPosition = menuBG.transform.position;

        // Pause the game.
        Time.timeScale = 0f;
        Debug.Log("PAUSE");
    }

    void OnDisable() {
        // We no longer need the quad.
        Destroy(menuBG);
        // Unpause the game.
        Time.timeScale = 1f;
        Debug.Log("RESUME");
    }

    void OnGUI() {
        // You can use whatever you want for the menu UI, this is a simple example solution
        // though.
        if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 35, 100, 30),
                      "Resume")) {
            this.enabled = false;
        }
        if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 30),
                      "Quit Game")) {
            // Just doing this check to show the button was pressed since Application.Quit()
            // doesn't have an effect in the editor.
            if(Application.isEditor)
                Debug.Log("'Quit Game' button clicked!");
            Application.Quit();
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.M)) {
            // Toggle the menu.
            this.enabled = !this.enabled;
        }
    }
}
