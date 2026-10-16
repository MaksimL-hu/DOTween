using DG.Tweening;
using UnityEngine;

public class LoopedRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _endRotation;
    [SerializeField] private float _duration = 3f;

    private void Start()
    {
        transform.DOLocalRotate(_endRotation, _duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}