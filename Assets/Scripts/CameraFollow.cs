using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    
    public float smoothSpeed = 0.2f;
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
            switch(blockedCameraPosition)
            {
                case BlockedAxes.x:
                    desiredPosition = new Vector3(transform.position.x, target.position.y, target.position.z) + offset;
                    break;
                case BlockedAxes.y:
                    desiredPosition = new Vector3(target.position.x, transform.position.y, target.position.z) + offset;
                    break;
                case BlockedAxes.z:
                    desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;
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
            if(target != null)
                defaultPosition = target.position + offset;
            transform.position = defaultPosition;
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
