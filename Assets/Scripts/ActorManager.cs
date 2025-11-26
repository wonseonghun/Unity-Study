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
        GameObject go = new GameObject("Actor");
        go.SetActive(false);
        Actor actor = go.AddComponent<Actor>();
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

