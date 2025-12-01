using UnityEngine;
using System.Collections;

/**
 *	Rapidly sets a light on/off.
 *	
 *	(c) 2015, Jean Moreno
**/

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour
{
    private Light _fireLight;

    private void Awake()
    {
        _fireLight = GetComponent<Light>();
    }

    void OnEnable ()
	{
	
		StartCoroutine("Flicker");
	}
	
	IEnumerator Flicker()
	{
        _fireLight.enabled = true;
        yield return null;
        // 잠깐 대기
        yield return null;
        _fireLight.enabled = false;
    }
}
