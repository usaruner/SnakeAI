using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
public class HighScore : Agent
{
     
    public Vector2Int bodypos;
    public int changex;
    public int changey;
    private bool x ;
    public enum Direction { up, down, left, right };
    public Direction direction;
    private Vector3 moveDir;
    private GameObject target;
    public bool repress;
    public float timeLeft;
    public List<GameObject> walls;
    public List<GameObject> food;
    public int rewardmult;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "wall")
        {
            reward(-5);
            EndEpisode();
        }
        if (collider.tag == "food")
        {
            foody food = collider.gameObject.GetComponent<foody>();
            food.Move();
            reward(2*rewardmult);
            rewardmult++;
        }

    }
    // Start is called before the first frame update

    public override void OnEpisodeBegin()
    {
        changex = 0;
        changey = 1;
        repress = true;
        timeLeft= 0;
        rewardmult = 1;
        x = false;
        this.transform.localPosition = Vector3.zero;
    }
    public override void CollectObservations(VectorSensor sensor){
        /*
        sensor.AddObservation(transform.localPosition);
        foreach (GameObject berry in food)
        {
            //Debug.Log(berry.name);
            target = berry;
            sensor.AddObservation(berry.transform.localPosition);
        }
        foreach (GameObject walle in walls)
        {
            //Debug.Log(walle.name);
            sensor.AddObservation(walle.transform.localPosition);
        }
        */
        sensor.AddObservation(changey);
        sensor.AddObservation(changex);
        sensor.AddObservation(transform.localPosition);
        foreach (GameObject berry in food)
        {
            //Debug.Log(berry.name);
            target = berry;
            sensor.AddObservation(berry.transform.localPosition);
            sensor.AddObservation(Mathf.Abs(Vector3.Distance(berry.transform.localPosition, transform.localPosition)));
        }
        foreach (GameObject walle in walls)
        {
            //Debug.Log(walle.name);
            sensor.AddObservation(walle.transform.localPosition);
            sensor.AddObservation(Mathf.Abs(Vector3.Distance(walle.transform.localPosition, transform.localPosition)));
        }
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> Caction = actionsOut.ContinuousActions;
        Caction[0] = Input.GetAxisRaw("Horizontal");    
    }
    public void reward(float gift)
    {
        //Debug.Log(Mathf.Abs(Vector3.Distance(target.transform.localPosition, this.transform.localPosition)));
        SetReward(gift);
        
    }
    public override void  OnActionReceived(ActionBuffers actions)
    {
        int move = (int)actions.ContinuousActions[0];
        if (Mathf.Clamp(move, -1, 1) != 0 && repress)
        {
            if (x)
            {
                transform.Rotate(Vector3.forward * (-1 * Mathf.Clamp(move, -1, 1) * 90 ));
                changey = -1 * Mathf.Clamp(move, -1, 1) * changex;
                changex = 0;
                x = false;

            }
            else
            {
                transform.Rotate(Vector3.forward * (-1 * Mathf.Clamp(move, -1, 1) * 90 ));
                changex = Mathf.Clamp(move, -1, 1) * changey;
                changey = 0;
                x = true;
            }
            repress = false;
            timeLeft = 0.25f;
        }
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            repress = true;
        }
        Vector3 moveDir = new Vector3(changex, changey);
        transform.position += moveDir * 2f * Time.deltaTime;

    }
}

