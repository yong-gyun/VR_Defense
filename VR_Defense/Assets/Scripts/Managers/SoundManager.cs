using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    public GameObject Root
    {
        get
        {
            if(root == null)
            {
                root = GameObject.Find("@Sound_Root");
                
                if(root == null)
                {
                    root = new GameObject { name = "@Sound_Root" };
                }
            }

            root.transform.SetParent(GameObject.Find("@Managers").transform);
            return root;
        }
    }

    GameObject root = null;

    Dictionary<Define.BGM, AudioClip> _bgms = new Dictionary<Define.BGM, AudioClip>();
    Dictionary<Define.SFX, AudioClip> _sfxs = new Dictionary<Define.SFX, AudioClip>();

    AudioSource _bgmSource = null;
    AudioSource _sfxSource = null;

    public void Init()
    {
        GameObject bgm = GameObject.Find("@BGM");

        if(bgm == null)
            bgm = new GameObject { name = "@BGM" };

        _bgmSource = bgm.GetOrAddComponent<AudioSource>();

        GameObject sfx = GameObject.Find("@SFX");

        if (sfx == null)
            sfx = new GameObject { name = "@SFX" };

        _sfxSource = sfx.GetOrAddComponent<AudioSource>();

        for(int i = 0; i < System.Enum.GetValues(typeof(Define.BGM)).Length; i++)
        {
            AudioClip clip = Managers.Resource.Load<AudioClip>($"Sound/{(Define.BGM) i}");
            _bgms.Add((Define.BGM)i, clip);
        }

        for (int i = 0; i < System.Enum.GetValues(typeof(Define.SFX)).Length; i++)
        {
            AudioClip clip = Managers.Resource.Load<AudioClip>($"Sound/{(Define.SFX)i}");
            _sfxs.Add((Define.SFX) i, clip);
        }
    }

    public void SetVolume(float volume = 1, Define.AudioSources source = Define.AudioSources.Unknown)
    {
        switch(source)
        {
            case Define.AudioSources.BGM:
                _bgmSource.volume = volume;
                break;
            case Define.AudioSources.SFX:
                _sfxSource.volume = volume;
                break;
        }
    }

    public void PlayBGM(Define.BGM type)
    {
        if (_bgmSource.isPlaying)
            _bgmSource.Stop();

        _bgmSource.clip = _bgms[type];
        _bgmSource.Play();
    }

    public void PlaySFX(Define.SFX type, GameObject go= null)
    {
        AudioSource source = null;

        if (go == null)
            source = _sfxSource;
        else
            source = go.GetOrAddComponent<AudioSource>();

        source.clip = _sfxs[type];
        source.Play();
    }
}
