using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePredictor : MonoBehaviour
{
    [SerializeField] private float minAlpha;
    [SerializeField] private float maxAlpha;
    [SerializeField] private float alphaSpeed;
    private SpriteRenderer sr;
    private bool alphaUp = true;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>(); 
        sr.color = new Color(text.color.r, text.color.g, text.color.b, minAlpha);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sr.color.a <= minAlpha) { alphaUp = true; }
        else if (sr.color.a >= maxAlpha) { alphaUp = false; }

        if (alphaUp) { sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + alphaSpeed); }
        else { sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - alphaSpeed); }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall")) { sr.enabled = false; }
    }

    void OnCollisionExit()
    {
        sr.enabled = true;
    }
}
