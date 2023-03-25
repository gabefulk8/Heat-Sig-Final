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
    public Renderer quarryFlareRenderer;
    public Renderer cabinLampRenderer;
    public Renderer towerLampRenderer;
    public Renderer boatLampRenderer;
    public Renderer campLampRenderer;
    public Material[] guidanceMats; // 0 is thermal, 1 flare, 2 lamp

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
        RenderSettings.ambientLight = new Color(0.227451f, 0.227451f, 0.227451f);

        charCont.enabled = true;

        ThermalsOFF();

        mouseScript.SetActive(true);
    }

    void ToDrone()
    {
        //disable movement, swap to drone camera
        mainCam.SetActive(false);
        droneCam.SetActive(true);

        RenderSettings.fogColor = Color.white;
        RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);

        charCont.enabled = false;

        ThermalsON();
        
        mouseScript.SetActive(false);
    }

    public void ThermalsON()
    {
        rend.sharedMaterial = materials[1];
        quarryFlareRenderer.sharedMaterial = guidanceMats[0];
        campLampRenderer.sharedMaterial = guidanceMats[0];
        towerLampRenderer.sharedMaterial = guidanceMats[0];
        boatLampRenderer.sharedMaterial = guidanceMats[0];
        cabinLampRenderer.sharedMaterial = guidanceMats[0];
    }

    public void ThermalsOFF()
    {
        rend.sharedMaterial = materials[0]; //default monster material
        quarryFlareRenderer.sharedMaterial = guidanceMats[1];
        campLampRenderer.sharedMaterial = guidanceMats[2];
        towerLampRenderer.sharedMaterial = guidanceMats[2];
        boatLampRenderer.sharedMaterial = guidanceMats[2];
        cabinLampRenderer.sharedMaterial = guidanceMats[2];
    }
}