using System;

using UnityEngine;

public class GravityScale : MonoBehaviour
{
  public float gravityScale = 1f;

  private Rigidbody rb;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.useGravity = false;
  }

  private void FixedUpdate()
  {
    rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
  }
}
