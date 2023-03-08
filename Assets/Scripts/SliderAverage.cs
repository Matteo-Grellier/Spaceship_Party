using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderAverage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider _sliderR;
    [SerializeField] private Slider _sliderL;
    [SerializeField] private TextMeshProUGUI _slidersAverageText;

    void Start() {
        float vR = 0f;
        float vL = 0f;
        _sliderR.onValueChanged.AddListener((v) => {
            vR = v;
            float average = AverageSliders(vR, vL);
            _slidersAverageText.text = average.ToString("0.00");
        });
        _sliderL.onValueChanged.AddListener((v) => {
            vL = v;
            float average = AverageSliders(vR, vL);
            _slidersAverageText.text = average.ToString("0.00");
        });
    }

    private float AverageSliders(float vR, float vL) {
        return (vR + vL) / 2;
    }
}
