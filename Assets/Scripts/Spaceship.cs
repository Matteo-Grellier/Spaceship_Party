using UnityEngine;
//using Mirror;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour //NetworkBehaviour
{
    private Rigidbody rb;
    public float multiplierSpeed;
    public float smoothSpeed = 0.125f;
    [SerializeField] private Slider _sliderR;
    [SerializeField] private Slider _sliderL;
    float vR = 0f;
    float vL = 0f;
    float average = 0f;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        _sliderR.onValueChanged.AddListener((v) => {
            vR = v;
            average = AverageSliders(vR, vL);
        });
        _sliderL.onValueChanged.AddListener((v) => {
            vL = v;
            average = AverageSliders(vR, vL);
        });
    }

    private void FixedUpdate() {
      /*if (!isLocalPlayer) {
        transform.Find("Camera").gameObject.SetActive(false);
      }*/
      MovePlayer(average, vR, vL);
    }

    private float AverageSliders(float vR, float vL) {
        return (vR + vL) / 2;
    }

    private void MovePlayer(float average, float vR, float vL) {
        rb.AddRelativeForce(0f, 0f, multiplierSpeed * average, ForceMode.Force);
        //float diffSliders = (vR - vL) * 100;
        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }
}
