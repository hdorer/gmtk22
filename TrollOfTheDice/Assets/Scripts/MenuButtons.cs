using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {
    [SerializeField] RectTransform indicator;
    [SerializeField] RectTransform[] options;
    int selectedOption = 0;

    float oldVertical;

    private void Update() {
        float vertical = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0)) {
            if(selectedOption == 0) {
                MenuButton();
            } else if(selectedOption == 1) {
                QuitButton();
            }
        }

        if(verticalDown(vertical)) {
            if(vertical > 0) {
                selectedOption--;
                if(selectedOption < 0) {
                    selectedOption = options.Length - 1;
                }
            } else if(vertical < 0) {
                selectedOption++;
                if(selectedOption >= options.Length) {
                    selectedOption = 0;
                }
            }
        }

        indicator.position = options[selectedOption].position;

        oldVertical = vertical;
    }

    // Start is called before the first frame update
    public void MenuButton() {
        SceneManager.LoadScene("Level1");
    }

    public void QuitButton() {
        Application.Quit();
    }

    private bool verticalDown(float vertical) {
        if(vertical != 0 && oldVertical == 0) {
            return true;
        }
        return false;
    }
}
