using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    Vector3 posPlayer;
    Vector3 posPlanet;
    private bool isSun = false;
    private bool isPlanet = false;
    private bool isAttract = false;


    public void Update()
    {
        if (isAttract)
        {
            rb.AddForce(-direction);
        }
    }

    // Exécuter lorsque l'objet entre dans la zone de détection
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "spaceship")
        {
            isAttract = true;
            
            rb = other.GetComponent<Rigidbody>();
            posPlayer = other.transform.position;
            posPlanet = transform.position;
            direction =  posPlanet + posPlayer;
            rb.AddForce(-direction);

            if (isSun)
            {
                other.GetComponent<Spaceship>().canRecharge = true;
            }
            if (isPlanet)
            {
                other.GetComponent<Spaceship>().canBoost = true;
            }
        }
    }

    // Exécuter lorsque l'objet sort de la zone de détection
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "spaceship")
        {
            isAttract = false;

            if (isSun)
            {
                other.GetComponent<Spaceship>().canRecharge = false;
            }
            if (isPlanet)
            {
                other.GetComponent<Spaceship>().canBoost = false;
            }
        }
    }
}
