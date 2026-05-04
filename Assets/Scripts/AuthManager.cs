using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{
    [SerializeField] private Button loginButton;

    // async / await / Task
    private async void Start()
    {
        // UGS 초기화
        await UnityServices.InitializeAsync();
        Debug.Log("UGS 초기화 완료");
    }
}
