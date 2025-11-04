using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLightToogle : MonoBehaviour
{
    
    private PlayerInputs playerInput;
    public GameObject flashLight;
    private bool isOn = true;

    public AudioSource sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
    }

    void Start()
    {
        //playerInput = InputManager.Inputs;
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.Player.ToogleFlashLight.WasPressedThisFrame())
        {
            sound.Play();
            ToogleFlashLight();
        }
    }

    private void ToogleFlashLight()
    {
        if (isOn)
        {
            flashLight.SetActive(false);
            isOn = false;
        }
        else
        {
            flashLight.SetActive(true);
            isOn = true;
        }
    }
}
