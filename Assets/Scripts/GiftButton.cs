using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GiftButton : MonoBehaviour {

    public Button _button;
    public TMP_Text buttonText;
    private Gift gift;
    private bool haveGift;
    // Start is called before the first frame update
    void Start()
    {
        buttonText = _button.GetComponentInChildren<TMP_Text>(true);
        _button.interactable = false;
        _button.onClick.AddListener(UseGift);
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

    private void UseGift() {
        gift.Use();
        gift = null;
        haveGift = false;
    }

    public void SetGift(string giftName) {
        gift = gameObject.AddComponent(typeof(Gift)) as Gift;
        gift.name = giftName;
        haveGift = true;
    }
}
