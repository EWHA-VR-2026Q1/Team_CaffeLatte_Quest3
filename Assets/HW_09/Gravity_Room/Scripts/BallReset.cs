using UnityEngine;

public class BallReset : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        rb.isKinematic = true; // 처음엔 고정

        Collider col = GetComponent<Collider>();
        PhysicMaterial bounceMat = new PhysicMaterial();
        bounceMat.bounciness = 0.8f;
        bounceMat.frictionCombine = PhysicMaterialCombine.Minimum;
        bounceMat.bounceCombine = PhysicMaterialCombine.Maximum;
        col.material = bounceMat;
    }

    public void ResetBall()
    {
        rb.isKinematic = true; // 다시 고정
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }

    public void Release()
    {
        rb.isKinematic = false; // 중력 영향 받기 시작
    }
}