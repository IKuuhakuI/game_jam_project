using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    private float gameplayTime;
    private float timeRemaining;
    private float rotationPointer;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameplayTime = GameObject.Find("player").GetComponent<playerController>().timeToDeath;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining = player.GetComponent<playerController>().deathTimer;
        rotationPointer = (((timeRemaining / gameplayTime) * 360) -270);
        Debug.Log(rotationPointer);
        gameObject.GetComponentInChildren<RectTransform>().rotation = Quaternion.Euler(0f, 0f, rotationPointer);

    }
}
