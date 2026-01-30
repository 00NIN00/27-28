using UnityEngine;

namespace WalletSystem
{
    public class BootstrapWallet : MonoBehaviour
    {
        [Header("Wallet")]
        [SerializeField] private WalletView _walletView;
        private Wallet _wallet;
    
        [Header("Example")]
        [SerializeField] private Example _example;
    
    
        private void Awake()
        {
            _wallet = new Wallet();
        
            _example.Initialize(_wallet);
        
            _walletView.Initialize(_wallet);
        }
    }
}