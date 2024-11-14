using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;
    private PlayerStateMachine _stateMachine;

    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _checkerRadius;
    [SerializeField] private LayerMask _groundMask;

    #region Properties

    public float MaxSpeed => _config.MaxSpeed;
    public float MovementSmoothing => _config.MovementSmoothing;
    public float JumpHeight => _config.JumpHeight;
    public BoxCollider2D Collider { get; private set; }
    public bool OnGround { get; private set; }

    #endregion

    private void Awake(){
        Collider = GetComponent<BoxCollider2D>();
        _stateMachine = GetComponent<PlayerStateMachine>();
        _stateMachine.SetPlayer(this);
    }

    private void Start()
    {
        _stateMachine.EnterIn<GroundedState>();
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
        _stateMachine.CurrentState.LogicUpdate();
        //CheckGround();

        Debug.Log(_stateMachine.CurrentState);
    }

    //private void CheckGround()
    //{
    //    OnGround = Physics2D.OverlapCircle(_groundChecker.position, _checkerRadius, _groundMask);
    //}

}
