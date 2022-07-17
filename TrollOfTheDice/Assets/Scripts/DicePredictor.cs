using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePredictor : MonoBehaviour
{
    [SerializeField] private float minAlpha;
    [SerializeField] private float maxAlpha;
    [SerializeField] private float alphaSpeed;
    [SerializeField] private LayerMask wallLayer;

    private SpriteRenderer sr;
    private bool alphaUp = true;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, minAlpha);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sr.color.a <= minAlpha) { alphaUp = true; }
        else if (sr.color.a >= maxAlpha) { alphaUp = false; }

        if (alphaUp) { sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + alphaSpeed); }
        else { sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - alphaSpeed); }
    }

    void Update()
    {
        /*if (Physics.Raycast(transform.position, new Vector3(0, 0, -1), 2f, wallLayer))
        {
            Debug.Log("here");
            sr.enabled = false;
        }
        else { sr.enabled = true; }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("here");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall")) { sr.enabled = false; }
    }

    void OnTriggerExit()
    {
        sr.enabled = true;
    }
}
