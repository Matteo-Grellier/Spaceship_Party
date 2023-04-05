using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    public bool isSun = false;
    public bool isBoostZone = true;
    private bool isAttract = false;
    [Range(0.0f, 1.0f)] public float atractionForce = 1;


    public void Update()
    {
        if (isAttract)
        {
            rb.AddForce(direction * atractionForce);
        }
    }

    // Ex�cuter lorsque l'objet entre dans la zone de d�tection
    public void OnTriggerStay(Collider other)
    {
        Vector3 posPlanet;
        Vector3 posPlayer;

        if (other.gameObject.CompareTag("spaceship") && other is Collider)
        {
            isAttract = true;
            
            rb = other.GetComponent<Rigidbody>();
            posPlayer = other.transform.position;
            posPlanet = transform.position;

            direction = posPlanet - posPlayer;

            if (isSun)
            {
                other.GetComponent<Spaceship>().canRecharge = true;
            }

            if (isBoostZone)
            {
                other.GetComponent<Spaceship>().canBoost = true;
            }
        }
    }

    // Ex�cuter lorsque l'objet sort de la zone de d�tection
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("spaceship"))
        {
            isAttract = false;

            if (isSun)
            {
                other.GetComponent<Spaceship>().canRecharge = false;
            }
            if (isBoostZone)
            {
                other.GetComponent<Spaceship>().canBoost = false;
            }
        }
    }
}
