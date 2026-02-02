using System.Collections.Generic;
using UnityEngine;
using System;

namespace WalletSystem
{
    public class WalletView : MonoBehaviour
    {
        [Header("UI Spawn")]
        [SerializeField] private CurrencyView _containerPrefab;
        [SerializeField] private RectTransform _container;
        [Header("Icons")] 
        [Tooltip("Index corresponds to enum number") ][SerializeField] private List<Sprite> _spritesIcons = new(Enum.GetValues(typeof(CurrencyType)).Length);
        
        private Wallet _wallet;
        
        private Dictionary<CurrencyType, Sprite> _icons = new();
        private Dictionary<CurrencyType, CurrencyView> _currencies = new();

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;
            _wallet.Changed += OnChangeCurrencyBy;
            
            SetDictionaryIcons();
        }

        private void SetDictionaryIcons()
        {
            foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
            {
                _icons.Add(type, _spritesIcons[(int)type]);
            }
        }
        
        private void OnChangeCurrencyBy(CurrencyType type, int value)
        {
            if (_currencies.TryGetValue(type, out var view))
            {
                view.SetText(value.ToString());
            }
            else
            {
                CreateViewContainer(type, value);
            }
        }

        private void CreateViewContainer(CurrencyType type,  int value)
        {
            CurrencyView view = Instantiate(_containerPrefab, _container);
            _currencies.Add(type, view);

            view.SetIcon(_icons[type]);
            view.SetText(value.ToString());
        }

        private void OnDisable()
        {
            _wallet.Changed -= OnChangeCurrencyBy;
        }
    }
}