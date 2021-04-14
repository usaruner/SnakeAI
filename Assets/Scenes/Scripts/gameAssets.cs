using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameAssets : MonoBehaviour
{
	public static gameAssets i;
    public Sprite snakeHeadSprite;
    public Sprite Berries;
    public Sprite body;
    private void Awake(){
    	i = this;
    }
}
