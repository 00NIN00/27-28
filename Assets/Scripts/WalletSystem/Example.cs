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
                _wallet.AddCurrencyBy(CurrencyType.Coin, 10);
            }    
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _wallet.RemoveCurrencyBy(CurrencyType.Coin, 5);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _wallet.AddCurrencyBy(CurrencyType.Money, 10);
            }    
            
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _wallet.RemoveCurrencyBy(CurrencyType.Money, 5);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                _wallet.AddCurrencyBy(CurrencyType.Energy, 10);
            }    
            
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                _wallet.RemoveCurrencyBy(CurrencyType.Energy, 5);
            }
        }
    }
}
