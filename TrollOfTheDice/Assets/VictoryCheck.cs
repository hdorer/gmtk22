using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCheck : MonoBehaviour
{
    [SerializeField] private TileVariables[] winners;
    [SerializeField] private string nextScene;

    // Start is called before the first frame update
    public void CheckIfWin()
    {
        for (int i = 0; i < winners.Length; i++)
        {
            if (!winners[i].IsActive) { return; }
        }

        Win();
    }

    public void Win()
    {
        SceneManager.LoadScene(nextScene);
    }
}
