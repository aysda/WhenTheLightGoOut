using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CharacterController controller;
    private Vector2 moveInput;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveInput = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
            if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
            if (Keyboard.current.dKey.isPressed) moveInput.x += 1;
            if (Keyboard.current.aKey.isPressed) moveInput.x -= 1;
        }

        Vector3 move =
            transform.forward * moveInput.y +
            transform.right * moveInput.x;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}