using strange.extensions.mediation.impl;
using UnityEngine;

public class AudioView : View
{
    [SerializeField]
    private AudioClip _clickAudioClip;
    [SerializeField]
    private AudioClip _dropAudioClip;

    private AudioSource _audioSource;

    protected override void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayDropAudio()
    {
        PlayAudioClip(_dropAudioClip);
    }

    public void PlayClickAudio()
    {
        PlayAudioClip(_clickAudioClip);
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}
