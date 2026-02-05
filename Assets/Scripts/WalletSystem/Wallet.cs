using System.Collections.Generic;
using UnityEngine;
using System;

namespace WalletSystem
{
    public class Wallet
    {
        public event Action<CurrencyType, int> Changed;

        private readonly List<Currency> _currencies = new();

        public Wallet()
        {
            foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
            {
                Currency currency = new Currency(type);
                _currencies.Add(currency);
                currency.Changed += CurrencyOnChanged;
            }
        }
        

        public bool TryAddCurrencyBy(CurrencyType type, int value)
        {
            Currency currency = _currencies.Find(c => c.CurrencyType == type);

            if (currency == null)
                return false;

            return currency.TryAdd(value);
        }

        public bool TryRemoveCurrencyBy(CurrencyType type, int value)
        {
            foreach (var currency in _currencies)
            {
                if (currency.CurrencyType == type)
                   return currency.TryRemove(value);
            }

            return false;
        }

        private void CurrencyOnChanged(CurrencyType type, int value)
        {
            Debug.Log($"{type}: {value}");
            Changed?.Invoke(type, value);
        }
    }
}