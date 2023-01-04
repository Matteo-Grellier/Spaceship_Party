using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Exécuter lorsque l'objet entre dans la zone de détection
        if(other.gameObject.tag == "spaceship")
        {
            Debug.Log("Entre dans la zone de détection !");
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Exécuter lorsque l'objet sort de la zone de détection
        if (other.gameObject.tag == "spaceship")
        {
            Debug.Log("Sort de la zone de détection !");
        }
    }
}
