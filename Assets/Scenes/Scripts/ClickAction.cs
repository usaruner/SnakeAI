using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
public class ClickAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Change_to_Play(){
    	SceneManager.LoadScene("Play");
    }
    public void Change_to_Lose()
    {
        SceneManager.LoadScene("Lose");
    }
}
