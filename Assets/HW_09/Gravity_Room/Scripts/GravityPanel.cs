using UnityEngine;

public class GravityPanel : MonoBehaviour, IRayInteractable
{
    [Header("중력 설정")]
    public float gravityValue = 9.81f;
    public string planetName = "지구";
    public BallReset ball;

    private bool isTriggered = false;

    public void OnRayEnter() { }
    public void OnRayStay() { }
    public void OnRayExit() { }

    public void OnRayClick()
    {
        if (isTriggered) return;
        isTriggered = true;

        Physics.gravity = new Vector3(0, -gravityValue, 0);

        if (ball != null)
        {
            ball.ResetBall();
            ball.Release();
        }

        Invoke("ResetTrigger", 1f);
    }

    void ResetTrigger()
    {
        isTriggered = false;
    }
}