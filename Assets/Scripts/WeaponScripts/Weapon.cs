using System;
using KinematicCharacterController;
using KinematicCharacterController.Examples;
using UnityEngine;
using Random = UnityEngine.Random;

namespace WeaponScripts
{
  public abstract class Weapon : MonoBehaviour
  {
    public GameObject Ammo;
    public string Name;
    public int Damage;
    public int MinPrimaryFireAmmo;
    public int MinSecondaryFireAmmo;
    public Transform MuzzleFlashPoint;
    public float ProjectileSpeed = 30f;
    public Camera Camera { get; set; }
    public float PrimaryFireDelay = 0.2f;
    public float SecondaryFireDelay = 1.0f;
    public int TrailCount = 3;
    public ExampleCharacterController  CharacterController;
    private float _nextPrimaryFireTime;
    private float _nextSecondaryFireTime;
    private KinematicCharacterMotor  _characterMotor;
    
    public void Initialize(Camera cam, ExampleCharacterController characterCtrl)
    {
      Camera = cam;
      CharacterController = characterCtrl;
      _characterMotor = characterCtrl.GetComponent<KinematicCharacterMotor>();
      _nextPrimaryFireTime = Time.time + PrimaryFireDelay;
      _nextSecondaryFireTime = Time.time + SecondaryFireDelay;
      Debug.Log($"Weapon {Name} Initialized");
    }

    public abstract void PrimaryFire();

    public abstract void SecondaryFire();

    protected void RegularPrimaryFire()
    {
      //Checks for Cooldown and Ammo
      if (!PrimaryFireChecks())
      {
        return;
      }
      //Subtract Fired Ammo
      CharacterController.CurrentAmmo -= MinPrimaryFireAmmo;
      //Position and Rotation
      var parent = MuzzleFlashPoint.transform.parent;
      var worldPos = MuzzleFlashPoint.transform.position;
      var worldRot = MuzzleFlashPoint.transform.rotation;
      MuzzleFlashPoint.transform.parent = null;
      
      //Trail
      var upwardsVector = new Vector3(0, 0.3f, 0);
      for (int i = 1; i <= TrailCount*2; i+=2)
      {
        var firedAmmo = Instantiate(Ammo, worldPos, worldRot);
        var component = firedAmmo.GetComponent<Rigidbody>();
        var shootDirection = Camera.transform.forward.normalized + upwardsVector;
        var speed = shootDirection * ((ProjectileSpeed /( ((i / 2) *0.5f) + 1)) * 1.3f);
        if (i > 1)
        {
          speed *= (Random.value + 0.5f);
        }
        if (i>TrailCount*2-2)
        {
          speed = Vector3.zero;
        }
        Debug.Log(_characterMotor.Velocity);
        component.linearVelocity = speed + _characterMotor.Velocity*1.2f;
      }
      //Reparent
      MuzzleFlashPoint.transform.parent = parent;
    }
    protected bool PrimaryFireChecks()
    {
      if (Time.time < _nextPrimaryFireTime)
      {
        return false;
      }
      if (CharacterController is null)
      {
        Debug.LogError("CharacterController is null! Cannot check ammo.", this);
        return false;
      }
      if (CharacterController.CurrentAmmo-MinPrimaryFireAmmo<0)
      {
        return false;
      }
      
      _nextPrimaryFireTime = Time.time + PrimaryFireDelay;
      return true;
    }
  }
}