using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace WalletSystem
{
    [System.Serializable]
    public class CurrencyView
    {
        [SerializeField] private TMP_Text _value;
        [SerializeField] private Image _image;

        public CurrencyView(TMP_Text value, Image image)
        {
            _value = value;
            _image = image;
        }

        public void SetText(string text)
        {
            _value.text = text;
        }

        public void SetIcon(Sprite icon)
        {
            _image.sprite = icon;
        }
    }
}