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

        if (currentTurn % 3 == 0)
        {
            int rand = Random.Range(0, 5);
            switch (rand)
            {
                case 0: currentMood = "Agglomerated"; break;
                case 1: currentMood = "Dubious"; break;
                case 2: currentMood = "Enthused"; break;
                case 3: currentMood = "Meritocratic"; break;
                case 4: currentMood = "Perturbed"; break;
            }
        }

        for (int i = 0; i < panels.Length; i++) { panels[i].UpdateText(); }
    }
}
