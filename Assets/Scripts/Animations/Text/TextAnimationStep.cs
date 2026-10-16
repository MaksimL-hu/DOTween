using System;
using UnityEngine;

[Serializable]
public sealed class TextAnimationStep
{
    [SerializeField] private TextChangeType _type;
    [SerializeField] private string _value = "";
    [SerializeField, Min(0.01f)] private float _duration = 1f;
    [SerializeField, Min(0f)] private float _delay = 0.3f;

    public float Duration => _duration;
    public float IntervalAfter => _delay;
    public bool UseScramble => _type == TextChangeType.Scramble;

    public string GetTargetText(string currentText)
    {
        string value = _value ?? string.Empty;

        return _type == TextChangeType.Append
            ? currentText + value
            : value;
    }
}