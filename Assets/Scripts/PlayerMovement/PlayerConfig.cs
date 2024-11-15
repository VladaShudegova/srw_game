using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game Data/ Player Config")]
public class PlayerConfig : ScriptableObject
{
    public float MaxSpeed;
    public float MovementSmoothing;

    public float JumpHeight;
    public float MaxFallingSpeed;
    public float JumpBufferTime;

    public float GroundDistance;
    public LayerMask GroundLayerMask;
}
