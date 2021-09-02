using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Cannon/Params", fileName = "Cannon Params")]
public class CannonParams : ScriptableObject
{
    [SerializeField] [Range(0f, 100f)] private float _rotationSpeed;
    [SerializeField] [Range(0f, 10f)] private float _rotationSpeedFactor;
    [SerializeField] [Range(20f, 180f)] private float _maxRotationAngle;
    [SerializeField] [Range(0f, 10f)] private float _cooldownDuration;
    [SerializeField] [Range(0f, 10f)] private float _angleFactor;

    public float RotationSpeed => _rotationSpeed;
    public float MaxRotationAngle => _maxRotationAngle;
    public float CooldownDuration => _cooldownDuration;
    public float AngleFactor => _angleFactor;
    public float RotationSpeedFactor => _rotationSpeedFactor;
}