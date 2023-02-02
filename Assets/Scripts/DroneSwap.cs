using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneSwap : MonoBehaviour
{
    public GameObject mainCam;      //set this in editor
    public GameObject droneCam;     //set this in editor
    public CharacterController charCont;    //put this script on the player and it should find the character controller
    public int camState;  // 0 is main cam. 1 is drone cam
    public GameObject mouseScript;

    public Material[] materials;    //different materials for the monster. 0 is default, 1 is thermal
    public Renderer rend;       //renderer on the monster


    private InputAction playerControls;


    void Start()
    {
        charCont = this.GetComponent<CharacterController>();
        camState = 0;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && camState == 0) //go to drone cam
        {
            ToDrone();
            camState = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Q) && camState == 1) //go to main cam
        {
            ToMain();
            camState = 0;
        }
    }

    void ToMain()
    {
        //enable movement, swap to main camera
        droneCam.SetActive(false);
        mainCam.SetActive(true);

        RenderSettings.fogColor = Color.black;

        charCont.enabled = true;

        rend.sharedMaterial = materials[0]; //default monster material

        mouseScript.SetActive(true);
    }

    void ToDrone()
    {
        //disable movement, swap to drone camera
        mainCam.SetActive(false);
        droneCam.SetActive(true);

        RenderSettings.fogColor = Color.white;

        charCont.enabled = false;

        rend.sharedMaterial = materials[1];
        mouseScript.SetActive(false);
    }
}