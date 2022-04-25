using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RobotManualInput : MonoBehaviour
{
    public GameObject robot;

    private RobotController robotController;
    PlayerControls controls;


    private void Awake()
    {
        //controls = new PlayerControls();

        //controls.ArmMovement.Base.performed += ctx => OnBase();
    }

    private void Start()
    {
        //robotController = robot.GetComponent<RobotController>();
    }

    void Update()
    {
        //for (int i = 0; i < robotController.joints.Length; i++)
        //{
        //    float inputVal = Input.GetAxis(robotController.joints[i].inputAxis);
        //    if (Mathf.Abs(inputVal) > 0)
        //    {
        //        RotationDirection direction = GetRotationDirection(inputVal);
        //        robotController.RotateJoint(i, direction);
        //        return;
        //    }
        //}
        //robotController.StopAllJointRotations();

    }


    


    // HELPERS

    static RotationDirection GetRotationDirection(float inputVal)
    {
        if (inputVal > 0)
        {
            return RotationDirection.Positive;
        }
        else if (inputVal < 0)
        {
            return RotationDirection.Negative;
        }
        else
        {
            return RotationDirection.None;
        }
    }


    // Movements
    public void OnBase()
    {
        //Debug.Log("OnBase() called");
        //robotController.RotateJoint(0, RotationDirection.Positive);
    }

}
