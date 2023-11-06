
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;

    private TouchControl toutcControl;
    private void Awake()
    {
        toutcControl = new TouchControl();
    }

    private void OnEnable()
    {
        toutcControl.Enable();
    }

    private void OnDisable()
    {
        toutcControl.Disable();
    }

    private void Start()
    {
        toutcControl.Touch.TouchPress.started += ctx => StartTouch(ctx);
        toutcControl.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch started " + toutcControl.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null) OnStartTouch(toutcControl.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended");
        if (OnEndTouch != null) OnEndTouch(toutcControl.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }
}
