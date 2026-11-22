using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Camera mainCamera;
    private MouseInput mouseInput;
    private Vector2 mousePosition;
    private bool leftClick;

    void Awake()
    {
        mouseInput = new MouseInput();
        mouseInput.Mouse.Position.started += OnMouseMovement;
        mouseInput.Mouse.Position.performed += OnMouseMovement;
        mouseInput.Mouse.Position.canceled += OnMouseMovement;
        
        mainCamera = Camera.main;
    }

    void OnMouseMovement(InputAction.CallbackContext context) => mousePosition = context.ReadValue<Vector2>();

    void Update()
    {
        transform.position = mainCamera.ScreenToWorldPoint(mousePosition);
        
        leftClick = mouseInput.Mouse.LeftClick.WasPressedThisFrame();
    }

    void OnEnable()
    {
        mouseInput.Enable();
    }
    void OnDisable()
    {
        mouseInput.Disable();
    }
}