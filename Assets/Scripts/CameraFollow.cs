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
            switch(blockedCameraPosition)
            {
                case BlockedAxes.x:

                    float desiredX = DesiredBlockPosition(
                        target.position.x, 
                        GameManager.instance.rightMapBorderObject.transform.position.x,
                        GameManager.instance.leftMapBorderObject.transform.position.x,
                        transform.position.x
                    );

                    desiredPosition = new Vector3(desiredX, target.position.y, target.position.z) + offset;
                    break;
                case BlockedAxes.y:

                    float desiredY = DesiredBlockPosition(
                        target.position.y, 
                        GameManager.instance.rightMapBorderObject.transform.position.y,
                        GameManager.instance.leftMapBorderObject.transform.position.y,
                        transform.position.y
                    );

                    desiredPosition = new Vector3(target.position.x, desiredY, target.position.z) + offset;
                    break;
                case BlockedAxes.z:

                    float desiredZ = DesiredBlockPosition(
                        target.position.z, 
                        GameManager.instance.rightMapBorderObject.transform.position.z,
                        GameManager.instance.leftMapBorderObject.transform.position.z,
                        transform.position.z
                    );

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

    public Transform Target
    {
        get
        {
            return this.target;
        }

        set
        {
            target = value;
        }
    }

    private float DesiredBlockPosition(float targetPositionAxe, float rightBorderAxe, float leftBorderAxe, float transformPositionAxe) 
    {
        float distanceWithBorder = 15;

        if(targetPositionAxe > rightBorderAxe - distanceWithBorder 
        || targetPositionAxe < leftBorderAxe + distanceWithBorder)
        {
            return transformPositionAxe;
        } else {
            return targetPositionAxe;
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
            transform.position = target.position+offset;
            defaultRotation = transform.eulerAngles;
        }
        else 
        {
            Vector3 smoothPosition = Vector3.Lerp(transform.position, DesiredPosition, smoothSpeed);

            Debug.Log(smoothPosition);

            transform.position = smoothPosition;

            DesiredLookAt = target.position;
            transform.LookAt(DesiredLookAt);
        }
    }
}
