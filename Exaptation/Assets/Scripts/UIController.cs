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
            int rand = Random.Range(0, 15);

            switch (rand)
            {
                case 0: currentMood = "Agglomerated"; break;
                case 1: currentMood = "Dubious"; break;
                case 2: currentMood = "Enthused"; break;
                case 3: currentMood = "Meritocratic"; break;
                case 4: currentMood = "Perturbed"; break;
                case 5: currentMood = "Wistful"; break;
                case 6: currentMood = "Contemplative"; break;
                case 7: currentMood = "Irritated"; break;
                case 8: currentMood = "Ultra-Pensive"; break;
                case 9: currentMood = "Melancholy"; break;
                case 10: currentMood = "Glowering"; break;
                case 11: currentMood = "Duplicitous"; break;
                case 12: currentMood = "Detroit"; break;
                case 13: currentMood = "Pondering"; break;
                case 14: currentMood = "Ruminant"; break;
            }
        }

        for (int i = 0; i < panels.Length; i++) { panels[i].UpdateText(); }
    }
}
