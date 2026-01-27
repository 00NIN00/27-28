using WalletSystem;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("Wallet")]
    [SerializeField] private WalletView _walletView;
    private Wallet _wallet;
    
    [Header("Example")]
    [SerializeField] private Example _example;
    
    
    private void Awake()
    {
        _wallet = new Wallet();
        
        _walletView.Initialize(_wallet);
        
        _example.Initialize(_wallet);
    }
}