using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using YooAsset;


/// <summary>
/// 音频管理器
/// AikeLiu
/// </summary>
public class SoundManager : MonoSingleton<SoundManager>
{
    private const int MAX_SOUND = 10;
    private Dictionary<GameObject, List<Sound>> soundPool = new Dictionary<GameObject, List<Sound>>(MAX_SOUND);//音效池子

    //音频路径前缀
    private const string prefixPath = "Assets/HotUpdateResources/";

    public const string AudioVolumeSer = "AudioVolume";//音频序列化
    public const string SoundVolumeSer = "SoundVolume";//音效序列化
    public const string MusicVolumeSer = "MusicVolume";//音乐序列化
                                                       
    private AudioSource musicPlayer;//音乐播放器(把这个当做背景音乐通道吧,全局只有一个)

    private Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();
    private List<AudioSource> soundAudioSources = new List<AudioSource>();//音效列表

    private bool _audioEnabled = true;//总音频开关
    private bool _soundEnabled = true;//音效开关
    private bool _musicEnabled = true;//音乐开关

    public bool audioEnabled
    {
        get { return _audioEnabled; }
        set
        {
            if (value == _audioEnabled)
                return;
            _audioEnabled = value;

            if (!_audioEnabled)//如果关闭总音频，把音乐和音效都关闭掉
            {
                StopAll();
            }
            else
            {
                if (_musicEnabled)//音乐开关打开情况下，打开总开关那么再重新播放音乐
                {
                    ResumeMusic();
                }
            }

        }
    }

    public bool musicEnabled
    {
        get { return _musicEnabled; }
        set
        {
            if (value == _musicEnabled)
                return;
            _musicEnabled = value;
            if (!_musicEnabled)
            {
                StopMusic();
            }
            else
            {
                ResumeMusic();
            }
        }
    }

    public bool soundEnabled
    {
        get { return _soundEnabled; }
        set
        {
            if (value == _soundEnabled)
                return;
            _soundEnabled = value;
            if (!_soundEnabled)
            {
                StopAllSound();
            }
        }
    }

    private float _audioVolume = 1;
    public float AudioVolume
    {
        get { return _audioVolume; }
        set
        {
            _audioVolume = value;
            //PlayerPrefs.SetFloat(AudioVolumeSer, _audioVolume);
            if (_audioVolume < _soundVolume)
            {
                SoundVolume = _audioVolume;
            }
            if (_audioVolume < _musicVolume)
            {
                MusicVolume = _audioVolume;
            }
        }
    }
    private float _soundVolume = 1;
    public float SoundVolume
    {
        get { return _soundVolume; }
        set
        {
            _soundVolume = value;
            //PlayerPrefs.SetFloat(SoundVolumeSer, _soundVolume);
        }
    }
    private float _musicVolume = 1;
    public float MusicVolume
    {
        get { return _musicVolume; }
        set
        {
            _musicVolume = value;
            musicPlayer.volume = value;
            //PlayerPrefs.SetFloat(MusicVolumeSer, _musicVolume);
        }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        //Init();
    }
    private void Init()
    {
        if (PlayerPrefs.HasKey(SoundVolumeSer)) SoundVolume = PlayerPrefs.GetFloat(SoundVolumeSer);
        if (PlayerPrefs.HasKey(MusicVolumeSer)) MusicVolume = PlayerPrefs.GetFloat(MusicVolumeSer);
        if (PlayerPrefs.HasKey(AudioVolumeSer)) AudioVolume = PlayerPrefs.GetFloat(AudioVolumeSer);
    }
    #region 背景音乐


    private string musicName;
    /// <summary>
    /// 播放音乐
    /// </summary>
    /// <param name="soundName"></param>
    /// <param name="loop"></param>
    public void PlayMusic(string soundName, bool loop = true)
    {
        musicName = soundName;
        if (!LoginModel.Instance.isGameInit) return;
        if (!_audioEnabled || !_musicEnabled) return;
        if (musicPlayer == null)
            musicPlayer = gameObject.AddComponent<AudioSource>();

        if (musicPlayer.isPlaying)
            musicPlayer.Stop();

        async Task PlayMusic(string soundName, bool loop = false)
        {
            var clip = await GetAudioClipAsync(soundName);
            if (clip == null)
            {
                Debug.LogError("没有此音频：" + soundName);
                return;
            }
            musicPlayer.clip = clip;
            musicPlayer.loop = loop;
            musicPlayer.volume = MusicVolume;
            musicPlayer.Play();
        }
        _ = PlayMusic(soundName, loop);
    }

    /// <summary>
    /// 停止播放音乐
    /// </summary>
    public void StopMusic()
    {
        musicPlayer?.Stop();
    }

    /// <summary>
    /// 暂停播放音乐
    /// </summary>
    public void PauseMusic()
    {
        musicPlayer?.Pause();
    }

    /// <summary>
    /// 继续播放音乐
    /// </summary>
    public void ResumeMusic()
    {
        if (musicPlayer != null)
        {
            musicPlayer.Play();
        }
        else
        {
            PlayMusic(musicName);
        }
    }
    #endregion
    #region 音效

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="soundName"></param>
    /// <param name="attachTarget">附加的发声对象</param>
    /// <param name="loop"></param>
    /// 
    public void PlaySound(string soundName, GameObject attachTarget = null, bool loop = false)
    {
        if (!LoginModel.Instance.isGameInit) return;
        if (!_audioEnabled || !_soundEnabled) return;
        Sound sound = GetSound(attachTarget, loop);
        if (loop && sound.ClipName().Equals(soundName.ToString()) && sound.isPlaying) return;//循环声音同样的音频不重复播放

        async Task PlaySound(string soundName, bool loop = false)
        {
            if (sound != null)
            {
                var clip = await GetAudioClipAsync(soundName);
                if (clip != null)
                {
                    sound.Play(clip, SoundVolume, loop);
                }
            }
        }
        _ = PlaySound(soundName, loop);
    }

    private Sound GetSound(GameObject attachTarget, bool isLoop = false)
    {
        List<Sound> sounds;
        Sound sound;
        if (attachTarget == null) attachTarget = gameObject;
        if (!soundPool.TryGetValue(attachTarget, out sounds))
        {
            sounds = new List<Sound>();
            sound = new Sound(attachTarget.AddComponent<AudioSource>(), attachTarget);
            sounds.Add(sound);
            soundPool.Add(attachTarget, sounds);
            return sound;
        }
        if (isLoop) return sounds[0];
        else
        {
            foreach (Sound soundItem in sounds)
            {
                if (!soundItem.isPlaying)
                {
                    return soundItem;
                }
            }
        }
        sound = new Sound(attachTarget.AddComponent<AudioSource>(), attachTarget);
        sounds.Add(sound);
        return sound;
    }

    private Sound GetSound(string soundName, GameObject attachTarget)
    {
        List<Sound> sounds;

        if (attachTarget == null) attachTarget = gameObject;
        if (!soundPool.TryGetValue(attachTarget, out sounds))
        {
            return null;
        }

        foreach (Sound soundItem in sounds)
        {
            if (soundItem.ClipName().Equals(soundName.ToString())) return soundItem;
        }

        return null;
    }
    /// <summary>
    /// 获取音效音源
    /// </summary>
    /// <returns></returns>
    private AudioSource CreateSoundAudioSource()
    {
        foreach (AudioSource audioSource in soundAudioSources)
        {
            if (!audioSource.isPlaying)//优先找一个未在播放的
            {
                return audioSource;
            }
        }
        //列表找不到则创建一个新的
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        soundAudioSources.Add(audio);
        return audio;
    }

    /// <summary>
    /// 停止播放音效
    /// </summary>
    public void StopSound(string soundName, GameObject attachTarget = null)
    {
        var sound = GetSound(soundName, attachTarget);
        if (sound != null && sound.isPlaying)
        {
            sound.Stop();
        }
    }

    /// <summary>
    /// 停止所有音效
    /// </summary>
    public void StopAllSound()
    {
        foreach (KeyValuePair<GameObject, List<Sound>> kv in soundPool)
        {
            var sounds = kv.Value;
            foreach (Sound sound in sounds)
            {
                if (sound.isPlaying)
                {
                    sound.Stop();
                }
            }
        }
    }
    #endregion

    /// <summary>
    /// 停止全部声音
    /// </summary>
    public void StopAll()
    {
        StopMusic();
        StopAllSound();
    }

    /// <summary>
    /// 设置静音状态
    /// </summary>
    public void SetMuteState(bool mute)
    {
        SetMusicMuteState(mute);
        SetSoundMuteState(mute);
    }

    /// <summary>
    /// 设置音乐静音状态
    /// </summary>
    public void SetMusicMuteState(bool mute)
    {
        if (musicPlayer != null)
            musicPlayer.mute = mute;
    }

    /// <summary>
    /// 设置音效静音状态
    /// </summary>
    public void SetSoundMuteState(bool mute)
    {
        foreach (KeyValuePair<GameObject, List<Sound>> kv in soundPool)
        {
            var sounds = kv.Value;
            foreach (Sound sound in sounds)
            {
                if (sound.isPlaying)
                {
                    sound.mute = mute;
                }
            }
        }
    }

    ///// <summary>
    ///// 同步获取一个音频
    ///// </summary>
    ///// <param name="sound"></param>
    ///// <returns></returns>
    //private AudioClip GetAudioClip(string sound)
    //{
    //    AudioClip clip;
    //    var path = ResPath.GetAudioPath(sound);
    //    if (string.IsNullOrEmpty(path))
    //    {
    //        Debug.Log("未找到音频资源");
    //        return null;
    //    }

    //    if (!audioClipDic.TryGetValue(sound, out clip))
    //    {
    //        AssetHandle assetHandle = ResourceManager.Instance.LoadAssetSync<AudioClip>(path);
    //        clip = (assetHandle.AssetObject as AudioClip);
    //        audioClipDic.Add(sound, clip);
    //        if (clip == null)
    //            Debug.LogError("AudioClip is null, path=" + path);
    //    }
    //    return clip;
    //}

    /// <summary>
    /// 异步获取一个音频
    /// </summary>
    /// <param name="sound"></param>
    /// <returns></returns>
    private async Task<AudioClip> GetAudioClipAsync(string sound)
    {
        AudioClip clip = null;
        var path = ResPath.GetAudioPath(sound);
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log("未找到音频资源");
            return null;
        }

        if (!audioClipDic.TryGetValue(sound, out clip))
        {
            clip = await LoadSound(sound);
            audioClipDic.Add(sound, clip);
        }
        return clip;
    }


    /// <summary>
    /// 音频异步加载
    /// </summary>
    /// <param name="soundName"></param>
    public async Task<AudioClip> LoadSound(string soundName)
    {
        AudioClip clip;
        var path = ResPath.GetAudioPath(soundName);
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log("未找到音频资源");
            return null;
        }
        if (!audioClipDic.ContainsKey(soundName))
        {
            AssetHandle assetHandle = ResourceManager.Instance.LoadAssetAsync<AudioClip>(path);
            await assetHandle.Task;
            clip = (assetHandle.AssetObject as AudioClip);
            return clip;

            //audioClipDic.Add(soundName, clip);
            //if (clip == null)
            //    Debug.LogError("AudioClip is null, path=" + soundName);
        }
        return null;
    }

    /// <summary>
    /// 音频卸载
    /// </summary>
    /// <param name="soundName"></param>
    public void UpLoadSound(string soundName)
    {
        var config = ResPath.GetAudioPath(soundName);
        if (string.IsNullOrEmpty(config))
        {
            Debug.Log("未找到音频资源");
            return;
        }
        if (audioClipDic.ContainsKey(soundName))
        {
            ResourceManager.Instance.TryUnloadUnusedAsset(soundName);
            audioClipDic.Remove(soundName);
        }
    }


}
