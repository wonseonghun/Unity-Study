using UnityEngine;

public class TriggerReactor : MonoBehaviour
{

    public Color enterColor = Color.red;

    private Material _material;
    public Color _initColor;

    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _initColor = _material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
       _material.color = enterColor;
    }

    private void OnTriggerExit(Collider other)
    {
        _material.color = _initColor;
    }

}
