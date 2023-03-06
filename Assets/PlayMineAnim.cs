using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMineAnim : MonoBehaviour
{
    public Animator mineAnimator;
    bool cutscenePlayed = false;
    public GameObject cutSceneCam;
    public GameObject mainCam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && cutscenePlayed == false)
        {
            mainCam.SetActive(false);
            cutSceneCam.SetActive(true);
            RenderSettings.ambientLight = new Color(0.8f, 0.8f, 0.8f);
            playAnim();
        }
    }

    void playAnim()
    {
        mineAnimator.SetTrigger("PlayMineAnim");
        cutscenePlayed = true;

        RenderSettings.fogColor = Color.white;

        Invoke("ToggeleOn", 7f);        
    }

    void ToggeleOn()
    {
        cutSceneCam.SetActive(false);
        RenderSettings.ambientLight = new Color(0.227451f, 0.227451f, 0.227451f);
        RenderSettings.fogColor = Color.black;
        mainCam.SetActive(true);
    }
}
