using System;
using KinematicCharacterController;
using UnityEngine;

public class Deathplane : MonoBehaviour
{
  public Vector3 RespawnPoint;
  private void OnTriggerEnter(Collider other)
  {
    var kinematicCharacterMotor = other.gameObject.GetComponent<KinematicCharacterMotor>();
    kinematicCharacterMotor?.SetPosition(RespawnPoint);
  }
}
