using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;

namespace KinematicCharacterController.Examples
{
    public class ExamplePlayer : MonoBehaviour
    {
        public ExampleCharacterController Character;

        private const string MouseXInput = "Mouse X";
        private const string MouseYInput = "Mouse Y";
        private const string MouseScrollInput = "Mouse ScrollWheel";
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        private const string ClickInput = "Mouse Click";
        private Camera _camera;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            HandleCharacterInput();
        }

        private void HandleCharacterInput()
        {
            PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

            // Build the CharacterInputs struct
            characterInputs.MoveAxisForward = Input.GetAxisRaw(VerticalInput);
            characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
            characterInputs.CameraRotation = _camera.transform.rotation;
            characterInputs.JumpDown = Input.GetKeyDown(KeyCode.Space);
            characterInputs.CrouchDown = Input.GetKeyDown(KeyCode.C);
            characterInputs.CrouchUp = Input.GetKeyUp(KeyCode.C);
            characterInputs.Fire1Down = Input.GetKeyDown(KeyCode.Mouse0);
            characterInputs.Fire1Up = Input.GetKeyUp(KeyCode.Mouse0);
            characterInputs.Fire2Down = Input.GetKeyDown(KeyCode.Mouse1);
            characterInputs.Fire2Up = Input.GetKeyUp(KeyCode.Mouse1);

            // Apply inputs to character
            Character.SetInputs(ref characterInputs);
        }
    }
}
