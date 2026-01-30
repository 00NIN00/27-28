using UnityEngine;

namespace WalletSystem
{
    public class Example : MonoBehaviour
    {
        private Wallet _wallet;

        public void Initialize(Wallet wallet)
        {
            _wallet  = wallet;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
               AddCurrencyBy(CurrencyType.Coin, 10);
            }    
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                RemoveCurrencyBy(CurrencyType.Coin, 5);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                AddCurrencyBy(CurrencyType.Money, 10);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                RemoveCurrencyBy(CurrencyType.Money, 5);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                AddCurrencyBy(CurrencyType.Energy, 10);
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                RemoveCurrencyBy(CurrencyType.Energy, 5);
            }
        }
        
        private void AddCurrencyBy(CurrencyType currencyType, int amount) => _wallet.AddCurrencyBy(currencyType, amount);
        private void RemoveCurrencyBy(CurrencyType currencyType, int amount) => _wallet.RemoveCurrencyBy(currencyType, amount);
    }
}
