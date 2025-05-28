using UnityEngine;
using UnityEngine.Rendering;

public class BennelliM4 : Weapon
{
  public override void PrimaryFire()
  {
    RegularPrimaryFire();
  }

  public override void SecondaryFire()
  {
    Debug.Log("Secondary Fire of Bennelli_M4");
  }
}
