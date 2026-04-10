using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    void Awake()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    void Start()
    {
        // 씬의 모든 Rigidbody 깨우기
        foreach (var rb in FindObjectsOfType<Rigidbody>())
        {
            rb.WakeUp();
        }
    }
}