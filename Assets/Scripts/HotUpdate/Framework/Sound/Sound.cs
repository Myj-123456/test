using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;


/// <summary>
/// 一个音频播放对象
/// </summary>
public class Sound
{
    private string soundName;
    private AudioSource audio;
    private GameObject _owner;
    public GameObject Owner
    {
        get { return _owner; }
    }
    public Sound(AudioSource audio, GameObject owner)
    {
        this.audio = audio;
        _owner = owner;
    }

    public void Play(AudioClip clip, float volume, bool loop = false)
    {
        audio.clip = clip;
        audio.volume = volume;
        audio.loop = loop;
        audio.Play();
    }

    public void Stop() => audio.Stop();
    public void Pause() => audio.Pause();
    public void Resume() => audio.Play();
    public bool mute { get { return audio.mute; } set { audio.mute = value; } }
    public bool isPlaying => audio.isPlaying;

    public string ClipName()
    {
        if (audio.clip == null) return "";
        else return audio.clip.name;
    }
}

