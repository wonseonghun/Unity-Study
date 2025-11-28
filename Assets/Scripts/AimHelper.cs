using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimHelper : MonoBehaviour
{

    public Transform camTransform;
    [Range(1f,100f)]                            //1에서 100까지만 넣어라. -방지용
    public float sensitivity = 5f;


    private Vector2 _deltavalue;
    private float _yaw;
    private float _pitch;
    
    
    void Start()
    {
        Vector3 euler = camTransform.rotation.eulerAngles;
        _pitch = euler.x;
        _yaw = euler.y;

        Cursor.lockState = CursorLockMode.Locked;     // 커서를 가운데로 잠군다. FPS 처럼
        Cursor.visible = false;  // 마우스 포인터를 끈다.
    }

    public void OnLook(InputValue value) //  마우스의 움직임을 받기 위해 inputvalue를 매개변수로 넣어줌
    {
        _deltavalue = value.Get<Vector2>();
    }
    void Update()
    {
        _pitch -= _deltavalue.y * sensitivity*Time.deltaTime;  //마우스의 위 아래 움직임을 파악 //피치는 각도기에 위쪽으로 가면 -가 되어서 // 기존의 pitch위치에서 움직인 거리만큼 추가됨.  // ???  
        _pitch = Mathf.Clamp(_pitch, -90f, 90f);  // -90도에서 90도까지 회전 가능하게 만드는 함수, 제한을 둔다.

        _yaw += _deltavalue.x * sensitivity * Time.deltaTime;
        camTransform.rotation = quaternion.Euler(_pitch, _yaw, 0f);

    }
}
