using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreKeeper : MonoBehaviour
{
    public int highScore;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        highScore = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
