using UnityEngine;

public class AnimateController : MonoBehaviour
{
    //트리거 파라메터 이름 변수  , 어차피 누르는 키를 다르게 하니까 같은 이름으로 하면 좋을 듯?
    public string triggerName = "Trigger";
    public string PistonTriggerName = "Trigger";

    public Animator triggerAnim;
    //화전 속도 파라메터 이름 변수
    public string speedName = "Speed";
    public float direction = 1f;
    [Range(0,1000f)]
    //회전 속도 값
    public float speedValue = 0f;
    //회전 속도 변화값
    public float changeValue = 0.1f;
    public Animator speedAnim;

    public Animator PistionAnim;

    private void Start()
    {
        // 초기값을 위해 초기화시킨다. / 기어가 시작할 때 speed 변수에 있는 값을 기준으로 회전하도록 초기화한다.
        speedAnim.SetFloat(speedName, speedValue);
    }



    public void OnAttack()
    {
        //애니메이터에 해당 이름을 가진 트리거 파라메터를 설정한다.
        triggerAnim.SetTrigger(triggerName);
    }

    public void OnFaster()
    {
        speedValue += changeValue;
     
        if (speedValue > 1000f)
        {
            speedValue = 1000f;
        }
        //애니메이터에 해당 이름을 가진 float 파라메터의 값을 변경한다.
        speedAnim.SetFloat(speedName, direction * speedValue);
    }

    public void OnSlower()
    {
        speedValue -= changeValue;
        if (speedValue < 0f)
        {
            speedValue = 0f;
        }
        //애니메이터에 해당 이름을 가진 float 파라메터의 값을 변경한다.
        speedAnim.SetFloat(speedName, direction * speedValue);
    }

    public void OnInvert()
    {
        direction *= -1f;
        speedAnim.SetFloat(speedName, direction * speedValue);
    }

    public void OnPush()
    {
        PistionAnim.SetTrigger(PistonTriggerName);
    }
}
