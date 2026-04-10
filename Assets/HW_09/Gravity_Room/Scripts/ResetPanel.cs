using UnityEngine;

public class ResetPanel : MonoBehaviour, IRayInteractable
{
    public BallReset ball;

    public void OnRayEnter() { }
    public void OnRayStay() { }
    public void OnRayExit() { }

    public void OnRayClick()
    {
        if (ball != null)
            ball.ResetBall();
    }
}