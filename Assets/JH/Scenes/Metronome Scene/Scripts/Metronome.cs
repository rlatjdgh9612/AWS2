using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Metronome : MonoBehaviour
{
    //AudioSource audioSource;

    public Image metronome_BeatsImg;
    public Image recorder_BeatsImg;
    public Text metronomeText;

    public int count;
    public int tempo;
    public int maxCount;

    Coroutine countCoroutine;

    private void Start()
    {

    }

    private void Update()
    {

    }

    [ContextMenu("play metronome")]
    public void PlayMetronome()
    {
        StopMetronome();
        countCoroutine = StartCoroutine(ieCountDown());
    }

    [ContextMenu("stop metronome")]
    public void StopMetronome()
    {
        if (countCoroutine != null)
        {
            StopCoroutine(countCoroutine);
            countCoroutine = null;
        }
    }

    IEnumerator ieCountDown()
    {
        while (count <= maxCount)
        {
            if (metronomeText) metronomeText.text = (count + 1).ToString();
            if (recorder_BeatsImg) recorder_BeatsImg.fillAmount = ((float)count) / (maxCount);
            metronome_BeatsImg.fillAmount = ((float)count) / (maxCount);
            count = (count + 1) % maxCount;

            //audioSource.Play();
            yield return new WaitForSeconds(60f / tempo);
        }
    }
}
