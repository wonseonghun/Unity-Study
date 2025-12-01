using UnityEngine;
using UnityEngine.ProBuilder;

public class Projectile : MonoBehaviour
{

    [Header("탄도")]
    public float launchPower = 300f; //발사속도
    public bool useGravity = false; // 탄이 중력에 영향 받을지 여부

    [Space(10f), Header("이펙트관련")]
    public GameObject hitEffect; // 적을 맞췄을 때 생성할 이펙트
    public GameObject holeEffect; // 벽이나 바닥을 맞췄을 때 생성할 이펙트  
    public LayerMask allowLayer; // 적을 구분하기 위한 레이어 설정


    [Space(10f), Header("공격관련")]
    private Rigidbody _rigidbody; // 물리 충돌 및 이동하기 위한 리지드 바디
    [Range(1, 20)]
    public int damage = 1;   // 적에게 줄 수 있는 데미지 크기
    public float explosionPower = 100f;  // 폭발력
    public float explosionRadius = 0.2f; //폭발범위

    


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
       // Launch(transform.forward);
       _rigidbody.useGravity = useGravity;
    }
    public void Launch(Vector3 direction)
    {
        //_rigidbody.AddForce(direction * launchPower);  // 절대적인 방향으로 힘을 가함(예 : 세상의 정면방향으로 힘을 가해라.)

        _rigidbody.AddRelativeForce(Vector3.forward*launchPower, ForceMode.VelocityChange);  //상대적인 방향으로 힘을 가함.(예: 내가 바라보는 정면을 향해 힘을 가해라)
    }

    private void OnCollisionEnter(Collision collision)  // 매개변수 collision에 여러 정보가 들어가 있음.
    {
        //가장 처음 충돌한 위치 정보
        Vector3 point = collision.contacts[0].point;
        // 가장 처음 충돌한 면의 노멀 정보
        Vector3 normal =collision.contacts[0].normal;

        //충돌한 레이어가 EnemyArmor가 아닐 경우
        if (collision.collider.gameObject.layer != LayerMask.NameToLayer("EnemyArmor"))
        {
            //구멍난 이펙트 생성
            Instantiate(holeEffect, point + normal * 0.01f, Quaternion.LookRotation(normal));
        }
        //반대일 경우
        else
        {
            // 적 히트 이펙트 생성
            Instantiate(hitEffect, point + normal * 0.01f, Quaternion.LookRotation(normal));

            // 히트 지점에 폭발  범위 안에 들어오는 모든 적을 검출함.
            Collider[] colliders = Physics.OverlapSphere(point, explosionRadius, allowLayer);
           
            // 검출된 적에게 데미지를 주고 파괴된 적ㅇ에게 물리적인 폭발력을 주어 날아가게 만듦.
            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody rb = colliders[i].attachedRigidbody;
                if (rb != null && rb.TryGetComponent<Enemy>(out var e))
                {
                    if (e.Hit(damage))
                    {
                        //날아가려면 부모와 떨어져야 하기 때문에 부모로부터 단절시킴.
                        rb.transform.SetParent(null);
                        //폭벌범위에 따른 힘을 가해 날아가게 만듦
                        rb.AddExplosionForce(explosionPower, point, explosionRadius, 0f, ForceMode.Impulse);
                    }
                }
            }
        }

            //Instantiate(hitEffect, collision.contacts[0].point + collision.contacts[0].normal * 0.01f, Quaternion.LookRotation(collision.contacts[0].normal)); //Identity는 회전이 000인 상태
        // 발사된 총알 파괴
        Destroy(gameObject); 
    }
}
