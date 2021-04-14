using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foody: MonoBehaviour
{
    private void Awake()
    {
    }
    void Start()
    {
        this.transform.localPosition = new Vector3(Random.Range(-24f, 24f), Random.Range(-9f, 9f), 0);
    }

    public void Move()
    {
        this.transform.localPosition = new Vector3(Random.Range(-24f, 24f), Random.Range(-9f, 9f), 0);
    }
}
