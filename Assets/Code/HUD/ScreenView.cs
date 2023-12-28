using Code.Services.Effects.DoTween;
using UnityEngine;

namespace Code.HUD
{
    [DisallowMultipleComponent]
    public class ScreenView : MonoBehaviour
    {
        [field: SerializeField] public ScreenType type { get; private set; }

        private void OnEnable()
        {
            DoTweenEffectsLibrary.DoSimpleBounce(transform);
        }
    }
}