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
      float rawScrollInput = Input.GetAxisRaw(MouseScrollInput);
      var characterInputs = new PlayerCharacterInputs
      {
        // Build the CharacterInputs struct
        MoveAxisForward = Input.GetAxisRaw(VerticalInput),
        MoveAxisRight = Input.GetAxisRaw(HorizontalInput),
        CameraRotation = _camera.transform.rotation,
        JumpDown = Input.GetKeyDown(KeyCode.Space),
        CrouchDown = Input.GetKeyDown(KeyCode.C),
        CrouchUp = Input.GetKeyUp(KeyCode.C),
        Fire1Down = Input.GetKeyDown(KeyCode.Mouse0),
        Fire1Up = Input.GetKeyUp(KeyCode.Mouse0),
        Fire2Down = Input.GetKeyDown(KeyCode.Mouse1),
        Fire2Up = Input.GetKeyUp(KeyCode.Mouse1),
        WeaponNextDown = rawScrollInput > 0f,
        WeaponPreviousDown = rawScrollInput < 0f,
      };

      // Apply inputs to character
      Character.SetInputs(ref characterInputs);
    }
  }
}