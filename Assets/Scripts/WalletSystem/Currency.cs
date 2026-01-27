using System;

namespace WalletSystem
{
    public class Currency
    {
        public event Action<CurrencyType, int> Changed;

        private int _value;
        
        public Currency(CurrencyType currencyType)
        {
            CurrencyType = currencyType;
        }

        public CurrencyType CurrencyType { get; }
        private int Value
        {
            get => _value;
            set
            {
                _value = value;
                Changed?.Invoke(CurrencyType, value);
            }
        }
        
        public bool TryAdd(int value)
        {
            if (value < 0)
                return false;

            Value += value;
            
            return true;
        }

        public bool TryRemove(int value)
        {
            if (value < 0 || Value - value < 0)
                return false;

            Value -= value;
            
            return true;
        }
    }
}