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
        // UGS 초기화 콜백
        UnityServices.Initialized += () => Debug.Log("UGS 초기화 완료");
        
        // UGS 초기화
        await UnityServices.InitializeAsync();
        
        loginButton.onClick.AddListener(async () =>
        {
            // 익명 로그인
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("익명로그인 완료");
        });
    }
}
