using UnityEngine;

public class Actor : MonoBehaviour
{
    public string actorName;
    public string actorType;
    public Vector3 initPosition;    // 활성화될 때마다 위치해 있어야  초기 위치값
    public Vector3 initRotation;     // 초기 회전값

    public Transform initTransform;  //  ?????
    public float moveSpeed = 1.0f;
    public float rotateSpeed = 90f;

    public Transform[] moveTransforms;  // 움직일 목적지를 나타내는 point를 나타내기 위함.
    private int _currentIndex = 0;
   
    private void Start()
    {
                                                          //Debug.Log($"액터의 이름은 {actorName}입니다."); 
    }

    private void OnEnable()                 //onEnable이란???
    {
                                                                                   //Debug.Log($"저의 역할은  {actorType}입니다.");
                                                                                // transform의 position과 rotation을 변경하면 그 위치, 회전 상태로 변경할 수 있다.
        if (moveTransforms.Length > 0)
        {
            transform.position = moveTransforms[0].position;  // 처음 점으로 이동 .transform의 position은 이 cube의 position
        }
        else
        {
            transform.position = initPosition;  // movetransform에 위치를 넣지 않으면 그냥 initposition에서 해라.
        }
        
        transform.rotation = Quaternion.Euler(initRotation); //360도 개념을 4원수로 바꿔주는 함수. , 굳이 필요없으니까.
    }
   
    void Update()
    {
        #region
        // 지정된 방향으로 원하는 거리만큼 이동하는 함수이다.
        //transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);  // 여기서 vector3.forward는 
        // 현재 회전값에서 목적 회전값까지 최대 회전각도만크 회전하는 함수
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(30,30,30)),90f*Time.deltaTime);
        #endregion 

        // 현재 위치에서 목적지까지 최대 거리만큼 이동(,,)
        transform.position = Vector3.MoveTowards(transform.position, moveTransforms[_currentIndex].position,moveSpeed * Time.deltaTime);  //현재위치, 목표 위치, 속도 이렇게 3개를 쓴다.  //그렇다면 movetransform의 element 0으로의 이동은 없겠네.
        // 그러면 이 transform.position을 바꿔주는 것이다. transform.position에서 moveTransforms까지의 벡터에서 한 deltatime마다 가는 위치로 바꿔주는 것이다. 
        // Time.deltaTime과 fixeddeltaTime의 차이점  
        if (transform.position == moveTransforms[_currentIndex].position)
        {
            UpdateDestination();
        }


        // 지정된 축으로 원하는 각도만큼 회전하는 함수.
        transform.Rotate(Vector3.up * rotateSpeed*Time.deltaTime, Space.World);  //space.world는???

 

    }

    public void OnAttack()
    {

        if (moveTransforms.Length == 0)
            return;

        UpdateDestination();
        //Debug.Log("Enter키 눌렀어?");
     
        //갱신된 목적지로 위치 이동
        //transform.position = moveTransforms[_currentIndex].position;
    }

    private void UpdateDestination()
    {
        _currentIndex++;
        if (_currentIndex >= moveTransforms.Length)
        {
            _currentIndex = 0;
        }
    }
}
