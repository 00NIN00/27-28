using System.Collections.Generic;
using UnityEngine;
using System;

namespace WalletSystem
{
    public class Wallet
    {
        public event Action<CurrencyType, int> Changed;
        
        private readonly List<Currency> _currencies = new();

        public void AddTypeCurrency(CurrencyType type)
        {
            if (_currencies.Exists(x => x.CurrencyType == type) == false)
            {
                Currency currency = new Currency(type);
                
                currency.Changed += CurrencyOnChanged;
                _currencies.Add(currency);
            }
        }

        public void RemoveTypeCurrency(CurrencyType type)
        {
            if (!_currencies.Exists(x => x.CurrencyType == type)) return;
            
            Currency currency = _currencies.Find(c => c.CurrencyType == type);
            
            currency.Changed -= CurrencyOnChanged;
            _currencies.Remove(currency);
        }

        public void AddCurrencyBy(CurrencyType type, int value)
        {
            Currency currency = _currencies.Find(c => c.CurrencyType == type);
            
            if (currency == null)
            {
                AddTypeCurrency(type);
                currency = _currencies.Find(c => c.CurrencyType == type);
            }
            
            currency.TryAdd(value);
        }

        public void RemoveCurrencyBy(CurrencyType type, int value)
        {
            foreach (var currency in _currencies)
            {
                if (currency.CurrencyType == type)
                    currency.TryRemove(value);
            }
        }
        
        private void CurrencyOnChanged(CurrencyType type, int value)
        {
            Debug.Log($"{type}: {value}");
            Changed?.Invoke(type, value);
        }
    }
}