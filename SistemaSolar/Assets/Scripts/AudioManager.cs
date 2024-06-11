using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Play("Star");
    }

    public void Play(string name)
    {
        if(!Search(name, out Sound s))
            return;

        s.source.Play();
    }

    public void Stop(string name)
    {
        if(!Search(name, out Sound s))
            return;

        if(s.source.isPlaying)
            s.source.Stop();
    }

    public void StopAll()
    {
        foreach(Sound s in sounds)
        {
            if(s.source.isPlaying)
                s.source.Stop();
        }
    }

    public void Focus(string name)
    {
        if(!Search(name, out Sound s))
            return;

        if(!s.source.isPlaying)
        {
            StopAll();
            s.source.Play();
        }
        else
        {
            foreach(Sound m in sounds)
            {
                if(m.name != s.name && m.source.isPlaying)
                    m.source.Stop();
            }
        }
    }

    bool Search(string name, out Sound s)
    {
        s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return false;
        }

        return true;
    }
}
