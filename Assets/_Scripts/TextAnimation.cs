using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{

    public Text dialogueText;
    public float delay;
    private string fullText;

    public string[] sentences = new string[3];

    public int waitTime;

    public GameObject Canvas;

    private string currentText = "";
    // Use this for initialization
    void Start()
    {
        fullText = sentences[0];
        StartCoroutine(ShowText());
        StartCoroutine(Text());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            dialogueText.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator Text()
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 1; i < sentences.Length; i++)
        {
            fullText = sentences[i];
            StartCoroutine(ShowText());
            yield return new WaitForSeconds(waitTime);
        }
        yield return new WaitForSeconds(3);
        Destroy();
    }

    public void Destroy()
    {
        Destroy(Canvas);
    }
}