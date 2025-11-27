using UnityEngine;
using UnityEngine.EventSystems;


// 필요한 component를 속성에 원하는 컴포넌트를 넣어서 강제할 수 있음
//[RequireComponent(typeof(MeshRenderer))]  
public class MousePointerReactor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //마우스 포인터가 오브젝트에 되어지면 호출되고, 나가면 호출되는 CLASS // event system이 필요 
{
    private Material _material;
    private Color _initColor;

    public Color enterColor;

    public void OnPointerEnter(PointerEventData eventData)  // 마우스 커서가 충돌 영역 안으로 들어올 때 호출되는 콜백 함수 
    // 전제 조건 : 
    // 1. cube에 colllider이 있는 지 확인
    // 1. cube에 colllider이 있는 지 확인
    // 2. UI -Eventsystem 추가
    // 3. main camera에 physics raycast 추가  => 광선을 쏴 충돌체를 감지하는 함수
    // Physics.Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask);
    // origin에서 direction방향으로 maxDistance 길이의 광선을 쏜다. 해당 layerMask의 Collider만 충돌하고 , 충돌체에 대한 정보를 hitinfo에 담는다.
    // maxDistance 생략 시, 디폴트로 무한대 거리 지정 / layerMask 생략 시 defaultRaycastLayers로 지정 / hitInfo 생략 시, 충돌체에 대한 정보를 따로 저장하지 않음
    {


        _material.color = enterColor;
    }

    public void OnPointerExit(PointerEventData eventData)  // 마우스 커서가 충돌영역 밖으로 들어올 때 호출되는 함수
    {
      

        _material.color = _initColor;
    }

    void Start()
    {
        
       MeshRenderer meshRender = GetComponent<MeshRenderer>();
        if (meshRender == null)
            return;
        // 필요 없을 수도 있지만, 안전장치
       
        _material = meshRender.material;
        _initColor=_material.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
