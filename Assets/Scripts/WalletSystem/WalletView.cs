using System.Collections.Generic;
using UnityEngine;

namespace WalletSystem
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private List<CurrencyView> _currenciesViews = new(System.Enum.GetValues(typeof(CurrencyType)).Length);
        [Header("Icons")]
        [SerializeField] private Sprite _coinIcon;
        [SerializeField] private Sprite _moneyIcon;
        [SerializeField] private Sprite _enegyIcon;
        
        private Wallet _wallet;
        private Dictionary<CurrencyType, CurrencyView> _currencies = new();

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;
            _wallet.Changed += OnChangeCurrencyBy;

            for (int i = 0; i < _currenciesViews.Count; i++)
            {
                _currencies.Add((CurrencyType)i, _currenciesViews[i]);
            }

            StartReset();
            SetIcons();
        }

        private void StartReset()
        {
            foreach (CurrencyView view in _currencies.Values)
            {
                view.SetText("");
            }
        }

        private void SetIcons()
        {
            foreach (var kvp in _currencies)
            {
                CurrencyType type = kvp.Key;
                CurrencyView view = kvp.Value;
    
                Sprite icon = null;
    
                switch (type)
                {
                    case CurrencyType.Coin:
                        icon = _coinIcon;
                        break;
                    case CurrencyType.Money:
                        icon = _moneyIcon;
                        break;
                    case CurrencyType.Energy:
                        icon = _enegyIcon;
                        break;
                }
    
                view.SetIcon(icon);
            }
        }
        
        private void OnChangeCurrencyBy(CurrencyType type, int value)
        {
            if (_currencies.TryGetValue(type, out var view))
            {
                view.SetText(value.ToString());
            }
        }

        private void OnDisable()
        {
            _wallet.Changed -= OnChangeCurrencyBy;
        }
    }
}