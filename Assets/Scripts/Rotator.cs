using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Transform은 오브젝트의 위치, 회전 크기를 변환시킬 때 사용하는 클래스
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
        //vector3.up은 
        transform.rotation = Quaternion.LookRotation(forward.normalized, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        //  공전하기 위해서는 먼저 회전시키고 위치를 변경해야함.
        transform.Rotate(rotateSpeed * Time.deltaTime * rotateAxis, Space.World);

        if (Target !=null)
            

        // 목적위치 + 바라보는 방향의 반대방향 *거리 = 공전시 있어야 하는 위치
        transform.position = Target.position + (-transform.forward * _distance) ;
    }
}
