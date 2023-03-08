using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GiftButton : MonoBehaviour {

    public Button _button;
    public TMP_Text buttonText;
    public Gift gift;
    private bool haveGift;
    // Start is called before the first frame update
    void Start()
    {
        buttonText = _button.GetComponentInChildren<TMP_Text>(true);
        _button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (haveGift || gift != null && !gift.isUsed) {
            buttonText.text = gift.name;
            _button.interactable = true;
        } else {
            buttonText.text = "Aucun";
            _button.interactable = false;
        }
    }

    public void IsClick() {
        gift.Use();
        gift = null;
        haveGift = false;
    }

    public void SetGift(Gift newGift) {
        gift = newGift;
        haveGift = true;
    }
}
