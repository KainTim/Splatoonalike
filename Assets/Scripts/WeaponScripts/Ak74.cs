using UnityEngine;

namespace WeaponScripts
{
  public class Ak74 : Weapon
  {
    public override void PrimaryFire()
    {
      RegularPrimaryFire();
    }

    public override void SecondaryFire()
    {
      Debug.Log("Secondary Fire of AK74");
    }
  }
}