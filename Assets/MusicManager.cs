using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] Sound intro;
    [SerializeField] Sound musicA;
    [SerializeField] Sound musicB;

    [SerializeField] bool skipIntro = false;

    private bool isBPlaying = false;
    private bool isIntro = true;

    public static MusicManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);

        CreateAudioSource(ref intro);
        CreateAudioSource(ref musicA);
        CreateAudioSource(ref musicB);
    }

    private void Start()
    {
        if (skipIntro)
        {
            musicA.source.Play();
            isIntro = false;
        }
        else
        {
            intro.source.loop = false;
            intro.source.Play();
        }
    }

    private void Update()
    {
        if (isIntro)
        {
            if (intro.source.time >= intro.source.clip.length)
            {
                if (!musicA.source.isPlaying)
                {
                    musicA.source.Play();
                    isIntro = false;
                }
            }
        }
    }

    private void CreateAudioSource(ref Sound track)
    {
        track.source = gameObject.AddComponent<AudioSource>();
        track.source.clip = track.clip;
        track.source.volume = track.volume;
        track.source.pitch = track.pitch;
        track.source.loop = true;
    }

    public void SwapTracks()
    {
        if (isBPlaying)
        {
            intro.source.Stop();
            musicA.source.Play();
            musicA.source.time = musicB.source.time;
            musicB.source.Stop();
            isBPlaying = false;
        }
        else
        {
            intro.source.Stop();
            musicB.source.Play();
            musicB.source.time = musicA.source.time;
            musicA.source.Stop();
            isBPlaying = true;
        }
    }
}
