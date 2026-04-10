using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPushBall : MonoBehaviour, IRayInteractable
{
    public float pushForce = 2.5f;
    public Transform rayOrigin;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnRayEnter() { }
    public void OnRayStay() { }
    public void OnRayExit() { }

    public void OnRayClick()
    {
        if (rayOrigin == null) return;

        Vector3 pushDir = -rayOrigin.forward;
        pushDir.y = 0f;
        pushDir.Normalize();

        rb.AddForce(pushDir * pushForce, ForceMode.Impulse);
    }
}
