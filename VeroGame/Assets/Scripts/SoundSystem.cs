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
}
