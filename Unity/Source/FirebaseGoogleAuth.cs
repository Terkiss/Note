using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Firebase.Auth;
public class FirebaseGoogleAuth : MonoBehaviour
{
    #region member Variable

    public FirebaseLogin firebaseLogin;
    private string serverAuthCode;

    #endregion // member Variable

    #region Unity Message

    void Awake()
    {

        // 게임에서 request server authcode 설정을 사용 설정 하여  게임 클라이언트 구성
        // 로그인시 토큰을 받기위해 구글 플레이 컨피그를 만들어둔다.
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration
                .Builder()
                .RequestServerAuthCode(false)
                .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        


       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            FirebaseUser user = firebaseLogin.Auth.CurrentUser;

            string userName = user.DisplayName;
            string uid = user.UserId;
            string phoneNumber = user.PhoneNumber;

            Debug.LogFormat("userName : {0}, uid : {1}, phoneNumber : {2}", userName, uid, phoneNumber);
        }
    }

    #endregion // Unity Message

    #region Google Game Play Auth Login System


    /// <summary>
    /// 구글play game 에 로그인을 시도 합니다. 
    /// </summary>
    public void TryGoogleLogin()
    {
        Debug.Log("로컬 유저 아이디 " + Social.localUser.id);
        Debug.Log("로컬 유저 친구 " + Social.localUser.friends);
        Debug.Log("로컬 유저  " + Social.localUser);
        Debug.Log("로그인 플래그 " + Social.localUser.authenticated);
        if (!Social.localUser.authenticated) // 로그인 되어 있지 않다면
        {
            Social.localUser.Authenticate(success => // 로그인 시도
            {
                if (success) // 성공하면
                {
                    Debug.Log(Social.localUser.userName);

                   
                    serverAuthCode = PlayGamesPlatform.Instance.GetServerAuthCode();

                    Debug.Log("auth code :: [" + PlayGamesPlatform.Instance.GetServerAuthCode() + "]");

                    googlePlayLoginForFirebase(serverAuthCode);
                }
                else // 실패하면
                {
                    Debug.Log("Login fail");

                }
            });
        }
    }

    public void googlePlayLoginForFirebase(string serverAuth)
    {
        //Debug.Log("null 레퍼런스 체크 ");
        if (firebaseLogin == null)
        {
            firebaseLogin = gameObject.GetComponent<FirebaseLogin>();
        }
        if (serverAuth.Length < 1)
        {
            Debug.LogError("서버 인증 토큰이 비어 있습니다. ");
            return;
        }

        firebaseLogin.GoogleLogin(serverAuthCode);

        FirebaseUser user = firebaseLogin.Auth.CurrentUser;

        string userName = user.DisplayName;
        string uid = user.UserId;
        string phoneNumber = user.PhoneNumber;

        Debug.Log("출력 " + userName);
        Debug.Log("출력 " + uid);
        Debug.Log("출력 " + phoneNumber);

    }
    /// <summary>
    /// 구글 플레이 로그인 해제 
    /// </summary>
    public void TryGoogleLogout()
    {
        Debug.Log("로그아웃 버튼 눌림");
        if (Social.localUser.authenticated) // 로그인 되어 있다면
        {
            PlayGamesPlatform.Instance.SignOut(); // 로그아웃
            Debug.Log("logout");
        }
    }

    #endregion // Google Game Play Auth Login System


    #region Play Service





    public void LeaderBoardTest()
    { 
        Social.ReportScore(12234, "CgkI9MvExsQZEAIQAA", (success) => {
            if (success)
            {
                Debug.Log("점수 기록이 성공적 입니다.");

            }
            else 
            {
                Debug.Log("점수 기록이 실패");
            }
        });
    }

    public void LeaderShow()
    {
        Social.ShowLeaderboardUI();
    }

    #endregion // Play Service

}
