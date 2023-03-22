using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radar : MonoBehaviour
{
    // Start is called before the first frame update
    private string display;
    public GameObject img;
    void Start()
    {
        img.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other) {
        // Debug.Log(other);
        DisplayRed(other);
    }
    
    private void DisplayRed(Collider other){
        Debug.Log(other.transform.position);
        img.transform.position = other.transform.position;
        // if (img.transform.position.y>gameObject.transform.position.y){
        //     img.transform.Rotate(new Vector3(transform.rotation.x,transform.rotation.y,180f));
        // }
        img.transform.Rotate(new Vector3(transform.rotation.x,transform.rotation.y,180f));

        img.SetActive(true);
        Debug.Log(img.activeSelf);

    }
}
