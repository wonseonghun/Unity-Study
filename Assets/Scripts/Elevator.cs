using UnityEngine;

public class Elevator : MonoBehaviour
{
    
    public Transform[] positions = new Transform[2];

    [Range(1f,10f)]
    public float moveSpeed = 1f;
    public int _destinationIndex = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, positions[_destinationIndex].localPosition, moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("들어왔다.");
        switch (_destinationIndex)
        {
            case 0:
                _destinationIndex = 1; break;

            case 1:
                _destinationIndex = 0; break;
        }

        
        
       
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    _destinationIndex = 0;
    //}

}
