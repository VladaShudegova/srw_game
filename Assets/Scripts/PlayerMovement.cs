using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;
    private PlayerStateMachine _stateMachine;
    private CharacterInputController _characterInputController;

    #region Properties
    public float MaxSpeed => _config.MaxSpeed;
    public float MovementSmoothing => _config.MovementSmoothing;
    public float JumpHeight => _config.JumpHeight;
    public BoxCollider2D Collider { get; private set; }
    public bool OnGround { get; private set; }
    public Vector2 InputDirection { get; private set; }
    public Transform GroundChecker { get; private set; }
    public float CheckerRadius { get; private set; }
    public LayerMask GroundMask { get; private set; }
    public bool Jump { get; private set; }
    public float JumpBufferTime => _config.JumpBufferTime;
    public float MaxFallingSpeed => _config.MaxFallingSpeed;
    public float GroundDistance => _config.GroundDistance;
    public LayerMask GroundLayerMask => _config.GroundLayerMask;

    #endregion

    private void Awake(){
        Collider = GetComponent<BoxCollider2D>();
        _characterInputController = GetComponent<CharacterInputController>();

        _stateMachine = GetComponent<PlayerStateMachine>();
        _stateMachine.SetPlayer(this);
    }

    private void Start()
    {
        _stateMachine.EnterIn<GroundedState>();
    }

    private void Update()
    {
        InputDirection = _characterInputController.GetInput();
        _stateMachine.CurrentState.Update();
        _stateMachine.CurrentState.LogicUpdate();
    }

    private void OnEnable()
    {
        _characterInputController.jumpPerformed += () =>
        {
            Jump = true;
        };

        _characterInputController.jumpCanceled += () =>
        {
            Jump = false;
        };
    }
}
