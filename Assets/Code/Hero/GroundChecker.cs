using Assets.Code.Constants;
using Code.HUD;
using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public event Action<bool> LeftBase;
    public event Action<bool> ReturnBase;
    public bool IsHeroBase { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Base)
        {
            IsHeroBase = true;
            ReturnBase?.Invoke(IsHeroBase);
        }

        if (collision.gameObject.tag == Tags.Ground)
        {
            Time.timeScale = 0;
            ScreenSwitcher.ShowScreen(ScreenType.LoseScreen);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Base)
        {
            IsHeroBase = false;
            LeftBase?.Invoke(IsHeroBase);
        }
    }
}
