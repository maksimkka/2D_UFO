using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;

namespace Code.Services.Effects.DoTween
{
    public static class DoTweenEffectsLibrary
    {
        public static Tweener DoSimpleBounce(this Transform transform, float duration = 0.8f, float target = 0.75f,
            Ease ease = Ease.OutElastic)
        {
            return transform.DOScale(new Vector2(2, 2) * target, duration)
                .From()
                .SetEase(ease)
                .SetUpdate(true);
        }

        public static Tweener DoPulse(this Transform transform, float duration = 1f, float target = 1.5f, 
            Ease ease = Ease.Linear)
        {
            return transform.DOScale(Vector3.one * target, duration)
                .SetEase(ease)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public static Tweener DoChangeColor(this Material material, Ease ease = Ease.Linear, float duration = 0.1f)
        {
            return material.DOFade(0, duration)
                //.From()
                .SetEase(ease)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}