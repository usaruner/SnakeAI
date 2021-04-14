using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum scenes{
	Init,
	Menu,
	Info,
	Game_Start,
	Game_End
}
public class MainManager : MonoBehaviour
{
	public int HighScore = 0;
	public scenes Scenes = scenes.Init;
    // Start is called before the first frame update
    void Start()
    {
        Scenes = scenes.Menu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
