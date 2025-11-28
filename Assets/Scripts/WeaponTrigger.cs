using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponTrigger : MonoBehaviour
{
    public Weapon currentWeapon;

    public void OnShoot(InputValue value)
    {
        Debug.Log("발사");
        currentWeapon.Fire(value.isPressed);
    }
}
