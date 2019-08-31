using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public int maxNumberofEnemies, currentNumberofEnemies;
    public GameObject endUI, gameAudioSource;
    public bool isOver;
    // Start is called before the first frame update
    void Start()
    {
        currentNumberofEnemies = 0;
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOver && endUI.activeSelf)
        {
            isOver = true;
            gameAudioSource.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown("f") && endUI.activeSelf)
        {
            SceneManager.LoadScene(1);
        }
    }
}
