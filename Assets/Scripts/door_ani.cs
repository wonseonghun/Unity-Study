using UnityEngine;

public class door_ani : MonoBehaviour
{

    public Animator door;

public string bParameternName = "door";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        door.SetBool(bParameternName, true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        door.SetBool(bParameternName, false);
    }
}
