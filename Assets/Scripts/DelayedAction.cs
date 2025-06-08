using System;
using UnityEngine;
using UnityEngine.Serialization;

public class DelayedAction : MonoBehaviour
{
  public float ActionDelay = 45f;

  public Action Action;
  private float _startTime;

  public void Start()
  {
    Action = () => { Destroy(gameObject); };
    _startTime = Time.time;
  }
  private void Update()
  {
    if (_startTime + ActionDelay < Time.time)
    {
      Debug.Log("Delayed Action");
      Action?.Invoke();
    }
  }
  public void ResetTimer()
  {
    _startTime = Time.time;
  }
}