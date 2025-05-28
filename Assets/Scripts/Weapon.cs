using System;
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

  public abstract void PrimaryFire();

  public abstract void SecondaryFire();

  protected void RegularPrimaryFire()
  {
    var parent = MuzzleFlashPoint.transform.parent;

    var worldPos = MuzzleFlashPoint.transform.position;
    var worldRot = MuzzleFlashPoint.transform.rotation;

    MuzzleFlashPoint.transform.parent = null;

    var firedAmmo = Instantiate(Ammo, worldPos, worldRot);

    MuzzleFlashPoint.transform.parent = parent;
    
    var component = firedAmmo.GetComponent<Rigidbody>();
    var shootDirection = Camera.transform.forward.normalized + new Vector3(0, 0.1f, 0);
    component.linearVelocity = shootDirection * ProjectileSpeed;
  }
}

