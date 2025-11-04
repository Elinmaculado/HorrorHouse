using UnityEngine;
using UnityEngine.InputSystem;

public class FPSMovement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInputs playerInput;

    public float movementSpeed = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //playerInput = InputManager.Inputs;
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();

    }
        // Update is called once per frame
    void Update() 
    {
        PlayerMovement();    
    }

    private void PlayerMovement()
    {
        Transform camTransform = Camera.main.transform;
        Vector3 camForward = camTransform.forward;
        Vector3 camRight = camTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();
        
        
        
        
        var movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 movement = camForward * movementInput.y + camRight * movementInput.x;
        controller.Move(movement * movementSpeed * Time.deltaTime);
    }
}
