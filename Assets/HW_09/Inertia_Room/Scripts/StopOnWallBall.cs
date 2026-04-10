using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnWallBall : MonoBehaviour
{
    public Rigidbody rb;

    private void Reset()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Wall")) return;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
    }

}
