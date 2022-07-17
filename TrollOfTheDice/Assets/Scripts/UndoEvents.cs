using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UndoEvents : MonoBehaviour {
    public UnityEvent addMoveStateEvent;
    public UnityEvent undoLastMoveEvent;

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
