using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    public Transform forwardTransform;
    public float moveSpeed = 3f;

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

    private void FixedUpdate()  //
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
}
