using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler GameControl;
    public bool Lose = false;
    private void Awake()
    {
        Lose = false;
        GameControl = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Lose = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Lose == true)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
