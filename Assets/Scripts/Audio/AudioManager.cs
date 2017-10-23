using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//need to change this when we figure out how to make enums in inspector from string list
[System.Serializable]
public enum ClipNames
{
    Knockback,
    ProgressUp,
    ProgressDown
}

[System.Serializable]
public class ClipData
{
    public ClipNames name;
    public AudioClip clip;
    public float timeOfLastPlay;
}


public class AudioManager : MonoBehaviour {

    private AudioSource source;

    public List<ClipData> clips = new List<ClipData>();

    //Singleton
    public static AudioManager inst;

    private void Awake()
    {
        if (inst != null)
        {
            DestroyImmediate(this);
        }
        else
        {
            inst = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GlobalEvents.playOneShot.AddListener(RunClip);
    }

    private void OnDisable()
    {
        GlobalEvents.playOneShot.RemoveListener(RunClip);
    }

    public void RunClip(OneShotData data)
    {
        ClipData clip = clips.Find(x => x.name == data.name);

        if ((clip.timeOfLastPlay + (clip.clip.length / 2)) <= Time.timeSinceLevelLoad)
        {
            source.PlayOneShot(clip.clip);
            clip.timeOfLastPlay = Time.timeSinceLevelLoad;
        }
    }
}
