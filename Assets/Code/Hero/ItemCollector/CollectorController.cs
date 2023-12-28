using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollectorController : MonoBehaviour
{
    [SerializeField] private GameObject itemCollector;
    [SerializeField] private float reloadTime;
    [SerializeField] private float lifeTime;
    private CancellationTokenSource token = new CancellationTokenSource();
    private Controls controls;
    private bool isReadyCollect;
    private bool isReload;

    private void Awake()
    {
        controls = new Controls();
        controls.Player.ItemCollector.Enable();
        controls.Player.ItemCollector.performed += OnLaunchCollector;
    }

    private void OnDestroy()
    {
        controls.Player.Pause.Disable();
        token.Cancel();
    }

    private void Update()
    {
        Reload();
    }

    private void OnLaunchCollector(InputAction.CallbackContext context)
    {
        if (isReadyCollect)
        {
            itemCollector.SetActive(true);
            isReadyCollect = false;
            LifeTime();
        }
    }

    private async void Reload()
    {
        if(!isReload)
        {
            isReload = true;
            await UniTask.Delay(TimeSpan.FromSeconds(reloadTime), cancellationToken: token.Token);
            isReadyCollect = true;
        }
    }

    private async void LifeTime()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(lifeTime), cancellationToken: token.Token);
        itemCollector.SetActive(false);
        isReload = false;
    }
}
