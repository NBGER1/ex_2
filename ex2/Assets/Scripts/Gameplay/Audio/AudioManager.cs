using System.Collections;
using System.Collections.Generic;
using Notifications;
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

    private void OnRocketLaunched(EventParams e)
    {
        var eParams = e as RocketLaunchedEventParams;
        var go = Instantiate(_audioSourceGoPrefab, eParams.Origin, Quaternion.identity);
        var index = _effects["ROCKET_LAUNCHED"];
        go.GetComponent<AudioSourceGameObject>().Init(_effectsClips[index]);
    }

    private void OnExplosion(EventParams e)
    {
        var eParams = e as ProjectileHitCarEventParams;
        var go = Instantiate(_audioSourceGoPrefab, eParams.HitPoint, Quaternion.identity);
        var index = _effects["EXPLOSION"];
        go.GetComponent<AudioSourceGameObject>().Init(_effectsClips[index]);
    }


    public void Init()
    {
        //# Dictionary
        _effects.Add("EXPLOSION", 0);
        _effects.Add("ROCKET_LAUNCHED", 1);

        //# Subscribe Events
        GameplayServices.EventBus.Subscribe(GameplayEventType.RocketLaunched, OnRocketLaunched);
        GameplayServices.EventBus.Subscribe(GameplayEventType.ProjectileHitCar, OnExplosion);
    }

    protected override AudioManager GetInstance()
    {
        return this;
    }

    #endregion
}