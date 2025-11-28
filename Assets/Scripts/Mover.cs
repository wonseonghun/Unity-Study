using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{

    [Header("이동")]  //카테고리로 나눌 수 있음. 
    public Transform forwardTransform;



    [Range(1f,100f)]
    public float moveSpeed = 3f;

    [Space(20f), Header("점프")]  
    [Range(0.5f, 10f)]
    public float jumpHeigtht = 2f;
    public int maxJumpCount = 1;
    public LayerMask groundLayer;
    [Range(0.1f, 10f)]
    public float groundRadius = 0.3f;
    public float groundOffest = 0f;

    public bool Grounded
    {
        get => _isGrounded;
        private set
        {
            if(_isGrounded == value)
                return;

            _isGrounded = value;
            if (value)
            {
                _remainJumpCount = maxJumpCount;
            }
        }
    }
    private bool _isGrounded;
    private int _remainJumpCount;

    private Rigidbody _rigidBody;
    private Vector2 _direction;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)    // inputsystem안에 함수가 있어서 
    {
        _direction = value.Get<Vector2>();   // OnMove 함수 안에서 플레이어가 입력하는 input인 value값을 _direction에 저장한다  // get <>를 어떻게 써야 하는지 ??
    }

    public void OnJump()
    {
        if (_remainJumpCount == 0)
            return;

        _rigidBody.AddForce( Mathf.Sqrt(jumpHeigtht * -2f * Physics.gravity.y) * Vector3.up, ForceMode.VelocityChange);

    }

    private void FixedUpdate()  
    {
       Vector3 forward = forwardTransform.forward;  // 캐릭터의 방향을 알아서 앞 방향을 알기 위해서
       Vector3 right = forwardTransform.right;  // 캐릭터의 우측 방향을 알아서 이를 이용해 우측 방향을 설정한다.
       forward.y = 0f;
        forward.Normalize();
        right.y = 0f;
        right.Normalize();

        Vector2 direction = moveSpeed * Time.fixedDeltaTime * _direction;
        Vector3 newPos = (direction.y * forward) + (direction.x * right)+ _rigidBody.position;
        _rigidBody.MovePosition(newPos);   // ? 

    }

    private void Update()
    {
        Grounded = GroundCheck();
    }

    private bool GroundCheck()
    {
        Vector3 gPos = transform.position;
        gPos.y += groundOffest;

        return Physics.CheckSphere(gPos, groundRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()  //스크립트가 달려 있는 오브젝트를 선택하는 순간 scene view에 그림을 그릴 수 있게 한다.
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        if (_isGrounded)
        {
            Gizmos.color = transparentGreen;
        }
        else 
            Gizmos.color= transparentRed;

        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y+ groundOffest, transform.position.z), groundRadius);
           
        
    }
}
