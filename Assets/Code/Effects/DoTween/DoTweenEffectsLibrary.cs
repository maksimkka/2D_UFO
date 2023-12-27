using Cysharp.Threading.Tasks;
using DG.Tweening;
using JetBrains.Annotations;
using System;
using UnityEngine;

namespace Code.Services.Effects.DoTween
{
    public static class DoTweenEffectsLibrary
    {
        public static Tweener DoSimpleBounce(this Transform transform, float duration = 0.3f, float target = 0.75f,
            Ease ease = Ease.OutElastic)
        {
            return transform.DOScale(Vector3.one * target, duration)
                .From()
                .SetEase(ease);
        }

        public static Tweener DoBounceRectTransform(this Transform transform, float duration = 0.3f, float targer = 0.75f,
            Ease ease = Ease.OutElastic)
        {
            var rectTransform = transform.GetComponent<RectTransform>();
            return rectTransform.DOSizeDelta(new Vector2(1.4f, 1.4f) * targer, duration)
                .From()
                .SetEase(ease)
                .SetLoops(-1, LoopType.Yoyo);
        }

        //public static async UniTask<Tweener> DoSimpleBounce(this Transform transform, float duration = 0.3f, float target = 0.75f,
        //    Ease ease = Ease.OutElastic)
        //{

        //    await UniTask.Delay(TimeSpan.FromSeconds(0.4f));
        //    var tweener = transform.DOScale(Vector3.one * target, duration)
        //        .From()
        //        .SetEase(ease);

        //    return tweener;
        //}

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