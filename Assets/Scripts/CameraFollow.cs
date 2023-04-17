using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    
    public float smoothSpeed = 0.2f;
    public Vector3 offset = new Vector3(0, 20f, 0); 

    public enum BlockedPosition
    {
        x,
        y,
        z,
        none
    }

    public BlockedPosition blockedCameraPosition;

    void FixedUpdate() 
    {
        Vector3 desiredPosition;

        if(target == null) 
        {
            target = GameObject.FindGameObjectWithTag("spaceship")?.transform;
            desiredPosition = target.position + offset;
            Vector3 firstPosition = desiredPosition;
            transform.position = firstPosition;
            return;
        }


        switch(blockedCameraPosition)
        {
            case BlockedPosition.x:
                desiredPosition = new Vector3(transform.position.x, target.position.y, target.position.z) + offset;
                break;
            case BlockedPosition.y:
                desiredPosition = new Vector3(target.position.x, transform.position.y, target.position.z) + offset;
                break;
            case BlockedPosition.z:
                desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;
                break;
            default:
                desiredPosition = target.position + offset;
                break;
        }
        
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothPosition;

    }
}
