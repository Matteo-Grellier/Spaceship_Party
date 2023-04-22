using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    public bool doMoov;
    private Vector3 savePos;
    private float sizeALaMano = 280;
    private float z;
    private float x;
    private float t = 0.005f;
    private void Start() {
        savePos = transform.position;
        x = Random.Range(0, 100.0f);
        z = Random.Range(0, 100.0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (doMoov){
            transform.position = Vector3.Lerp(transform.position, new Vector3(savePos.x+x, savePos.y, savePos.z+z), t*Time.deltaTime);
            if (t >= 0.9f){
                gameObject.SetActive(false);
            }
            if (t+0.005f<=1){
                t += 0.005f;
            }
        }
    }
}
