using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class LoopedColorChanger : MonoBehaviour
{
    [SerializeField] private Color _endColor;
    [SerializeField] private float _duration = 3f;

    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Start()
    {
        _material.DOColor(_endColor, _duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}