using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ViewOption { Normal, Delayed, Predicted}

public class GameManager : MonoBehaviour
{
    [Header("For Different Views")]
    public GameObject mainCamera;
    public GameObject delayedCamera;
    public GameObject delayedCameraPublisher;
    public GameObject robotController;
    public bool automated = false;
    public float turnTime = 35f; 
    public float delay = 1f;

    [Header("UI Elements")]
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI delayText;
    public GameObject reconstructionDoneButton;

    //CONSTS
    private const string VIEW_KEY = "viewOption";
    

    [Header("Private Vars")]
    private bool playing;
    private bool leftTurnFlag;
    private float timer;
    private ViewOption viewOption;
    private RosSharp.RosBridgeClient.ImagePublisherDelayed delayedCameraPublisherScript; 


    private void Awake()
    {
        // get option and convert to enum
        string viewOptionString = PlayerPrefs.GetString(VIEW_KEY, "Normal");
        viewOption = (ViewOption)System.Enum.Parse(typeof(ViewOption), viewOptionString);
        

        // disable and enable objects accordingly
        // delayed 
        if (viewOption == ViewOption.Normal)
        {
            // Toggle views
            Debug.Log("Normal View");
            delayedCamera.SetActive(false);
            delayedCameraPublisher.SetActive(false);

            // display delay (none)
            delayText.text = "Delay: None";

            // Toggle UI
            reconstructionDoneButton.SetActive(false);
        }
        else if (viewOption == ViewOption.Delayed)
        {
            // Toggle views
            Debug.Log("Delayed View");
            delayedCamera.SetActive(true);
            delayedCameraPublisher.SetActive(false);

            // Update and display delay
            delayText.text = "Delay: " + delay.ToString("0.0") + "s";
            delayedCamera.GetComponent<DelayedCamera>().delay = delay;

            // Toggle UI
            reconstructionDoneButton.SetActive(false);
        }
        else if (viewOption == ViewOption.Predicted)
        {
            // Toggle views
            Debug.Log("Predicted View");
            delayedCamera.SetActive(false);
            delayedCameraPublisher.SetActive(true);

            // update and display delay
            delayText.text = "Delay: " + delay.ToString("0.0") + "s";
            delayedCameraPublisherScript = delayedCameraPublisher.GetComponent<RosSharp.RosBridgeClient.ImagePublisherDelayed>();
            delayedCameraPublisherScript.delay = delay;

            // Toggle UI
            reconstructionDoneButton.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // start flag
        playing = true;
        leftTurnFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        // update timer
        if (playing)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer % 60F);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            Debug.Log("Timer: " + timerText.text);

            if (timer > turnTime && leftTurnFlag && automated)
            {
                Debug.Log("Turned left");
                robotController.GetComponent<RobotController>().autoRotateSpeed *= -1;
                leftTurnFlag = false;
                OnClickReconstructionDone();
            }
        }


        //Debug.Log(mainCamera.transform.position);
        //Debug.Log("X:" + mainCamera.transform.rotation.x);
        //Debug.Log("Y:" + mainCamera.transform.rotation.y);
        //Debug.Log("Z:" + mainCamera.transform.rotation.z);
        //Debug.Log(mainCamera.GetComponent<Camera>().projectionMatrix);
        //Debug.Log(mainCamera.GetComponent<Camera>().worldToCameraMatrix);
    }


    // UI Button Functions
    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void OnClickNormalView()
    {
        PlayerPrefs.SetString(VIEW_KEY, ViewOption.Normal.ToString());
        ReloadScene();
    }

    public void OnClickDelayedView()
    {
        PlayerPrefs.SetString(VIEW_KEY, ViewOption.Delayed.ToString());
        ReloadScene();
    }

    public void OnClickPredictedView()
    {
        PlayerPrefs.SetString(VIEW_KEY, ViewOption.Predicted.ToString());
        ReloadScene();
    }

    // for sending images in spurts after initial reconstruction done
    public void OnClickReconstructionDone()
    {
        delayedCameraPublisherScript.reconstructionDone = true;
        reconstructionDoneButton.SetActive(false);
        delayText.text += "\n(sending in spurts)";
    }


}
