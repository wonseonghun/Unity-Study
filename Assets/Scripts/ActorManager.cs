using UnityEngine;

public class ActorManager : MonoBehaviour
{

    // 게임 오브젝트가 활성화될 때 가장 먼저 호출(한번만) 
    private void Awake()
    {
        //Debug.Log("Awake");
    }

    // 게임 오브젝트가 활성화될 때마다 호출
    private void OnEnable()
    {
        //Debug.Log("OnEnable");
    }

    // 게임 오브젝트가 활성화될 때 단 한번만 호출 
    void Start()
    {
        //Debug.Log("Start");
        GameObject go = new GameObject("Actor");  //Actor라는 새로운 오브젝트를 추가하고 위치를 go에 넣어라.
        go.SetActive(false);                                      // Active를 비활성화해라.
        Actor actor = go.AddComponent<Actor>();    // Actor라는 component를 추가하고 그 component의 위치를 actor라 한다. 
        actor.enabled = false;
        actor.actorName = "Ashley";
        actor.actorType = "extra01";
        go.SetActive(true);
        
    }

    // 게임 오브젝트가 활성화되어 있는 동안 매 프레임마다 한번씩 호출
    void Update()
    {
        //Debug.Log("Update");
    }

    // 
    private void OnDisable()
    {
        //Debug.Log("OnDisable");
    }
}

