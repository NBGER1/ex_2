using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class AudioSourceGameObject : MonoBehaviour
{
    #region Editor

    [SerializeField] private AudioSource _audioSource;

    #endregion

    #region Methods

    public void Init(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
        GameplayServices.WaitService.WaitFor(clip.length, () => { Destroy(gameObject); });
    }

    #endregion
}