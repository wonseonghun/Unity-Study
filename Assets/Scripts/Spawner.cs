using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 어떤 부모 밑에서 태어날지 결정 , 그래서 왼쪽 hierarchy에서 감당이 안되게 생성되는 걸 방지.
    public Transform parent;
    // 아 부모를 만들어내서 그 밑에 생성된 걸 넣으니까 parent를 ballList에 넣는다.

    public GameObject item;                 // ???? 
    public Transform[] spawnPositions;  // spawnposition이란라는 위치, 회전 크기를 정의
    public float startSpawntime = 1f;
    public float spawnInterval = 1f;
    // 게임 오브젝트를 어느위치 & 어드 시점에 생성할지, 인터벌을 정의
    private float _spawnTime;
    // private를 사용하면 _spawnTime을 inspector에 안드러나려고.. => monobehaviour Class에는 드러나지 않으니까.  ===> 맞는지 체크
    // spawnTime은 다음에 생성해야 하는 시간을 기록
    // object를 생성햅해보자
    void Start()
    {
        _spawnTime = Time.time + startSpawntime;
        // Time.time은 현재 시간
    }

    // 프레임마다 호출된다.
    void Update()
    {
        if (_spawnTime > Time.time)
            return;
                                                                                                                                     // 만약 0초에서 시작하면 spwantime은 1초 => return이 되고 다시 업데이트부터 하면 1초 후에는 return이 안되고 
        _spawnTime += spawnInterval;
                                                                                                                                    // spawntime에 1초를 더해준다. 즉 2초
        if (spawnPositions.Length == 0)
            return;
        //spawnPosition이 없으면 return한다.
       

        for (int i = 0; i < spawnPositions.Length; i++) 
        GameObject.Instantiate(item, spawnPositions[i].position,spawnPositions[i].rotation, parent);
        // parent는 ballList에 clone을 넣어두기 위해 만든 것.

    

    }
}
