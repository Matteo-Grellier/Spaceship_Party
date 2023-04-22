using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    
    public float smoothSpeed = 0.05f;
    public Vector3 offset = new Vector3(0, 20f, 0); 

    private Vector3 defaultRotation;
    private Vector3 defaultPosition;

    private Vector3 desiredPosition;
    private Vector3 desiredLookAt;

    public enum BlockedAxes
    {
        x,
        y,
        z,
        none
    }

    public BlockedAxes blockedCameraPosition;
    public BlockedAxes blockedCameraRotation;

    private Vector3 DesiredPosition 
    {
        get
        {
            float distanceWithBorder = 15;

            // float desiredBlockedPosition;
            
            switch(blockedCameraPosition)
            {
                case BlockedAxes.x:
                    float desiredX = target.position.x;
                    
                    if(target.position.x > GameManager.instance.rightMapBorderPosition.x-distanceWithBorder 
                    || target.position.x < GameManager.instance.leftMapBorderPosition.x+distanceWithBorder)
                    {
                        desiredX = transform.position.x;
                    }

                    desiredPosition = new Vector3(desiredX, target.position.y, target.position.z) + offset;
                    break;
                case BlockedAxes.y:

                    float desiredY = target.position.y;
                    
                    if(target.position.y > GameManager.instance.rightMapBorderPosition.y-distanceWithBorder 
                    || target.position.y < GameManager.instance.leftMapBorderPosition.y+distanceWithBorder)
                    {
                        desiredY = transform.position.y;
                    }

                    desiredPosition = new Vector3(target.position.x, desiredY, target.position.z) + offset;
                    break;
                case BlockedAxes.z:

                    float desiredZ = target.position.z;
                    
                    if(target.position.z > GameManager.instance.rightMapBorderPosition.z-distanceWithBorder 
                    || target.position.z < GameManager.instance.leftMapBorderPosition.z+distanceWithBorder)
                    {
                        desiredY = transform.position.z;
                    }

                    desiredPosition = new Vector3(target.position.x, target.position.y, desiredZ) + offset;
                    break;
                default:
                    desiredPosition = target.position + offset;
                    break;
            }

            return this.desiredPosition;
        }

        set
        {
            desiredPosition = value;
        }
    }

    private Vector3 DesiredLookAt 
    {
        get
        {
            switch(blockedCameraRotation)
            {
                case BlockedAxes.x:
                    desiredLookAt.x = transform.position.x;
                    break;
                case BlockedAxes.y:
                    desiredLookAt.y = transform.position.y;
                    break;
                case BlockedAxes.z:
                    desiredLookAt.z = transform.position.z;
                    break;
                default:
                    break;
            }

            return this.desiredLookAt;
        }

        set
        {
            desiredLookAt = value;
        }
    }

    void FixedUpdate() 
    {
        if(target == null) 
        {
            if (GameManager.instance.localPlayer == null)
                return; 
            
            target = GameManager.instance.localPlayer.transform;
            Debug.Log("[cmr] target= " + target);
            defaultRotation = transform.eulerAngles;
        }
        else 
        {
            Vector3 smoothPosition = Vector3.Lerp(transform.position, DesiredPosition, smoothSpeed);

            transform.position = smoothPosition;

            DesiredLookAt = target.position;
            transform.LookAt(DesiredLookAt);
        }
    }
}
