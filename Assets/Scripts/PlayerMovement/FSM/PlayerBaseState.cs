using UnityEngine;

public class PlayerBaseState : State
{
    protected CharacterInputController inputController;
    protected PlayerMovement playerMovement;

    protected Vector2 _currentSpeed;
    protected bool grounded;

    public PlayerBaseState(StateMachine stateMachine, PlayerMovement playerMovement, CharacterInputController inputController) : base(stateMachine)
    {
        this.inputController = inputController;
        this.playerMovement = playerMovement;
    }

    public override void Update()
    {
        base.Update();
        Move();
        CheckCollision();
    }

    private void Move()
    {
        Vector2 inputDirection = inputController.GetInput();
        _currentSpeed.x = Mathf.MoveTowards(_currentSpeed.x, inputDirection.x * playerMovement.MaxSpeed, playerMovement.MovementSmoothing * Time.deltaTime);
        if(playerMovement.OnGround)
        {
            _currentSpeed.y = 0f;
        }
        else
        {
            _currentSpeed.y += Physics2D.gravity.y * Time.deltaTime;
        }
        playerMovement.transform.Translate(_currentSpeed * Time.deltaTime);
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

            if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && _currentSpeed.y <= 0)
            {
                grounded = true;
            }
        }
    }
}
