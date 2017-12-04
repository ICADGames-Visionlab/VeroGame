using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public AudioClip clip;

    private AudioSource source;
        
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void setLoop(bool flag)
    {
        source.loop = flag;
    }

    public void setClip(AudioClip clip)
    {
        this.clip = clip;
    }

    public void playClip()
    {
        source.PlayOneShot(clip);
    }

    public void stopClip()
    {
        source.Stop();
    }

    public static void stopSound(GameObject go)
    {
        if (go.transform.childCount > 0)
        {
            SoundSystem system = go.GetComponentInChildren<SoundSystem>();
            if (system != null)
                system.stopClip();
        }
    }

    public static void playSound(GameObject go)
    {
        if (go.transform.childCount > 0)
        {
            SoundSystem system = go.GetComponentInChildren<SoundSystem>();
            if (system != null)
                system.playClip();
        }
    }
}
