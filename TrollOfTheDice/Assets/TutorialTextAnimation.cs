using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialTextAnimation : MonoBehaviour
{
    [SerializeField] private float startDelay;
    [SerializeField] private float popInTime;
    [SerializeField] private float remainTime;
    [SerializeField] private float popOutTime;
    [SerializeField] private float alphaSpeed;

    private string state = "delay";
    private float timeInState = 0;

    private Image i;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        i = this.gameObject.GetComponent<Image>();
        text = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeInState++;

        if (state == "pop in")
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a+alphaSpeed);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a+alphaSpeed);

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y +1, gameObject.transform.position.z);
        }

        if (state == "pop out")
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a- alphaSpeed);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a- alphaSpeed);

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
        }

        else if (timeInState > startDelay && state == "delay")
        {
            state = "pop in";
            timeInState = 0;
        }
        else if (timeInState > popInTime && state == "pop in")
        {
            state = "remain";
            timeInState = 0;
        }
        else if (timeInState > remainTime && state == "remain")
        {
            state = "pop out";
            timeInState = 0;
        }
        else if (timeInState > remainTime && state == "pop out")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }
}
