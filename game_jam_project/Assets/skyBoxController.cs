using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyBoxController : MonoBehaviour
{

    public float maxOpacity, minimumOpacity;
    public float duration; //seconds
    private float startTime;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maxOpacity, minimumOpacity, t)); //selecione a cor aqui
    }
}
