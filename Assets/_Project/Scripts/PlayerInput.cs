using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string JumpButton = "Jump";

    public float HorizontalValue { get; private set; }
    public bool IsJumpPressed { get; private set; }

    private void Update()
    {
        HorizontalValue = Input.GetAxis(HorizontalAxis);

        if (Input.GetButtonDown(JumpButton))
        {
            IsJumpPressed = true;
        }
    }

    public void ConsumeJump()
    {
        IsJumpPressed = false;
    }
}