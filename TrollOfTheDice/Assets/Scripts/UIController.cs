using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIPanelClass[] panels;
    private int currentTurn = 0;
    public int CurrentTurn { get { return currentTurn; } }
    private string currentMood = "Pensive";
    public string CurrentMood { get { return currentMood; } }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void AddTurn()
    {
        currentTurn++;

        for (int i = 0; i < panels.Length; i++) { panels[i].UpdateText(); }
    }

    public void SubtractTurn() {
        if (currentTurn > 0) { currentTurn--; }
        for (int i = 0; i < panels.Length; i++) { panels[i].UpdateText(); }
    }
}
