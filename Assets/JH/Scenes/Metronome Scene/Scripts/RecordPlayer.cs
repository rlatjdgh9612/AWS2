using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RecordPlayer : Metronome
{
    public AudioSource[] sourcePool;
    public Loop recordLoop;
    public TriggerEnterEvent shouldPlayNote;

    bool isLoop;
    bool isPlaying;
    private float currentPlayTime = 0;

    Metronome metronome;

    public void OnClickPlay(bool isLoop)
    {
        this.isLoop = isLoop;
        isPlaying = !isPlaying;
    }

    private void Start()
    {
        metronome = GameObject.FindGameObjectWithTag("Metronome").GetComponent<Metronome>();
        maxCount = metronome.maxCount;
        tempo = metronome.tempo;

        sourcePool = new AudioSource[50];
        for (int i = 0; i < 50; i++)
        {
            sourcePool[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (isPlaying && currentPlayTime <= recordLoop.recordLength)
        {
            currentPlayTime += Time.deltaTime;
            shouldPlayNote = recordLoop.record.FirstOrDefault(r => r.isNowPlaying(currentPlayTime) && !r.isPlaying);
            if (shouldPlayNote != null && shouldPlayNote.sound != null)
            {
                StartCoroutine(IePlayNote(shouldPlayNote));
            }
        }
        else
        {
            if (!isLoop)
                isPlaying = false;
            currentPlayTime = 0;
        }
    }

    private IEnumerator IePlayNote(TriggerEnterEvent note)
    {
        note.isPlaying = true;
        AudioSource playableSource = sourcePool.First(source => !source.isPlaying);
        playableSource.clip = note.sound;
        playableSource.loop = true;
        playableSource.Play();

        yield return new WaitForSeconds(note.length);

        playableSource.Stop();
        note.isPlaying = false;
    }
}
