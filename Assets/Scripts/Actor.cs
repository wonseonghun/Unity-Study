using UnityEngine;

public class Actor : MonoBehaviour
{
    public string actorName;
    public string actorType;
    // 활성화될 때마다 위치해 있어야 할 회전값
    public Vector3 initPosition;
    public Vector3 initRotation;
    public Transform initTransform;
    public float moveSpeed = 1.0f;
    public float rotateSpeed = 90f;

    //public Vector3[] movePositions;
    public Transform[] moveTransforms;

    private int _currentIndex = 0;
    void Start()
    {
        //Debug.Log($"액터의 이름은 {actorName}입니다."); 
    }

    private void OnEnable()
    {
        //Debug.Log($"저의 역할은  {actorType}입니다.");
        // transform의 position과 rotation을 변경하면 그 위치, 회전 상태로 변경할 수 있다.
        if (moveTransforms.Length > 0)
        {
            transform.position = moveTransforms[0].position;
        }
        else
        {
            transform.position = initPosition;
        }
            transform.position = initPosition;

        //trnasform의 rotation에 사원수를 대입하면 
        transform.rotation = Quaternion.Euler(initRotation); //360도 개념을 4원수로 바꿔주는 함수.
    }
    // Update is called once per frame
    void Update()
    {
        #region

        // 지정된 방향으로 원하는 거리만큼 이동하는 함수이다.
        //transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
        // 현재 회전값에서 목적 회전값까지 최대 회전각도만크 회전하는 함수
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(30,30,30)),90f*Time.deltaTime);
        #endregion 

        // 현재 위치에서 목적지까지 최대 거리만큼 이동
        transform.position = Vector3.MoveTowards(transform.position, moveTransforms[_currentIndex].position,moveSpeed * Time.deltaTime);

        if (transform.position == moveTransforms[_currentIndex].position)
        {
            UpdateDestination();
        }


        // 지정된 축으로 원하는 각도만큼 회전하는 함수.
        transform.Rotate(Vector3.up * rotateSpeed*Time.deltaTime, Space.World);

 

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
