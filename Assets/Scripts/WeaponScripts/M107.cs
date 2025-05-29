using UnityEngine;

namespace WeaponScripts
{
  public class M107 : Weapon
  {
    public override void PrimaryFire()
    {
      RegularPrimaryFire();
    }

    public override void SecondaryFire()
    {
      Debug.Log("Secondary Fire of M107");
    }
  }
}