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

        // ���ӿ��� request server authcode ������ ��� ���� �Ͽ�  ���� Ŭ���̾�Ʈ ����
        // �α��ν� ��ū�� �ޱ����� ���� �÷��� ���Ǳ׸� �����д�.
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
    /// ����play game �� �α����� �õ� �մϴ�. 
    /// </summary>
    public void TryGoogleLogin()
    {
        Debug.Log("���� ���� ���̵� " + Social.localUser.id);
        Debug.Log("���� ���� ģ�� " + Social.localUser.friends);
        Debug.Log("���� ����  " + Social.localUser);
        Debug.Log("�α��� �÷��� " + Social.localUser.authenticated);
        if (!Social.localUser.authenticated) // �α��� �Ǿ� ���� �ʴٸ�
        {
            Social.localUser.Authenticate(success => // �α��� �õ�
            {
                if (success) // �����ϸ�
                {
                    Debug.Log(Social.localUser.userName);

                   
                    serverAuthCode = PlayGamesPlatform.Instance.GetServerAuthCode();

                    Debug.Log("auth code :: [" + PlayGamesPlatform.Instance.GetServerAuthCode() + "]");

                    googlePlayLoginForFirebase(serverAuthCode);
                }
                else // �����ϸ�
                {
                    Debug.Log("Login fail");

                }
            });
        }
    }

    public void googlePlayLoginForFirebase(string serverAuth)
    {
        //Debug.Log("null ���۷��� üũ ");
        if (firebaseLogin == null)
        {
            firebaseLogin = gameObject.GetComponent<FirebaseLogin>();
        }
        if (serverAuth.Length < 1)
        {
            Debug.LogError("���� ���� ��ū�� ��� �ֽ��ϴ�. ");
            return;
        }

        firebaseLogin.GoogleLogin(serverAuthCode);

        FirebaseUser user = firebaseLogin.Auth.CurrentUser;

        string userName = user.DisplayName;
        string uid = user.UserId;
        string phoneNumber = user.PhoneNumber;

        Debug.Log("��� " + userName);
        Debug.Log("��� " + uid);
        Debug.Log("��� " + phoneNumber);

    }
    /// <summary>
    /// ���� �÷��� �α��� ���� 
    /// </summary>
    public void TryGoogleLogout()
    {
        Debug.Log("�α׾ƿ� ��ư ����");
        if (Social.localUser.authenticated) // �α��� �Ǿ� �ִٸ�
        {
            PlayGamesPlatform.Instance.SignOut(); // �α׾ƿ�
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
                Debug.Log("���� ����� ������ �Դϴ�.");

            }
            else 
            {
                Debug.Log("���� ����� ����");
            }
        });
    }

    public void LeaderShow()
    {
        Social.ShowLeaderboardUI();
    }

    #endregion // Play Service

}
