using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Code.Scanner
{
    class LocationScanner : MonoBehaviour
    {
        [SerializeField] private GameObject radarWave;
        [SerializeField] private float cooldown;

        private float currentCoolDown;
        private bool isReadyLaunchWave;
        private Controls controls;

        private void Awake()
        {
            controls = new Controls();
            controls.Player.LaunchWave.performed += LaunchWave;
        }

        private void OnEnable()
        {
            controls.Player.LaunchWave.Enable();
        }

        private void OnDisable()
        {
            controls.Player.LaunchWave.Disable();
        }

        public void Update()
        {
            CountDown();
        }

        private void CountDown()
        {
            currentCoolDown += Time.deltaTime;

            if(currentCoolDown >= cooldown)
            {
                isReadyLaunchWave = true;
            }
        }

        private void LaunchWave(InputAction.CallbackContext context)
        {
            if(isReadyLaunchWave)
            {
                Instantiate(radarWave, transform.position, Quaternion.identity);
                isReadyLaunchWave = false;
            }
        }

        private void OnDestroy()
        {
            controls.Player.LaunchWave.performed -= LaunchWave;
        }
    }
}
