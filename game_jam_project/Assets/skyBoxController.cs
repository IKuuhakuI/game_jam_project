/*
 * 
 * Mudar a variável que pula o tempo baseado no dano para velocidade
 * Multiplicar a velocidade por t
 * 
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyBoxController : MonoBehaviour
{

    public float maxOpacity, minimumOpacity;
    public float duration; //seconds
    private float startTime;
    public float danoPulaTempo;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(danoAceleraTempo);
        float t = (Time.time - startTime + danoPulaTempo) / duration; //olhe o cabeçalho ali encima
        Debug.Log(t);
        Debug.Log((Time.time - startTime) / duration);
        sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maxOpacity, minimumOpacity, t)); //selecione a cor aqui
    }
}
