using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIPanelClass[] panels;
    private int currentTurn = 0;
    public int CurrentTurn { get { return currentTurn; } }
    private string levelName = "Pensive";
    public string LevelName { get { return levelName; } }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void AddTurn()
    {
        currentTurn++;

        for (int i = 0; i < panels.Length; i++) { panels[i].UpdateText(); }
    }

    public void SubtractTurn()
    {
        if (currentTurn > 0) { currentTurn--; }

        for (int i = 0; i < panels.Length; i++) { panels[i].UpdateText(); }
    }
}
