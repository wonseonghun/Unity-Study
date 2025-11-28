using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public GameObject hitEffect;
    public float launchPower = 5f;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Launch(transform.forward);
    }
    public void Launch(Vector3 direction)
    {
        _rigidbody.AddForce(direction * launchPower);
    }

    private void OnCollisionEnter(Collision collision)  // 매개변수 collision에 여러 정보가 들어가 있음.
    {
        Instantiate(hitEffect, collision.contacts[0].point, Quaternion.identity);
        Destroy(gameObject); // 총알을 ㅇ
    }
}
