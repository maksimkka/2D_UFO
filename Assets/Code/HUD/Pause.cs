using Code.Logger;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.HUD
{
	public class Pause : MonoBehaviour
	{
		private bool isPause;
		private Controls controls;

		private void Awake()
		{
			controls = new Controls();
			controls.Player.Pause.Enable();
			controls.Player.Pause.performed += OnPause;
		}

		private void OnDestroy()
		{
			controls.Player.Pause.Disable();
		}

		private void OnPause(InputAction.CallbackContext context)
		{
			if (ScreenSwitcher.GetCurrentScreen() != ScreenType.Menu)
			{
				isPause = !isPause;
				if (isPause)
				{
					PauseGame();
				}
				else
				{
					UnPauseGame();
				}
			}
		}

		private void PauseGame()
		{
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.Confined;
			ScreenSwitcher.ShowScreen(ScreenType.Pause);
		}

		private void UnPauseGame()
		{
			Time.timeScale = 1;
			Cursor.lockState = CursorLockMode.Locked;
			ScreenSwitcher.ShowScreen(ScreenType.Game);
		}
	}
}