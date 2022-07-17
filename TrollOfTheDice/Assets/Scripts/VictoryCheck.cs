using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCheck : MonoBehaviour
{
    [SerializeField] private TileVariables[] winners;
    [SerializeField] private string nextScene;

    private AudioSource winSound;

    private void Start() {
        winSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void CheckIfWin()
    {
        for (int i = 0; i < winners.Length; i++)
        {
            if (!winners[i].IsActive) { return; }
        }

        StartCoroutine(Win());
    }

    private IEnumerator Win()
    {
        winSound.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextScene);
    }
}
