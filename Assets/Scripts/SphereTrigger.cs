using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    private Rigidbody rb;
    private bool isSun = false;
    private bool isPlanet = false;
    private float vx = 1f;
    private float vz = 1f;
    private float maxVX = 100f;
    private float maxVZ = 100f;

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
            Debug.Log("Entre dans la zone de détection !");

            vx *= -8f;
            vz *= -8f;

            float dist = Vector3.Distance(gameObject.transform.position, rb.transform.position);

            if (dist > 3f & vx <= maxVX & vz <= maxVZ)
            {
                rb.AddRelativeForce(vx, 0f, vz, ForceMode.Force);
            }

            if (isSun)
            {
                other.GetComponent<Spaceship>().canRecharge = true;
                Debug.Log("Rechargement des batteries !");
            }
            if (isPlanet)
            {
                other.GetComponent<Spaceship>().canBoost = true;
                Debug.Log("Boost la vitesse !");
            }
        }
    }
    // Exécuter lorsque l'objet sort de la zone de détection
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            other.GetComponent<Spaceship>().isInEffectZone = false;
            Debug.Log("Sort de la zone de détection !");

            if (isSun)
            {
                other.GetComponent<Spaceship>().canRecharge = false;
                Debug.Log("Ne peut plus recharger ses batteries !");
            }
            if (isPlanet)
            {
                other.GetComponent<Spaceship>().canBoost = false;
                Debug.Log("Ne peut plus booster la vitesse !");
            }
        }
    }
}
