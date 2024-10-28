<<<<<<< HEAD
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class Rotate3DObject : MonoBehaviour
{
    #region Input Actions
    [SerializeField]
    private InputActionAsset _actions;

    public InputActionAsset actions
    {
        get => _actions;
        set => _actions = value;
    }

    protected InputAction leftClickPressedInputAction { get; set; }

    protected InputAction mouseLookInputAction { get; set; }

    #endregion

    #region Variables

    private bool _rotateAllowed;

    private Camera _camera;

    [SerializeField] private float _speed;

    [SerializeField] private bool _inverted;

    #endregion

    private void Awake()
    {
        InitializeInputSystem();
    }

    private void Start()
    {

        _camera = Camera.main;
        _rotateAllowed = false;
    }

    private void InitializeInputSystem()
    {
        leftClickPressedInputAction = actions.FindAction("Left Click");
        if (leftClickPressedInputAction != null)
        {
            leftClickPressedInputAction.started += OnLeftClickPressed;
            leftClickPressedInputAction.performed += OnLeftClickPressed;
            leftClickPressedInputAction.canceled += OnLeftClickPressed;
        }

        mouseLookInputAction = actions.FindAction("Mouse Look");

        actions.Enable();
    }

    protected virtual void OnLeftClickPressed(InputAction.CallbackContext context)
    {
        if ((context.started || context.performed) && SceneManager.rotate)
        {
            _rotateAllowed = true;
        }
        else if (context.canceled)
            _rotateAllowed = false;

    }

    protected virtual Vector2 GetMouseLookInput()
    {
        if (mouseLookInputAction != null)
            return mouseLookInputAction.ReadValue<Vector2>();

        return Vector2.zero;
    }

    private void Update()
    {
        if (!SceneManager.rotate)
            return;

            if (!_rotateAllowed)
                return;

            Vector2 MouseDelta = GetMouseLookInput();

            MouseDelta *= _speed * Time.deltaTime;

            transform.Rotate(Vector3.up * (_inverted ? 1 : -1), MouseDelta.x, Space.World);
            transform.Rotate(Vector3.right * (_inverted ? -1 : 1), MouseDelta.y, Space.World);
        
    }

   
=======
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class Rotate3DObject : MonoBehaviour
{
    #region Input Actions
    [SerializeField]
    private InputActionAsset _actions;

    public InputActionAsset actions
    {
        get => _actions;
        set => _actions = value;
    }

    protected InputAction leftClickPressedInputAction { get; set; }

    protected InputAction mouseLookInputAction { get; set; }

    #endregion

    #region Variables

    private bool _rotateAllowed;

    private Camera _camera;

    [SerializeField] private float _speed;

    [SerializeField] private bool _inverted;

    #endregion

    private void Awake()
    {
        InitializeInputSystem();
    }

    private void Start()
    {

        _camera = Camera.main;
        _rotateAllowed = false;
    }

    private void InitializeInputSystem()
    {
        leftClickPressedInputAction = actions.FindAction("Left Click");
        if (leftClickPressedInputAction != null)
        {
            leftClickPressedInputAction.started += OnLeftClickPressed;
            leftClickPressedInputAction.performed += OnLeftClickPressed;
            leftClickPressedInputAction.canceled += OnLeftClickPressed;
        }

        mouseLookInputAction = actions.FindAction("Mouse Look");

        actions.Enable();
    }

    protected virtual void OnLeftClickPressed(InputAction.CallbackContext context)
    {
        if ((context.started || context.performed) && SceneManager.rotate)
        {
            _rotateAllowed = true;
        }
        else if (context.canceled)
            _rotateAllowed = false;

    }

    protected virtual Vector2 GetMouseLookInput()
    {
        if (mouseLookInputAction != null)
            return mouseLookInputAction.ReadValue<Vector2>();

        return Vector2.zero;
    }

    private void Update()
    {
        if (!SceneManager.rotate)
            return;

            if (!_rotateAllowed)
                return;

            Vector2 MouseDelta = GetMouseLookInput();

            MouseDelta *= _speed * Time.deltaTime;

            transform.Rotate(Vector3.up * (_inverted ? 1 : -1), MouseDelta.x, Space.World);
            transform.Rotate(Vector3.right * (_inverted ? -1 : 1), MouseDelta.y, Space.World);
        
    }

   
>>>>>>> f9897ae9680b053245c1897c9a1e18f83d22fd7f
}