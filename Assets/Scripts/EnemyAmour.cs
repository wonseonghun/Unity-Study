using UnityEngine;

public class EnemyAmour : Enemy
{

    //활성화되면 물리 무적 상태로 변경
    private void OnEnable()
    {
        _rigidbody.isKinematic = true;

    }

    protected override void Die()
    {
        // 죽므면 물리 무적상태 해제
        _rigidbody.isKinematic=false;
        base.Die();
    }
}
