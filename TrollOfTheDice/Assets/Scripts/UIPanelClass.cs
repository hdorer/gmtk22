using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPanelClass : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private string panelType;
    private UIController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("MainUI").GetComponent<UIController>();
        text = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

        UpdateText();
    }

    public void UpdateText()
    {
        if (controller != null)
        {
            if (panelType == "turns") { text.text = "Current Turn: " + controller.CurrentTurn.ToString(); }
        }
        else { Debug.Log("ERROR: UI controller not found!!"); }
    }
}
