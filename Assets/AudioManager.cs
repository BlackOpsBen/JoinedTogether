using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static int CHARACTER_THIEF = 0;
    public static int CHARACTER_CLEANER = 1;

    public static int CATEGORY_THIEF_UP = 0;
    public static int CATEGORY_THIEF_DOWN = 1;
    public static int CATEGORY_THIEF_EXCLAIM = 2;
    public static int CATEGORY_THIEF_GOT_IT = 3;

    public static int CATEGORY_CLEANER_GO_FIGHT = 0;
    public static int CATEGORY_CLEANER_KILL = 1;

    public static AudioManager Instance { get; private set; }

    [Header("SFX")]
    public Sound[] SFX;

    [Header("Characters")]
    public SoundGroup[] characterSoundGroups;

    [Header("Reminders")]
    public Sound[] reminders;

    private bool someoneIsSpeaking = false;
    private float speakingDuration = 0f;

    private DialogLimiter dialogLimiter;

    private float timeSinceLastReminder = 4f;
    private float reminderInterval = 5f;

    private void Awake()
    {
        dialogLimiter = GetComponent<DialogLimiter>();
        SingletonPattern();
        CreateAudioSources(ref SFX);
        CreateAudioSources(ref reminders);
        for (int i = 0; i < characterSoundGroups.Length; i++)
        {
            for (int j = 0; j < characterSoundGroups[i].dialogCategories.Length; j++)
            {
                for (int k = 0; k < characterSoundGroups[i].dialogCategories[j].dialogsOptions.Length; k++)
                {

                }
            }
        }
        foreach (SoundGroup sg in characterSoundGroups)
        {
            foreach (DialogCategory dc in sg.dialogCategories)
            {
                CreateAudioSources(ref dc.dialogsOptions);
            }
        }
    }

    private void SingletonPattern()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (speakingDuration < 0.0f)
        {
            someoneIsSpeaking = false;
        }
        else
        {
            speakingDuration -= Time.deltaTime;
        }

        timeSinceLastReminder += Time.deltaTime;
    }

    private void CreateAudioSources(ref Sound[] sounds)
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.source.Play();
    }

    public void PlaySFXLoop(string name)
    {
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.source.loop = true;
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
    }

    public void StopSFXLoop(string name)
    {
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.source.loop = false;
        s.source.Stop();
    }

    public void PlayDialog(int CHARACTER_INDEX, int DIALOG_CATEGORY, bool oneAtATime)
    {
        int maxOption = characterSoundGroups[CHARACTER_INDEX].dialogCategories[DIALOG_CATEGORY].dialogsOptions.Length;
        int selectedOption = UnityEngine.Random.Range(0, maxOption);
        Sound s = characterSoundGroups[CHARACTER_INDEX].dialogCategories[DIALOG_CATEGORY].dialogsOptions[selectedOption];

        if (oneAtATime)
        {
            if (someoneIsSpeaking || !dialogLimiter.GetCanSpeak(CHARACTER_INDEX))
            {
                return;
            }
            speakingDuration = s.source.clip.length;
            someoneIsSpeaking = true;
            dialogLimiter.SetCanSpeak(CHARACTER_INDEX, false);
        }

        s.source.Play();
    }

    public void PlayReminder()
    {
        int maxOption = reminders.Length;
        int selectedOption = UnityEngine.Random.Range(0, maxOption);
        Sound s = reminders[selectedOption];
        if (timeSinceLastReminder > reminderInterval)
        {
            s.source.Play();
            timeSinceLastReminder = 0f;
        }
    }

    public bool GetIsSomeoneSpeaking()
    {
        return someoneIsSpeaking;
    }
}

[System.Serializable]
public class SoundGroup
{
    public string name;
    public DialogCategory[] dialogCategories;
}

[System.Serializable]
public class DialogCategory
{
    public string name;
    public Sound[] dialogsOptions;
}
