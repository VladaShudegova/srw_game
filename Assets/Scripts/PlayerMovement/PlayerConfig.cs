using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game Data/ Player Config")]
public class PlayerConfig : ScriptableObject
{
    public float MaxSpeed;
    public float MovementSmoothing;

    public float JumpHeight;
}
