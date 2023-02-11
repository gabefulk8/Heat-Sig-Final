using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GPS : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] items;
    [SerializeField] TMP_Text[] text;
    private bool inMenu;
    private int menuState;

    //GPS
    [SerializeField] int updatetime;
    [SerializeField] AudioClip beep;
    private int[] playerpos;
    private int postimer;
    private int beeptimer;

    //Map
    [SerializeField] TMP_Text[] locations;
    [SerializeField] private AudioClip checkmark;

    //Audio Logs
    [SerializeField] TMP_Text audioLogText;
    [SerializeField] AudioClip[] audioLogs;
    [SerializeField] AudioClip click;
    [SerializeField] Slider audioSlider;
    [SerializeField] GameObject[] buttons;
    public Animator[] buttonAnimators;
    private int whatLog;
    private int makesurethesounddoesntplay;
    private bool isPaused;
    private bool[] hasLog;
    private bool noLogs;


    //Audio Sources
    [SerializeField] AudioSource source1;
    [SerializeField] AudioSource source2;

    [SerializeField] TMP_Text sampletext;
    private int numberoflogs;
    [SerializeField] Image arrow;

    // Start is called before the first frame update
    void Start()
    {
        inMenu = false;
        menuState = 0;
        playerpos = new int[3];
        isPaused = false;
        whatLog = 0;
        noLogs = true;
        hasLog = new bool[audioLogs.Length + 1];
        for (int i = 0; i < hasLog.Length; i++) hasLog[i] = false;
        audioSlider.minValue = 0;
        audioSlider.direction = Slider.Direction.LeftToRight;
        numberoflogs = 0;
        beeptimer = 0;
    
    }

    // Update is called once per frame
    void Update()
    {
        Menus();

        UpdatePos();

        if (Input.GetKeyDown(KeyCode.H)) hasLog[1] = true;
        if (Input.GetKeyDown(KeyCode.J)) hasLog[2] = true;
        if (Input.GetKeyDown(KeyCode.K)) hasLog[3] = true;
        if (Input.GetKeyDown(KeyCode.L)) hasLog[4] = true;
        if (Input.GetKeyDown(KeyCode.Z)) hasLog[5] = true;


        //ligma balls
        arrow.rectTransform.eulerAngles = new Vector3(0, 0, -(audioSlider.value * 360));
    }

    void Menus()
    {

        numberoflogs = 0;
        for (int i = 0; i < hasLog.Length; i++)
        {
            if (hasLog[i] == true) numberoflogs++;
        }

        //sampletext.text = "" + numberoflogs;
        //Changes what item is being held
        switch (menuState)
        {
            case 0:
                inMenu = false;
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].transform.localPosition.y > -0.9) items[i].transform.localPosition += new Vector3(0, -0.05f, 0);
                    if (items[i].transform.localPosition.y > -0.8) inMenu = true;
                }

                if (Input.GetKeyDown(KeyCode.Alpha1) && inMenu == false)
                {
                    menuState = 1;
         
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && inMenu == false) menuState = 2;
                else if (Input.GetKeyDown(KeyCode.Alpha3) && inMenu == false) menuState = 3;

                break;
             //GPS
            case 1:
                inMenu = true;
                if (Input.GetKeyDown(KeyCode.Alpha1)) menuState = 0;
                if (items[0].transform.localPosition.y < -0.325) items[0].transform.localPosition += new Vector3(0, 0.05f, 0);
                beeptimer++;
                if (beeptimer > 2 * 60)
                {
                    playAudio(beep);
                    beeptimer = 0;
                }

                    break;
            //Map
            case 2:
                inMenu = true;
                if (Input.GetKeyDown(KeyCode.Alpha2)) menuState = 0;
                if (items[1].transform.localPosition.y < -0.2) items[1].transform.localPosition += new Vector3(0, 0.05f, 0);
                map();
                break;
            //Tape Recorder
            case 3:
                inMenu = true;
                if (Input.GetKeyDown(KeyCode.Alpha3)) menuState = 0;
                if (items[2].transform.localPosition.y < -0.15) items[2].transform.localPosition += new Vector3(0, 0.05f, 0);
                AudioLogs();
                break;
        }

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].transform.localPosition.y <= -0.8)
            {
                items[i].SetActive(false);
            }

            else if (items[i].transform.localPosition.y > -0.8)
            {
                items[i].SetActive(true);
            }
        }
    }

    //Updates the position of the player 
    void UpdatePos()
    {
        postimer++;
        if (postimer > updatetime * 60)
        {
            playerpos[0] = Mathf.RoundToInt(player.transform.position.x);
            playerpos[1] = Mathf.RoundToInt(player.transform.position.y);
            playerpos[2] = Mathf.RoundToInt(player.transform.position.z);
            text[0].text = "" + playerpos[0].ToString("0000") + "°, " + playerpos[2].ToString("0000") + "°";
            postimer = 0;
        }
    }

    void map()
    {

        //Map of Locations
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            locations[0].text = "<s>Location 1: 100, 200, 300<s>";
            playAudio(checkmark);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            locations[1].text = "<s>Location 2: 100, 200, 300<s>";
            playAudio(checkmark);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            locations[2].text = "<s>Location 3: 100, 200, 300<s>";
            playAudio(checkmark);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            locations[3].text = "<s>Location 4: 100, 200, 300<s>";
            playAudio(checkmark);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            locations[4].text = "<s>Location 5: 100, 200, 300<s>";
            playAudio(checkmark);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            locations[5].text = "<s>Location 6: 100, 200, 300<s>";
            playAudio(checkmark);
        }
    }

    void AudioLogs()
    {
        //checks which logs you have
        for (int i = 0; i < hasLog.Length; i++)
        {
            if (hasLog[i] == true && noLogs == true)
                {
                    whatLog = i;
                    noLogs = false;
                }
        }

        //displays the logs if you have some
        if (noLogs == false)
        {
            if (Input.GetKeyDown(KeyCode.N) && whatLog != 0)
            {
                makesurethesounddoesntplay = whatLog;
                whatLog += -1;
                for (int i = 0; i < audioLogs.Length; i++)
                {
                    if (whatLog < 1) whatLog = audioLogs.Length;
                    if (hasLog[whatLog] == false) whatLog += -1;
                }
                if (makesurethesounddoesntplay != whatLog)
                {
                    playAudio(click);
                    isPaused = false;
                    source2.Stop();
                    source2.time = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.M) && whatLog != 0)
            {
                makesurethesounddoesntplay = whatLog;
                whatLog += 1;
                for (int i = 0; i < audioLogs.Length; i++)
                {
                    if (whatLog > audioLogs.Length) whatLog = 1;
                    if (hasLog[whatLog] == false) whatLog += 1;
                }
                if (makesurethesounddoesntplay != whatLog)
                {
                    isPaused = false;
                    source2.Stop();
                    source2.time = 0;
                    playAudio(click);

                }
            }

            //restart log
            if (Input.GetKeyDown(KeyCode.R) && whatLog != 0 && source2.isPlaying == true) playAudioLog(audioLogs[whatLog - 1]);
        }

        //checks if you have any audiologs then displays which one you have
        if(whatLog == 0) audioLogText.text = "No Audio Logs";
        else
        {
            audioLogText.text = "Audio Log #" + whatLog;
            playAudioLog(audioLogs[whatLog - 1]);
            audioSlider.value = (source2.time / audioLogs[whatLog - 1].length);
            audioSlider.maxValue = audioLogs[whatLog - 1].length;
        }


    }


    //sound effects
    void playAudio(AudioClip whatsoundeffect)
    {
        source1.PlayOneShot(whatsoundeffect);

    }

    //controls the audio long playing
    void playAudioLog(AudioClip whichLog)
    {
        source2.clip = whichLog;

        //play and pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            playAudio(click);

            if (source2.isPlaying == true)
            {
                isPaused = true;

                source2.Pause();

                buttonAnimators[4].SetTrigger("ButtonInput");
            }
            else if (source2.isPlaying == false)
            {
                if (isPaused == false) source2.Play();
                else if (isPaused == true)
                {
                    source2.UnPause();
                }

                buttonAnimators[2].SetTrigger("ButtonInput");
            }
        }


        //restart song
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isPaused == true) source2.UnPause();
            source2.Play();
            buttonAnimators[1].SetTrigger("ButtonInput");
        }


        //rewind by 10%
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (source2.time < (whichLog.length / 10)) source2.time = 0;
            else source2.time += -(whichLog.length / 10);
            buttonAnimators[1].SetTrigger("ButtonInput");
        }


        //fast forward by 10%
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (source2.time > ((9 * whichLog.length) / 10)) source2.Stop();
            else source2.time += (whichLog.length / 10);
            buttonAnimators[3].SetTrigger("ButtonInput");
        }
    }
  
}