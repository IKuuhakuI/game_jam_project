using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public float timeStartSC; //seconds
    public float readingTime, timer;
    public bool started;
    public int currentScene;
    public GameObject cutSceneObj;
    public GameObject[] scenes;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        currentScene = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !started)
        {
            started = true;
            timeStartSC = Time.time;
            Debug.Log(timeStartSC);
            Debug.Log("AAAAA");
            cutSceneObj.SetActive(true);

            cutScene();

            //SceneManager.LoadScene(1);

        }
        if (started)
        {
            cutScene();
        }

        //cutScene();
    }

    void cutScene()
    {
        timer += Time.deltaTime;
        if (timer >= readingTime && currentScene <= 13)
        {

            timer = 0;
            scenes[currentScene - 1].SetActive(false);
            currentScene++;
        } else if (currentScene > 13 && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(1);
        }
    }
    void cutScene2()
    {
        Debug.Log(Time.time);
        cutSceneObj.SetActive(true);
        if((Time.time > (timeStartSC + 8) && started))
        {
            //Debug.Log(scenes[currentScene]);
            Debug.Log("entrou if");
            scenes[currentScene-1].SetActive(false);
            currentScene++;
        }

    }
}
