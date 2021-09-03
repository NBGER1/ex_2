using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    #region Editor

    [SerializeField] private AudioClip[] _effectsClips;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _audioSourceGoPrefab;

    #endregion

    #region Fields

    private Dictionary<string, int> _effects = new Dictionary<string, int>();

    #endregion

    #region Methods

    public void Init()
    {
        _effects.Add("EXPLOSION", 0);
        _effects.Add("BOMB_LAUNCHED", 1);

        Debug.Log("AudioManager Initialized");
    }

    protected override AudioManager GetInstance()
    {
        return this;
    }

    public void PlayEffect(string effectName, Vector3 position)
    {
        var index = _effects[effectName];
        //_audioSource.PlayOneShot(_effectsClips[index]);
        var go = Instantiate(_audioSourceGoPrefab, position, Quaternion.identity);
        go.GetComponent<AudioSourceGameObject>().Init(_effectsClips[index]);
    }

    #endregion
}