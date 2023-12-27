using System.Collections;
using System.Collections.Generic;
using Code.Services.Effects.DoTween;
using DG.Tweening;
using UnityEngine;

public class GroundBorder : MonoBehaviour
{
    [field: SerializeField] public SpriteRenderer BorderMaterial { get; private set; }

    private void Awake()
    {
        DoTweenEffectsLibrary.DoChangeColor(BorderMaterial.material);
        BorderMaterial.gameObject.SetActive(false);
    }
}
