using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    public bool isSun = false;
    public bool isPlanet = false;

    // Ex�cuter lorsque l'objet entre dans la zone de d�tection
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            other.GetComponent<Spaceship>().isInEffectZone = true;
            Debug.Log("Entre dans la zone de d�tection !");

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
    // Ex�cuter lorsque l'objet sort de la zone de d�tection
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            other.GetComponent<Spaceship>().isInEffectZone = false;
            Debug.Log("Sort de la zone de d�tection !");

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
