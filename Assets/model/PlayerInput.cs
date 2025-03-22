using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; private set; }

    [Header("Input Type")]
    public bool useController = false; // Toggle between Keyboard & Controller

    [Header("Action Keys")]
    public KeyCode meleeAttackKey = KeyCode.J;
    public KeyCode rangedAttackKey = KeyCode.K;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Movement Keys")]
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;

    [Header("Controller Buttons")]
    public string meleeAttackButton = "X";
    public string rangedAttackButton = "Right Bumper";
    public string jumpButton = "A";
    public string sprintButton = "Left Stick";

    [Header("Axis Settings")]
    public string horizontalAxis = "Horizontal"; // LeftStick Horizontal
    public string verticalAxis = "Vertical"; // LeftStick Vertical

    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool MeleeAttackPressed { get; private set; }
    public bool RangedAttackPressed { get; private set; }
    public bool IsSprinting { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (useController)
        {
            // Controller Input Handling
            HorizontalInput = Input.GetAxis(horizontalAxis);
            VerticalInput = Input.GetAxis(verticalAxis);
            JumpPressed = Input.GetButtonDown(jumpButton);
            MeleeAttackPressed = Input.GetButtonDown(meleeAttackButton);
            RangedAttackPressed = Input.GetButtonDown(rangedAttackButton);
            IsSprinting = Input.GetButton(sprintButton);
        }
        else
        {
            // Keyboard Input Handling
            HorizontalInput = 0;
            if (Input.GetKey(moveLeftKey)) HorizontalInput = -1;
            if (Input.GetKey(moveRightKey)) HorizontalInput = 1;

            JumpPressed = Input.GetKeyDown(jumpKey);
            MeleeAttackPressed = Input.GetKeyDown(meleeAttackKey);
            RangedAttackPressed = Input.GetKeyDown(rangedAttackKey);
            IsSprinting = Input.GetKey(sprintKey);
        }
    }
}
