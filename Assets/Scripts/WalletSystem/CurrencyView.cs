using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace WalletSystem
{
    [System.Serializable]
    public class CurrencyView
    {
        [SerializeField] private TMP_Text _valueText;
        [SerializeField] private Image _image;

        public CurrencyView(TMP_Text valueText, Image image)
        {
            _valueText = valueText;
            _image = image;
        }

        public void SetText(string text)
        {
            _valueText.text = text;
        }

        public void SetIcon(Sprite icon)
        {
            _image.sprite = icon;
        }
    }
}