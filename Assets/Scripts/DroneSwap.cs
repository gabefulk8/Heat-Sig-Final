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

    public Renderer rend;       //these rends are each monster in the game ok sorry
    public Renderer rend2;
    public Renderer rend3;
    public Renderer rend4;
    public Renderer rend5;
    public Renderer rend6;
    public Renderer rend7;
    public Renderer rend8;
    public Renderer rend9;
    public Renderer rend10;
    public Renderer rend11;
    public Renderer rend12;
    public Renderer rend13;

    public Renderer quarryFlareRenderer;
    public Renderer cabinLampRenderer;
    public Renderer towerLampRenderer;
    public Renderer boatLampRenderer;
    public Renderer campLampRenderer;
    public Material[] guidanceMats; // 0 is thermal, 1 flare, 2 lamp
    public GameObject FloodThermals;

    private InputAction playerControls;

    public AudioClip toDrone;
    public AudioClip droneStatic;
    public AudioClip fromDrone;
    public AudioSource droneAudio;
    public AudioSource playerAudio;

    public MonoBehaviour scriptToDisable;
    public AudioClip deathSoundEffect;
    public AudioSource[] audioSourcesToDisable;

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
        droneAudio.Stop();
        playerAudio.PlayOneShot(fromDrone);
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
        droneAudio.PlayOneShot(toDrone);
        droneAudio.PlayDelayed(0.6f);
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
        rend2.sharedMaterial = materials[1];
        rend3.sharedMaterial = materials[1];
        rend4.sharedMaterial = materials[1];
        rend5.sharedMaterial = materials[1];
        rend6.sharedMaterial = materials[1];
        rend7.sharedMaterial = materials[1];
        rend8.sharedMaterial = materials[1];
        rend9.sharedMaterial = materials[1];
        rend10.sharedMaterial = materials[1];
        rend11.sharedMaterial = materials[1];
        rend12.sharedMaterial = materials[1];
        rend13.sharedMaterial = materials[1];
        quarryFlareRenderer.sharedMaterial = guidanceMats[0];
        campLampRenderer.sharedMaterial = guidanceMats[0];
        towerLampRenderer.sharedMaterial = guidanceMats[0];
        boatLampRenderer.sharedMaterial = guidanceMats[0];
        cabinLampRenderer.sharedMaterial = guidanceMats[0];
        FloodThermals.SetActive(true);
    }

    public void ThermalsOFF()
    {
        rend.sharedMaterial = materials[0]; //default monster material
        rend2.sharedMaterial = materials[0];
        rend3.sharedMaterial = materials[0];
        rend4.sharedMaterial = materials[0];
        rend5.sharedMaterial = materials[0];
        rend6.sharedMaterial = materials[0];
        rend7.sharedMaterial = materials[0];
        rend8.sharedMaterial = materials[0];
        rend9.sharedMaterial = materials[0];
        rend10.sharedMaterial = materials[0];
        rend11.sharedMaterial = materials[0];
        rend12.sharedMaterial = materials[0];
        rend13.sharedMaterial = materials[0];
        quarryFlareRenderer.sharedMaterial = guidanceMats[1];
        campLampRenderer.sharedMaterial = guidanceMats[2];
        towerLampRenderer.sharedMaterial = guidanceMats[2];
        boatLampRenderer.sharedMaterial = guidanceMats[2];
        cabinLampRenderer.sharedMaterial = guidanceMats[2];
        FloodThermals.SetActive(false);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            scriptToDisable.enabled = false;
            AudioSource.PlayClipAtPoint(deathSoundEffect, transform.position);

            foreach (var audioSource in audioSourcesToDisable)
            {
                audioSource.enabled = false;
            }
        }
    }
    
}