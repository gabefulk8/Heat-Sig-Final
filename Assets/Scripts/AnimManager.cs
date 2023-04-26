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

    public GameObject mineFlare;
    public GameObject towerLight;
    public GameObject cabinLight;
    public GameObject boatLight;
    public GameObject campLight;

    public GameObject mineText;
    public GameObject towerText;
    public GameObject cabinText;
    public GameObject boatText;
    public GameObject campText;

    public AudioSource playerAudio;

    //Monster Babies Patrols
    public GameObject patrols;

    public AudioClip huntaudio;

    public GameObject huntText;

    void Update()
    {
        if (minePlayed == false && Vector3.Distance(this.transform.position, mineFlare.transform.position) < 3) //Mine Animation Trigger
        {
            mineText.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                playMineAnim();
            }
        } else {
            mineText.SetActive(false);
        }

        if (cabinPlayed == false && Vector3.Distance(this.transform.position, cabinLight.transform.position) < 3) //Cabin Animation Trigger
        {
            cabinText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playCabinAnim();
            }
        } else {
            cabinText.SetActive(false);
        }

        if (rangerPlayed == false && Vector3.Distance(this.transform.position, towerLight.transform.position) < 3) //Ranger Animation Trigger
        {
            towerText.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                playRangerAnim();
            }
        } else {
            towerText.SetActive(false);
        }

        if (shipPlayed == false && Vector3.Distance(this.transform.position, boatLight.transform.position) < 3) //Ship Animation Trigger
        {
            boatText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playShipAnim();
            }
        } else {
            boatText.SetActive(false);
        }

        if (campPlayed == false && Vector3.Distance(this.transform.position, campLight.transform.position) < 3) //Camp Animation Trigger
        {
            campText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playCampAnim();
            }
        } else {
            campText.SetActive(false);
        }
    }

    public void playMineAnim() //Play Mine Animation
    {
        playerAudio.PlayOneShot(GetComponent<DroneSwap>().toDrone);
        playerAudio.PlayDelayed(0.6f);
        mainCam.SetActive(false);
        mineCam.SetActive(true);
        RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
        GetComponent<DroneSwap>().ThermalsON();
        tempCam = mineCam;
        mineAnimator.SetTrigger("PlayMineAnim");
        minePlayed = true;
        GetComponent<GPS>().locations[0].text = "<s>816, 489<s>";
        RenderSettings.fogColor = Color.white;
        GetComponent<GPS>().QuarryScanned = true;
        Invoke("ToMainCam", 7f);        
    }

    void playCabinAnim() //Play Cabin Animation
    {
        playerAudio.PlayOneShot(GetComponent<DroneSwap>().toDrone);
        playerAudio.PlayDelayed(0.6f);
        mainCam.SetActive(false);
        cabinCam.SetActive(true);
        RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
        GetComponent<DroneSwap>().ThermalsON();
        tempCam = cabinCam;
        cabinAnimator.SetTrigger("PlayCabinAnim");
        cabinPlayed = true;
        GetComponent<GPS>().locations[2].text = "<s>-791, 90<s>";
        RenderSettings.fogColor = Color.white;
        GetComponent<GPS>().CabinScanned = true;
        patrols.SetActive(true);

        Invoke("ToMainCam", 7f);
    }

    void playRangerAnim() //Play Ranger Animation
    {
        playerAudio.PlayOneShot(GetComponent<DroneSwap>().toDrone);
        playerAudio.PlayDelayed(0.6f);
        mainCam.SetActive(false);
        rangerCam.SetActive(true);
        RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
        GetComponent<DroneSwap>().ThermalsON();
        tempCam = rangerCam;
        rangerAnimator.SetTrigger("PlayRangerAnim");
        rangerPlayed = true;
        GetComponent<GPS>().locations[1].text = "<s>819, -546<s>";
        RenderSettings.fogColor = Color.white;
        GetComponent<GPS>().RangerScanned = true;
        patrols.SetActive(true);
        huntText.SetActive(true);
        Invoke("ToMainCam", 7f);
    }

    void playShipAnim() //Play Ship Animation
    {
        playerAudio.PlayOneShot(GetComponent<DroneSwap>().toDrone);
        playerAudio.PlayDelayed(0.6f);
        mainCam.SetActive(false);
        shipCam.SetActive(true);
        RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
        GetComponent<DroneSwap>().ThermalsON();
        tempCam = shipCam;
        shipAnimator.SetTrigger("PlayShipAnim");
        shipPlayed = true;
        GetComponent<GPS>().locations[3].text = "<s>-857, -285<s>";
        RenderSettings.fogColor = Color.white;
        GetComponent<GPS>().BoatScanned = true;
        patrols.SetActive(true);

        Invoke("ToMainCam", 7f);
    }

    void playCampAnim() //Play Camp Animation
    {
        playerAudio.PlayOneShot(GetComponent<DroneSwap>().toDrone);
        playerAudio.PlayDelayed(0.6f);
        mainCam.SetActive(false);
        campCam.SetActive(true);
        RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
        GetComponent<DroneSwap>().ThermalsON();
        tempCam = campCam;
        campAnimator.SetTrigger("PlayCampAnim");
        campPlayed = true;
        GetComponent<GPS>().locations[4].text = "<s>1694, -436<s>";
        RenderSettings.fogColor = Color.white;
        GetComponent<GPS>().CampScanned = true;
        patrols.SetActive(true);

        Invoke("ToMainCam", 7f);
    }

    void ToMainCam()
    {
        playerAudio.PlayOneShot(GetComponent<DroneSwap>().fromDrone);
        Invoke("Check", 1f);
        playerAudio.Stop();
        playerAudio.PlayOneShot(GetComponent<DroneSwap>().fromDrone);
        tempCam.SetActive(false);
        RenderSettings.ambientLight = new Color(0.227451f, 0.227451f, 0.227451f);
        RenderSettings.fogColor = Color.black;

        GetComponent<DroneSwap>().ThermalsOFF();

        mainCam.SetActive(true);
    }

    public void Check()
    {
        GetComponent<GPS>().source1.PlayOneShot(GetComponent<GPS>().checkmark);
    }
}