using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{
    [SerializeField] private Button loginButton;
    [SerializeField] private Button logoutButton;
    [SerializeField] private Button savePlayerNameButton;
    [SerializeField] private TMP_InputField playerNameIf;

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
        
        // 6. 이름 변경
        savePlayerNameButton.onClick.AddListener( async () => SetPlayerName(playerNameIf.text));
    }

    // 50자 허용
    // 공백 허용 불가
    // 이름#1234
    private async Task SetPlayerName(string playerName)
    {
        await AuthenticationService.Instance.UpdatePlayerNameAsync(playerName);
        
        var savedPlayerName = await AuthenticationService.Instance.GetPlayerNameAsync();
        Debug.Log("이름 저장완료: " + savedPlayerName);
    }
}
