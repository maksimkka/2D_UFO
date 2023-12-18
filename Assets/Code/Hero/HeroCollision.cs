using Assets.Code.Constants;
using Code.HUD;
using Code.Logger;
using System;
using UnityEngine;

namespace Assets.Code.Hero
{
    public class HeroCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.tag == Tags.Base)
            {
                Time.timeScale = 0;
                ScreenSwitcher.ShowScreen(ScreenType.LoseScreen);
            }

            if (collision.gameObject.tag == Tags.Ground)
            {
                Time.timeScale = 0;
                ScreenSwitcher.ShowScreen(ScreenType.LoseScreen);
            }
        }
    }
}
