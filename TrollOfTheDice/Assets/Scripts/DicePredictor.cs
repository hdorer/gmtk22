using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePredictor : MonoBehaviour
{
    [SerializeField] private float minAlpha;
    [SerializeField] private float maxAlpha;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
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
