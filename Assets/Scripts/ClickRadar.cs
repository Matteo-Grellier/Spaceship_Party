using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRadar : MonoBehaviour
{
    public GameObject radarPiece;
    public MeshRenderer meshRenderer;
    public Material greenMaterial;
    public Material redMaterial;

    private bool isGreen = true;

    private void Start() 
    {
        meshRenderer.material = greenMaterial;
    }

    private void OnMouseDown() 
    {
        StartCoroutine(Clignote());
    }

    private IEnumerator Clignote()
    {
        meshRenderer.material =  redMaterial ;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.material =  greenMaterial ;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.material =  redMaterial ;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.material =  greenMaterial ;
        yield return new WaitForSeconds(0.1f);
    }
}
