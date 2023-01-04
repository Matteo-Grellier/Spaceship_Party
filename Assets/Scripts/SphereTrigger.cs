using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Ex�cuter lorsque l'objet entre dans la zone de d�tection
        if(other.gameObject.tag == "spaceship")
        {
            Debug.Log("Entre dans la zone de d�tection !");
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Ex�cuter lorsque l'objet sort de la zone de d�tection
        if (other.gameObject.tag == "spaceship")
        {
            Debug.Log("Sort de la zone de d�tection !");
        }
    }
}
