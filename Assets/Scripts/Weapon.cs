using System;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.Serialization;

public abstract class Weapon : MonoBehaviour
{
  public GameObject Ammo;
  public string Name;
  public int Damage;
  public int MaxAmmoCount;
  public int CurrentAmmo;
  public int MinPrimaryFireAmmoCount;
  public int MinSecondaryFireAmmoCount;
  public Transform MuzzleFlashPoint;
  public float ProjectileSpeed = 30f;
  public Camera Camera;
  public float PrimaryFireDelay = 0.2f;
  public float SecondaryFireDelay = 1.0f;
  private float _nextPrimaryFireTime;
  private float _nextSecondaryFireTime;

  private void Awake()
  {
    Camera = Camera.main!;
    _nextPrimaryFireTime = Time.time;
    _nextSecondaryFireTime = Time.time;
  }

  public abstract void PrimaryFire();

  public abstract void SecondaryFire();

  protected void RegularPrimaryFire()
  {
    if (Time.time < _nextPrimaryFireTime)
    {
      return;
    }
    _nextPrimaryFireTime = Time.time + PrimaryFireDelay;
    
    var parent = MuzzleFlashPoint.transform.parent;

    var worldPos = MuzzleFlashPoint.transform.position;
    var worldRot = MuzzleFlashPoint.transform.rotation;

    MuzzleFlashPoint.transform.parent = null;
    
    var upwardsVector = new Vector3(0, 0.3f, 0);
    for (int i = 1; i <= 3; i++)
    {
      var firedAmmo = Instantiate(Ammo,worldPos, worldRot);
      var component = firedAmmo.GetComponent<Rigidbody>();
      var shootDirection = Camera.transform.forward.normalized + upwardsVector;
      component.linearVelocity = shootDirection * (ProjectileSpeed/(i*0.7f));
    }

    MuzzleFlashPoint.transform.parent = parent;
  }
}

