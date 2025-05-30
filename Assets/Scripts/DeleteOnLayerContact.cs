using System;
using UnityEngine;

public class DeleteOnLayerContact : MonoBehaviour
{
    public LayerMask NotInkableFloorMask;
    private float _startTime;
    public float ActionDelay = 0.2f;
    private Collider _collider;
    private void Start()
    {
        _startTime = Time.time;
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
    }
    private void Update()
    {
        if (_startTime + ActionDelay < Time.time)
        {
            _collider.enabled = true;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (_startTime is 0)
        {
            _startTime = Time.time;
            return;
        }
        int otherMask = LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer));
        if (otherMask == NotInkableFloorMask)
        {
            Debug.Log("Destroying GO");
            Destroy(transform.parent.gameObject);
        }
    }
}
