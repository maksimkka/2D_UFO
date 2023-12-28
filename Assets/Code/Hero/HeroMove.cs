using Assets.Code.Hero;
using Code.Logger;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D herorigidbody2D;
    [SerializeField] private GroundChecker groundChecker;
    private Camera camera;
    private Controls controls;
    private bool isMove;
    private bool isReadyRotate;
    private const int degree = 270;
    private Vector2 inputValue;
    private float currentTime;
    private float timeToRotateReady = 0.5f;

    private void Awake()
    {
        controls = new Controls();
        camera = Camera.main;
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Movement.Disable();
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;
        TimeToReadyRotate();
        CheckInput();
        Rotate();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void CheckInput()
    {
        inputValue = new Vector2(0, controls.Player.Movement.ReadValue<Vector2>().y);
        isMove = inputValue.y != 0;
    }

    private void Movement()
    {
        if (!isMove) return;
        var movement = inputValue;
        movement.Normalize();
        herorigidbody2D.velocity = transform.TransformDirection(Vector3.up) * movement.y * speed;
    }

    private void Rotate()
    {
        if (groundChecker.IsHeroBase || !isReadyRotate) return;
        var value = controls.Player.MousePosition.ReadValue<Vector2>();
        var mousePosition = camera.ScreenToWorldPoint(value);
        var angle = Mathf.Atan2(mousePosition.y - transform.position.y,
            mousePosition.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + degree));
    }

    private void TimeToReadyRotate()
    {
        if (groundChecker.IsHeroBase)
        {
            currentTime = timeToRotateReady;
            isReadyRotate = false;
        }

        else
        {
            currentTime -= Time.deltaTime;
        }

        if (currentTime <= 0f)
        {
            isReadyRotate = true;
        }
    }
}
