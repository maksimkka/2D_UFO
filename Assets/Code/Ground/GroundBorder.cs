using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Code.Services.Effects.DoTween;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class GroundBorder : MonoBehaviour
{
    [field: SerializeField] public SpriteRenderer BorderMaterial { get; private set; }
    [SerializeField] private float timeToDisable;
    private float currentTime;
    private CancellationTokenSource token = new CancellationTokenSource();

    private void Awake()
    {
        DoTweenEffectsLibrary.DoChangeColor(BorderMaterial.material);
        BorderMaterial.gameObject.SetActive(false);
    }

    public async void DisableBorder()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(timeToDisable), cancellationToken : token.Token);
        BorderMaterial.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        token.Cancel();
    }
}
