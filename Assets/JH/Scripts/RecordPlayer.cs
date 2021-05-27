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
    public bool isPlaying;
    private float currentPlayTime = 0;

    Metronome metronome;
    public Image loop_BeatCount;

    public Image playImg;
    public Image stopImg;

    public Text playText;
    public Text stopText;
    public Text startText;

    public void OnClickPlay(bool isLoop)
    {
        this.isLoop = isLoop;

        if (!isPlaying)
        {
            SetState(LoopState.Ready);
            metronome.playList.Add(this);
        }
        else
        {
            isPlaying = false;
            SetState(LoopState.Pause);
        }
    }

    public void Play()
    {
        isPlaying = true;
        SetState(LoopState.Play);
    }

    public LoopState state = LoopState.Pause;

    public enum LoopState
    {
        Pause,
        Ready,
        Play,
    }

    private void Awake()
    {
        metronome = GameObject.FindGameObjectWithTag("Metronome").GetComponent<Metronome>();
        maxBeats = metronome.maxBeats;
        tempo = metronome.tempo;
    }
    private void Start()
    {
        sourcePool = new AudioSource[30];
        for (int i = 0; i < 30; i++)
        {
            sourcePool[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    protected override void Update()
    {
        base.Update();

        switch (state)
        {
            case LoopState.Pause:
                break;
            case LoopState.Ready:
                startText.text = (metronome.maxBeats - (metronome.beats + metronome.maxBeats - 1) % metronome.maxBeats).ToString();
                print($"{metronome.maxBeats} {metronome.beats}");
                break;
            case LoopState.Play:
                break;
        }
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
            {
                isPlaying = false;
                SetState(LoopState.Pause);
            }
            currentPlayTime = 0;
        }
    }

    private IEnumerator IePlayNote(TriggerEnterEvent note)
    {
        note.isPlaying = true;
        AudioSource playableSource = sourcePool.First(source => !source.isPlaying);
        playableSource.clip = note.sound;
        playableSource.Play();
        //playableSource.loop = true;

        yield return new WaitForSeconds(note.length);

        //playableSource.Stop();
        note.isPlaying = false;
    }

    // Image FillAmount 코루틴
    //public IEnumerator ieLoopCount()
    //{
    //    while (beats <= maxBeats)
    //    {
    //        loop_BeatCount.fillAmount = ((float)beats) / maxBeats;
    //        beats = (beats + 1) % maxBeats;
    //        yield return new WaitForSeconds(60f / tempo);
    //    }
    //}

    public void SetState(LoopState state)
    {
        this.state = state;
        switch (state)
        {
            case LoopState.Pause:
                playImg.enabled = true;
                stopImg.enabled = false;
                playText.enabled = true;
                stopText.enabled = false;
                startText.enabled = false;
                break;

            case LoopState.Ready:
                playImg.enabled = false;
                stopImg.enabled = false;
                playText.enabled = false;
                stopText.enabled = false;
                startText.enabled = true;
                break;

            case LoopState.Play:
                playImg.enabled = false;
                stopImg.enabled = true;
                playText.enabled = false;
                stopText.enabled = true;
                startText.enabled = false;
                break;
        }
    }
}
