using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderAverage : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider _sliderR;
    private Slider _sliderL;
    [SerializeField] private TextMeshProUGUI _slidersAverageText;
    float average = 0.0f;

    void Start() {
        _sliderL = GameObject.Find("SliderL").GetComponent<Slider>();
        _sliderR = GameObject.Find("SliderR").GetComponent<Slider>();
        _slidersAverageText = GameObject.Find("SliderTextA").GetComponent<TextMeshProUGUI>();
        float vR = 0f;
        float vL = 0f;
        _sliderR.onValueChanged.AddListener((v) => {
            vR = v;
            average = AverageSliders(vR, vL);
            _slidersAverageText.text = average.ToString("0.00");
        });
        _sliderL.onValueChanged.AddListener((v) => {
            vL = v;
            average = AverageSliders(vR, vL);
            _slidersAverageText.text = average.ToString("0.00");
        });
    }

    private float AverageSliders(float vR, float vL) {
        return (vR + vL) / 2;
    }

    public float GetAverage() {
        return average;
    }

    public Slider GetLeftSlider() {
        return _sliderL;
    }

    public Slider GetRightSlider() {
        return _sliderR;
    }

    public void SetInteractable(bool isInterac) {
        _sliderR.interactable = isInterac;
        _sliderL.interactable = isInterac;
    }

    public void SetValue(float value) {
        _sliderR.value = value;
        _sliderL.value = value;
    }
}
