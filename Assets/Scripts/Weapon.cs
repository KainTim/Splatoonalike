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
  public int minPrimaryFireAmmoCount;
  public int minSecondaryFireAmmoCount;
  public Transform MuzzleFlashPoint;
  public float ProjectileSpeed = 30f;
  public Camera cam

  abstract public void PrimaryFire();

  abstract public void SecondaryFire();

  private void RegularPrimaryFire()
  {
    var parent = MuzzleFlashPoint.transform.parent;

    Vector3 worldPos = MuzzleFlashPoint.transform.position;
    Quaternion worldRot = MuzzleFlashPoint.transform.rotation;

    MuzzleFlashPoint.transform.parent = null;

    var firedAmmo = Instantiate(Ammo, worldPos, worldRot);

    MuzzleFlashPoint.transform.parent = parent;
    
    var component = firedAmmo.GetComponent<Rigidbody>();
    Vector3 shootDirection = Camera.main!.transform.forward.normalized + new Vector3(0, 0.1f, 0);
    component.linearVelocity = shootDirection * ProjectileSpeed;
  }
}

