using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotController : MonoBehaviour
{
    // Public vars
    [System.Serializable]
    public struct Joint
    {
        public string inputAxis;
        public GameObject robotPart;
        public float input_val;
    }
    public Joint[] joints;

    

    // Private vars
    PlayerControls controls;
    //PincherController pincherController;
    //float pincher_val;

    public GameObject Magnet;
    private MagnetScript magnetScript;

    [Header("Testing")]
    public bool autoRotate = false;
    public float autoRotateSpeed = -0.05f;




    // FRAME METHODS
    private void Awake()
    {
        controls = new PlayerControls();

        // base 
        controls.ArmMovement.Base.performed += ctx => joints[0].input_val = ctx.ReadValue<float>();
        controls.ArmMovement.Base.canceled += ctx => joints[0].input_val = 0;

        // shoulder
        controls.ArmMovement.Shoulder.performed += ctx => joints[1].input_val = ctx.ReadValue<float>();
        controls.ArmMovement.Shoulder.canceled += ctx => joints[1].input_val = 0;

        // elbow
        controls.ArmMovement.Elbow.performed += ctx => joints[2].input_val = ctx.ReadValue<float>();
        controls.ArmMovement.Elbow.canceled += ctx => joints[2].input_val = 0;

        // Wrist1
        controls.ArmMovement.Wrist1.performed += ctx => joints[3].input_val = ctx.ReadValue<float>();
        controls.ArmMovement.Wrist1.canceled += ctx => joints[3].input_val = 0;

        // Wrist2
        controls.ArmMovement.Wrist2.performed += ctx => joints[4].input_val = ctx.ReadValue<float>();
        controls.ArmMovement.Wrist2.canceled += ctx => joints[4].input_val = 0;

        // Wrist3
        controls.ArmMovement.Wrist3.performed += ctx => joints[5].input_val = ctx.ReadValue<float>();
        controls.ArmMovement.Wrist3.canceled += ctx => joints[5].input_val = 0;

        // Hand
        controls.ArmMovement.Hand.performed += ctx => joints[6].input_val = ctx.ReadValue<float>();
        controls.ArmMovement.Hand.canceled += ctx => joints[6].input_val = 0;

        //controls.ArmMovement.Fingers.performed += ctx => pincher_val = ctx.ReadValue<float>();
        //controls.ArmMovement.Fingers.canceled += ctx => pincher_val = 0;

        // Magnet
        controls.Magnet.Attract.performed += _ => EnableAttraction();
        controls.Magnet.Stop.performed += _ => DisableAttraction();

    }

    private void Start()
    {
        //// get tool
        //pincherController = joints[6].robotPart.GetComponent<PincherController>();
        magnetScript = Magnet.GetComponent<MagnetScript>();
    }

    private void Update()
    {
        for (int i = 0; i < joints.Length; i++)
        {
            // Auto rotation for testing
            if (i == 0 && autoRotate)
            {
                RotationDirection direction = GetRotationDirection(autoRotateSpeed);
                RotateJoint(i, direction, Mathf.Abs(autoRotateSpeed));
                return;
            }

            if (Mathf.Abs(joints[i].input_val) > 0)
            {
                Debug.Log(joints[i].input_val);
                RotationDirection direction = GetRotationDirection(joints[i].input_val);
                RotateJoint(i, direction, Mathf.Abs(joints[i].input_val));
                return;
            }
        }
        StopAllJointRotations();

        //pincherController.gripState = GripStateForInput(pincher_val);
    }

    private void OnEnable()
    {
        controls.ArmMovement.Enable();
        controls.Magnet.Enable();
    }

    private void OnDisable()
    {
        controls.ArmMovement.Disable();
        controls.Magnet.Disable();
    }


    // CONTROL

    public void StopAllJointRotations()
    {
        for (int i = 0; i < joints.Length; i++)
        {
            GameObject robotPart = joints[i].robotPart;
            //joints[i].input_val = 0;
            UpdateRotationState(RotationDirection.None, robotPart, 1);
        }
    }

    public void RotateJoint(int jointIndex, RotationDirection direction, float speed)
    {
        StopAllJointRotations();
        Joint joint = joints[jointIndex];
        UpdateRotationState(direction, joint.robotPart, speed);
    }

    private void EnableAttraction()
    {
        magnetScript.inputGiven = true;
    }

    private void DisableAttraction()
    {
        magnetScript.inputGiven = false;
    }


    // HELPERS

    static void UpdateRotationState(RotationDirection direction, GameObject robotPart, float speed)
    {
        ArticulationJointController jointController = robotPart.GetComponent<ArticulationJointController>();
        jointController.rotationState = direction;
        jointController.speed = (float)50.0 * speed;
    }

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

    static GripState GripStateForInput(float input)
    {
        if (input > 0)
        {
            return GripState.Closing;
        }
        else if (input < 0)
        {
            return GripState.Opening;
        }
        else
        {
            return GripState.Fixed;
        }
    }


}
