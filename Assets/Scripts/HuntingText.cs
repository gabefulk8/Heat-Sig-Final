using UnityEngine;
using UnityEngine.UI;

public class HuntingText : MonoBehaviour
{
    public GameObject gameObjectToActivate;
    public float delayTime = 10f;
    public float displayTime = 10f;
    public GameObject uiElement;

    private bool isDelayFinished = false;

    void Start()
    {
        gameObjectToActivate.SetActive(false);
        uiElement.SetActive(false);
        Invoke("FinishDelay", delayTime);
    }

    void FinishDelay()
    {
        isDelayFinished = true;
        gameObjectToActivate.SetActive(true);
        Invoke("ShowUI", displayTime);
    }

    void ShowUI()
    {
        uiElement.SetActive(true);
        Invoke("HideUI", displayTime);
    }

    void HideUI()
    {
        uiElement.SetActive(false);
    }
}
