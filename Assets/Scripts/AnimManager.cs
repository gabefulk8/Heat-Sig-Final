using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public Animator mineAnimator;
    public Animator cabinAnimator;
    public Animator rangerAnimator;
    public Animator shipAnimator;
    public Animator campAnimator;

    public GameObject mainCam;
    public GameObject mineCam;
    public GameObject cabinCam;
    public GameObject rangerCam;
    public GameObject shipCam;
    public GameObject campCam;

    GameObject tempCam;

    public bool minePlayed = false;
    public bool cabinPlayed = false;
    public bool rangerPlayed = false;
    public bool shipPlayed = false;
    public bool campPlayed = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && minePlayed == false) //Mine Animation Trigger
        {
            mainCam.SetActive(false);
            mineCam.SetActive(true);
            RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
            playMineAnim();
        }

        if (Input.GetKeyDown(KeyCode.U) && cabinPlayed == false) //Cabin Animation Trigger
        {
            mainCam.SetActive(false);
            cabinCam.SetActive(true);
            RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
            playCabinAnim();
        }

        if (Input.GetKeyDown(KeyCode.I) && rangerPlayed == false) //Ranger Animation Trigger
        {
            mainCam.SetActive(false);
            rangerCam.SetActive(true);
            RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
            playRangerAnim();
        }

        if (Input.GetKeyDown(KeyCode.O) && shipPlayed == false) //Ship Animation Trigger
        {
            mainCam.SetActive(false);
            shipCam.SetActive(true);
            RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
            playShipAnim();
        }

        if (Input.GetKeyDown(KeyCode.P) && campPlayed == false) //Camp Animation Trigger
        {
            mainCam.SetActive(false);
            campCam.SetActive(true);
            RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
            playCampAnim();
        }
    }

    void playMineAnim() //Play Mine Animation
    {
        GetComponent<DroneSwap>().ThermalsON();
        tempCam = mineCam;
        mineAnimator.SetTrigger("PlayMineAnim");
        minePlayed = true;

        RenderSettings.fogColor = Color.white;

        Invoke("ToMainCam", 7f);        
    }

    void playCabinAnim() //Play Cabin Animation
    {
        GetComponent<DroneSwap>().ThermalsON();
        tempCam = cabinCam;
        cabinAnimator.SetTrigger("PlayCabinAnim");
        cabinPlayed = true;

        RenderSettings.fogColor = Color.white;

        Invoke("ToMainCam", 7f);
    }

    void playRangerAnim() //Play Ranger Animation
    {
        GetComponent<DroneSwap>().ThermalsON();
        tempCam = rangerCam;
        rangerAnimator.SetTrigger("PlayRangerAnim");
        rangerPlayed = true;

        RenderSettings.fogColor = Color.white;

        Invoke("ToMainCam", 7f);
    }

    void playShipAnim() //Play Ship Animation
    {
        GetComponent<DroneSwap>().ThermalsON();
        tempCam = shipCam;
        shipAnimator.SetTrigger("PlayShipAnim");
        shipPlayed = true;

        RenderSettings.fogColor = Color.white;

        Invoke("ToMainCam", 7f);
    }

    void playCampAnim() //Play Camp Animation
    {
        GetComponent<DroneSwap>().ThermalsON();
        tempCam = campCam;
        campAnimator.SetTrigger("PlayCampAnim");
        campPlayed = true;

        RenderSettings.fogColor = Color.white;

        Invoke("ToMainCam", 7f);
    }

    void ToMainCam()
    {
        tempCam.SetActive(false);
        RenderSettings.ambientLight = new Color(0.227451f, 0.227451f, 0.227451f);
        RenderSettings.fogColor = Color.black;

        GetComponent<DroneSwap>().ThermalsOFF();

        mainCam.SetActive(true);
    }
}