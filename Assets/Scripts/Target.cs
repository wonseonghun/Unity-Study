using UnityEditor.Build;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Material _material;
    public int max = 100;
    private Color _initColor = Color.white;
    private int _hitCount;

    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _initColor = _material.GetColor("_EmissionColor");
        _material.DisableKeyword("_EMISSION");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_hitCount == 0)
        {
            _material.EnableKeyword("_EMISSION");
        }

        Color current = _initColor * (++_hitCount / (float)max + 1f);
        _material.SetColor("_EmissionColor", current);
    }


    //private Color _initColor;



    //public Color targetColor = Color.white;
    //private int _hitCount;
    //private void Start()
    //{
    //    _material = GetComponent<MeshRenderer>().material;
    //    targetColor = _material.GetColor("_EmissionColor");
    //    _material.SetColor("_EmissionColor", (targetColor / 100f));


    //}

    //// 충돌이 감지되면 호출됨.
    //public void OnCollisionEnter(Collision collision)
    //{
    //    Color current = (targetColor / 100f) * ++_hitCount;
    //    _material.SetColor("_EmissionColor", current);
    //}
}
