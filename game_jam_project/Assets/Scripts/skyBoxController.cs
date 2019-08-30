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
using UnityEngine.Experimental.Rendering.LWRP;

public class skyBoxController : MonoBehaviour
{

    public float maxOpacity, minimumOpacity, timer1, timer2, timer3, timer4, minIntensity, sunStart, sunEnd, moonStart, moonEnd;
    public float duration; //seconds
    private float startTime, t, t2;
    public float danoPulaTempo;
    public SpriteRenderer spriteDay, spriteNoon, cloudDay, cloudNoon;
    public GameObject player, controller, globalLight, sun, moon;
    private float pdt, third;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        duration = player.GetComponent<playerController>().timeToDeath;
        third = duration / 3;
    }

    // Update is called once per frame
    void Update()
    {
        pdt = player.GetComponent<playerController>().deathTimer;
        //Debug.Log(danoAceleraTempo);
        //float t = (Time.time - startTime + danoPulaTempo) / duration; //olhe o cabeçalho ali encima
        //Debug.Log(t);
        //Debug.Log((Time.time - startTime) / duration);
        if (player.GetComponent<playerController>().phase==1)
        {
            pdt = (third)- (pdt - (2 * third));
            t = pdt / (third);
            spriteDay.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maxOpacity, minimumOpacity, t)); //selecione a cor aqui
            cloudDay.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maxOpacity, minimumOpacity, t)); //selecione a cor aqui
        }
        else if (player.GetComponent<playerController>().phase == 2)
        {
            pdt = (third) - (pdt - third);
            t = pdt / (third);
            spriteNoon.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maxOpacity, minimumOpacity, t)); //selecione a cor aqui
            cloudNoon.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maxOpacity, minimumOpacity, t)); //selecione a cor aqui
        }
        else if (player.GetComponent<playerController>().phase == 3)
        {
            minIntensity = globalLight.GetComponent<Light2D>().intensity;
            t = (third -pdt) / (third);
            Debug.Log(t);
            globalLight.GetComponent<Light2D>().intensity = Mathf.SmoothStep(minIntensity, 0.001f, t);

        }
        t2 = (duration- player.GetComponent<playerController>().deathTimer) / duration;
        sun.transform.position = new Vector3(Mathf.SmoothStep(sunStart, sunEnd, t2), sun.transform.position.y);
        moon.transform.position = new Vector3(Mathf.SmoothStep(moonStart, moonEnd, t2), moon.transform.position.y);
    }
}
