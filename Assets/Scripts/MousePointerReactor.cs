using UnityEngine;
using UnityEngine.EventSystems;


// 필요한 component를 속성에 원하는 컴포넌트를 넣어서 강제할 수 있음
//[RequireComponent(typeof(MeshRenderer))]  
public class MousePointerReactor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //마우스 포인터가 오브젝트에 되어지면 호출되고, 나가면 호출되는 CLASS
{
    private Material _material;
    private Color _initColor;

    public Color enterColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
       
        
        _material.color = enterColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      

        _material.color = _initColor;
    }

    void Start()
    {
        
       MeshRenderer meshRender = GetComponent<MeshRenderer>();
        if (meshRender == null)
            return;
       
        _material = meshRender.material;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
