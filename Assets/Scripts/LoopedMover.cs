using DG.Tweening;
using UnityEngine;

public class LoopedMover : MonoBehaviour
{
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private float _duration = 3f;

    private void Start()
    {
        transform.DOMove(_endPosition, _duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}