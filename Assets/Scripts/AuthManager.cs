using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{
    [SerializeField] private Button loginButton;
    [SerializeField] private Button logoutButton;

    // async / await / Task
    private async void Start()
    {
        // 2. UGS 초기화 콜백
        UnityServices.Initialized += () => Debug.Log("UGS 초기화 완료");
        
        // 1. UGS 초기화
        await UnityServices.InitializeAsync();
        
        // 3. 로그인 관련 콜백
        AuthenticationService.Instance.SignedOut += () => Debug.Log("로그아웃 완료");
        
        // 4. 로그인 요청
        loginButton.onClick.AddListener(async () =>
        {
            // 익명 로그인
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            var playerId = AuthenticationService.Instance.PlayerId;
            Debug.Log("익명로그인 완료 " + playerId);
        });
        
        // 5. 로그아웃 처리
        logoutButton.onClick.AddListener(() => AuthenticationService.Instance.SignOut());
    }
}
