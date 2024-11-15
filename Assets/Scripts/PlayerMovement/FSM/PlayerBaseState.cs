using UnityEngine;

public class PlayerBaseState : State
{
    protected PlayerMovement playerMovement;

    protected static Vector2 s_currentSpeed;
    protected static bool s_grounded;

    protected Vector2 inputDirection;

    public PlayerBaseState(StateMachine stateMachine, PlayerMovement playerMovement) : base(stateMachine)
    {
        this.playerMovement = playerMovement;
    }

    public override void Update()
    {
        base.Update();
        inputDirection = playerMovement.InputDirection;
        Move();
        CheckGround();
        CheckCollision();
    }

    private void Move()
    {
        s_currentSpeed.x = Mathf.MoveTowards(s_currentSpeed.x, inputDirection.x * playerMovement.MaxSpeed, playerMovement.MovementSmoothing * Time.deltaTime);
        playerMovement.transform.Translate(s_currentSpeed * Time.deltaTime);
    }

    private void CheckCollision()
    {
        BoxCollider2D collider = playerMovement.Collider;
        Collider2D[] hits = Physics2D.OverlapBoxAll(playerMovement.transform.position, collider.size, 0);

        foreach (Collider2D hit in hits)
        {
            if (hit == collider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(collider);

            if (colliderDistance.isOverlapped)
            {
                playerMovement.transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
            }
        }
    }
    private void CheckGround()
    {
        BoxCollider2D collider = playerMovement.Collider;
        s_grounded = Physics2D.BoxCast(collider.bounds.center, collider.size - new Vector2(0.1f, 0f), 0, Vector2.down, playerMovement.GroundDistance, playerMovement.GroundLayerMask);
    }
}
