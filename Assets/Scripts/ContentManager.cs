using UnityEngine;
using UnityEngine.InputSystem;

public class ContentManager : MonoBehaviour
{
    public GameObject[] contents;
    public Clicker clicker;
    public Mover mover;
    
    public void OnPress1()
    {
        if (contents.Length == 0 || contents[0] == null) // null은 element가 비어있을 때를 방지
            return;

        contents[0].SetActive(!contents[0].activeSelf);

        // 누른 컨텐츠만 커지게 하는 코드
        //for (int i = 0; i < contents.Length;  i++)
        //{
        //    contents[i].SetActive(i == 0);
        //    // setactive 는 뭘까??   오브젝트를 활성화, 비황성화를 하는 역할
        //}
    }

    public void OnPress2()  // Input system setting에서 대문자 Press를 썼으면 똑같이 써야 한다.
    {
        if (contents.Length < 2 || contents[1] == null)  // contents[1].Length는 의미가 없다. contents[1] 내부의 length는 없기에
            return;

        contents[1].SetActive(!contents[1].activeSelf);
       
        //for (int i = 0; i < contents.Length; i++)
        //{
        //    contents[i].SetActive(i == 1);
        //}
    }
    public void OnAttack()
    {
        clicker.OnAttack();
    }

    public void OnMove(InputValue value)
    {
        mover.OnMove(value);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
