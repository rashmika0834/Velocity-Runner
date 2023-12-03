using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum ControlType { HumanInput, AI};
    public ControlType controlType = ControlType.HumanInput;

    public float BestLaptime {  get; private set; } = Mathf.Infinity;
    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;

    public int CurrentLap { get; private set; } = 0;

    public float lapTimerTimestamp;
    private int lastCheckpointPassed = 0;

    private Transform checkpointsParent;
    private int checkpointsCount;
    private int checkpointLayer;
    private Car carController;

    void Awake()
    {
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointsCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoints");
        carController = GetComponent<Car>();
    }

    void StartLap()
    {
        Debug.Log("StartLap!");
        CurrentLap++;
        lastCheckpointPassed = 1;
        lapTimerTimestamp = Time.time; 
    }

    void EndLap()
    {
        LastLapTime = Time.time - lapTimerTimestamp;
        BestLaptime = Mathf.Min(LastLapTime, BestLaptime);
        Debug.Log("EndLap - LapTime was " + LastLapTime + "seconds");
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer != checkpointLayer)
        {
            return;
        }

        if(collider.gameObject.name == "1")
        {
            if(lastCheckpointPassed == checkpointsCount)
            {
                EndLap();
            }

            if(CurrentLap == 0 || lastCheckpointPassed == checkpointsCount)
            {
                StartLap();
            }
            return;
        }

        if(collider.gameObject.name == (lastCheckpointPassed + 1).ToString())
        {
            lastCheckpointPassed++; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLapTime = lapTimerTimestamp > 0 ? Time.time - lapTimerTimestamp : 0;

        if (controlType == ControlType.HumanInput)
        {
            carController.Steer = GameManager.Instance.InputController.SteerInput;
            carController.Throttle = GameManager.Instance.InputController.ThrottelInput;
        }
        
    }
}
