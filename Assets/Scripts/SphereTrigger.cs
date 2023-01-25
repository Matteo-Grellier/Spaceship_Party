using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    private Rigidbody rb;
    private bool isSun = false;
    private bool isPlanet = false;
    private float vx = 1f;
    private float vz = 1f;
    
    private void FixedUpdate()
    {
        rb.AddRelativeForce(vx, 0f, vz, ForceMode.Force);
    }

    // Exécuter lorsque l'objet entre dans la zone de détection
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            other.GetComponent<Spaceship>().isInEffectZone = true;

            rb = other.GetComponent<Rigidbody>();
            vx *= -8f;
            vz *= -8f;
            rb.AddRelativeForce(vx, 0f, vz, ForceMode.Force);

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
        if (other.gameObject.name == "player")
        {
            other.GetComponent<Spaceship>().isInEffectZone = false;

            rb = other.GetComponent<Rigidbody>();
            vx *= 0f;
            vz *= 0f;
            rb.AddRelativeForce(0f, 0f, 0f, ForceMode.Force);

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
