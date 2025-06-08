using System.Collections;
using UnityEngine;

namespace WeaponScripts
{
  public class CombineInk : MonoBehaviour
  {
    public float AmmoCanCollideDelay = 1f;
    public float CombineScale = 0.4f;
    public float MaxSize = 5;
    private Collider _collider;
    public float MaxSizeDestroyDelay = 120f;
    private void Awake()
    {
      _collider = GetComponent<Collider>();
      _collider.enabled = false;
      StartCoroutine(EnableColliderAfterDelay(AmmoCanCollideDelay));
    }
    private void OnTriggerEnter(Collider other)
    {
      if (other is null) return;
      HandleInkCollision(other);
    }
    private bool HandleInkCollision(Collider other)
    {
      var ink = other.gameObject.GetComponent<CombineInk>();
      var destroy = transform.parent.gameObject.GetComponent<DelayedAction>();
      if (ink is null) return false;
      if (transform.parent.transform.localScale.x < other.transform.parent.transform.localScale.x) return false;
      if (GetInstanceID() < ink.GetInstanceID()) return false;

      var ammo = transform.parent.gameObject.GetComponent<Ammo>();
      var scale = transform.parent.localScale;
      var otherScale = other.transform.parent.localScale;
      
      // Cap to MaxSize 
      if (scale.x >= MaxSize || scale.z >= MaxSize) return false;
      if (otherScale.x >= MaxSize || otherScale.z >= MaxSize) return false;

      if (ammo.Damage < 1)
      {
        //Scale directly
        scale.x += CombineScale;
        scale.z += CombineScale;
      }
      else
      {
        //Scale based on ammo
        scale.x += CombineScale * (ammo.Damage/20f);
        scale.z += CombineScale * (ammo.Damage/20f);
      }
      //Average the two positions
      transform.parent.position = (other.transform.parent.position+transform.parent.position)/2;
      if (scale.x>= MaxSize)
      {
        destroy.ActionDelay = MaxSizeDestroyDelay;
        destroy.ResetTimer();
      }
      
      transform.parent.localScale = scale;
      Destroy(other.gameObject.transform.parent.gameObject);
      return true;
    }

    private IEnumerator EnableColliderAfterDelay(float delay)
    {
      yield return new WaitForSeconds(delay);
      _collider.enabled = true;
    }
  }
}