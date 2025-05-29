using System;
using UnityEngine;

namespace WeaponScripts
{
  public class CombineInk : MonoBehaviour
  {
    private float _ammoCanCollideTime;
    public float AmmoCanCollideDelay = 0.3f;
    private void Awake()
    {
      _ammoCanCollideTime = Time.time + AmmoCanCollideDelay;
    }
    private void OnTriggerEnter(Collider other)
    {
      if (other is null) return;
      if (Time.time > _ammoCanCollideTime)
      {
        HandleInkCollision(other);
      }
      else if(other.gameObject.transform.parent.localScale.x > 5f ||
              transform.parent.localScale.x > 5f)
      {
        Debug.Log($"Collided from Scale {transform.parent.localScale}");
        Debug.Log($"Collided with Scale{other.gameObject.transform.parent.localScale}");
      }
    }
    private void OnTriggerStay(Collider other)
    {
      if (Time.time > _ammoCanCollideTime)
      {
        HandleInkCollision(other);
      }
    }
    private bool HandleInkCollision(Collider other)
    {
      var ink = other.gameObject.GetComponent<CombineInk>();
      if (ink is null) return false;
      if (transform.parent.transform.localScale.x < other.transform.parent.transform.localScale.x) return false;
      if (GetInstanceID() < ink.GetInstanceID()) return false;
      var scale = transform.parent.localScale;
      scale.x += 0.2f;
      scale.z += 0.2f;
      transform.parent.localScale = scale;
      Destroy(other.gameObject.transform.parent.gameObject);
      var ammo = transform.parent.gameObject.GetComponent<Ammo>();
      if (other.gameObject.transform.parent.localScale.x > 5f)
      {
        Debug.Log($"Destroyed with {ammo.Damage} Damage");
        Debug.Log($"Destroyed from Scale {transform.parent.localScale}");
        Debug.Log($"Destroyed GO with Scale{other.gameObject.transform.parent.localScale}");
      }
      return true;
    }
  }
}