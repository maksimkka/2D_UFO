using Code.HUD;
using UnityEngine;

namespace Code.Main
{
    public class LevelEntryPoint : MonoBehaviour
    {
        [SerializeField]
        private ScreenService screenService;

        private void Awake()
        {
            Time.timeScale = 0;
            ScreenSwitcher.Initialize(screenService.screens, screenService.gameObject);
            ScreenSwitcher.ShowScreen(ScreenType.Menu);
        }
    }
}