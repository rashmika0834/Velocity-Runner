using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum ControlType { HumanInput};
    public ControlType controlType = ControlType.HumanInput;

    public float BestLaptime {  get; private set; } = Mathf.Infinity;
    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;

    public int CurrentLap { get; private set; } = 0;

    public float Laptimer;
    private int lastCheckpointPassed = 0;

    private Transform checkpointsParent;
    private int checkpointsCount;
    private int checkpointLayer;
    private Wheels carController;

    void Awake()
    {
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointsCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        carController = GetComponent<Wheels>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
