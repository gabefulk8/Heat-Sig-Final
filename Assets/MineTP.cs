using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HFPS.Player;

public class MineTP : MonoBehaviour
{
    public GameObject fadePanel;
    public GameObject player;

    private YieldInstruction fadeInstruction = new YieldInstruction(); // fade to black before teleport
    IEnumerator FadeIn(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < 4.5f)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / 4.5f);
            image.color = c;
        }
    }

    IEnumerator FadeOut(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < 2.5f)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01((2.5f - elapsedTime)/2.5f);
            image.color = c;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("teleport initiated");
        if (other.transform.root.GetComponent<PlayerController>())
        {
            fadePanel.SetActive(true);
            StartCoroutine(FadeIn(fadePanel.GetComponent<Image>()));
            Invoke("ToEndOfMine", 3);
        }
    }

    public void ToEndOfMine()
    {
        player.transform.position = new Vector3(1555.81f, 26.629f, -1327.3f);
        player.transform.rotation = new Quaternion(0, 625, 0, 0);
        StartCoroutine(FadeOut(fadePanel.GetComponent<Image>()));
    }
}
