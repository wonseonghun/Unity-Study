using UnityEngine;

public class Rotator : MonoBehaviour
{

    //Transform은 오브젝트의 위치, 회전 크기를 변환시킬 때 사용하는 클래스
    //vec = Vector3.right;   // new Vector3(1, 0, 0);
    //vec = Vector3.left;    // new Vector3(-1, 0, 0);
    //vec = Vector3.up;      // new Vector3(0, 1, 0);
    //vec = Vector3.down;    // new Vector3(0, -1, 0);
    //vec = Vector3.forward; // new Vector3(0, 0, 1);
    //vec = Vector3.back;    // new Vector3(0, 0, -1);
    //vec = Vector3.zero;    // new Vector3(0, 0, 0);
    //vec = Vector3.one;     // new Vector3(1, 1, 1);


    public Transform Target;

    public float rotateSpeed = 90f;
    public Vector3 rotateAxis = Vector3.up;

    private float _distance =0f;

    void Start()
    {
        if (Target == null)
            return;
        //vector3 는 어떻게 쓰는 건가??
        // 목적지에서 현재 위치를 빼서 방향 벡터 구하기
        Vector3 forward = Target.position - transform.position;
        _distance = forward.magnitude;

        //벡터에서 magitude라는 변수를 이용해 거리를 알아냄.
        //LookRotation함수로 목적 방향으로 회전시킬 수 있다.
        // Quaternion은 3차원 함수
        transform.rotation = Quaternion.LookRotation(forward.normalized, Vector3.up); // forward를 기준으로 회전하고, (0,1,0)을 머리 위로 기준으로 삼아서 이상하게 보는 것을 방지
    }

    // Update is called once per frame
    void Update()
    {
        //  공전하기 위해서는 먼저 회전시키고 위치를 변경해야함.
        transform.Rotate(rotateSpeed * Time.deltaTime * rotateAxis, Space.World);

        if (Target !=null)
            

        // 목적위치 + 바라보는 방향의 반대방향 *거리 = 공전시 있어야 하는 위치  //아아아아아아 회전을 시켜서 정면을 90도 바꾸고 그 거리만큼 움직여러
        transform.position = Target.position + (-transform.forward * _distance) ;
    }
}


// is kinematic을 키면
// rigidbody의 constraint의 freeze position 어떤 운동을 넣어놨든 특정 포지션에 고정됨
// rigidbody의 constraint의 freeze rotation 어떤 운동을 넣어놨든 회전하지 않고 고정됨

//physics setting을 통해 layer 끼리의 충돌을 계산하지 않게 할 수 있다. => 계산 향상 , 선제조건은 각각 layer를 설정해야 한다.