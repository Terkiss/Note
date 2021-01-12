using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
public class FirebaseLogin : MonoBehaviour
{
    #region member Variable


    private FirebaseAuth firebaseAuth = null;
    private Firebase.FirebaseApp app = null;

    private Firebase.Auth.FirebaseAuth auss = null;


    public FirebaseAuth Auth
    {
        get
        {
            return firebaseAuth;
        }
    }

    public Firebase.FirebaseApp apps
    {
        get 
        {
            return app;
        }
    }

    #endregion // member Variable

    #region Unity Message

    void Awake()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                Debug.Log("Create and hold a reference to your FirebaseApp, ����� ���̾� ���̽� ��");
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                if (app == null)
                {
                    Debug.Log("���Դϴ�");
                }
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });


        if (app == null)
        {
            Debug.Log("���Դϴ�");
            
        }
        firebaseAuth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {


        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    string email = "dl2000dl@naver.com";
        //    string passwd = "dl2000dl2121";

        //    enailJoin(email, passwd);
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    string email = "dl2000dl@naver.com";
        //    string passwd = "dl2000dl2121";

        //    emailLogin(email, passwd);
        //}
    }

    #endregion // Unity Message

    #region FireBase Email Login System

    public void emailLogin(string email, string passwd)
    {
        firebaseAuth.SignInWithEmailAndPasswordAsync(email, passwd).ContinueWith(
            task =>
            {
                if (!task.IsFaulted && !task.IsCanceled && task.IsCompleted)
                {
                    Debug.Log(email + "�α��� �ϼ˽��ϴ�.");
                }
                else
                {
                    Debug.Log("�α��ο� ���� �ϼ˾��ϴ�.");
                }
            }
            );
    }
    public void emailLogin2(object[] userInfo)
    {
        string email = userInfo[0].ToString();
        string passwd = userInfo[1].ToString();

        firebaseAuth.SignInWithEmailAndPasswordAsync(email, passwd).ContinueWith(
            task =>
            {
                if (!task.IsFaulted && !task.IsCanceled && task.IsCompleted)
                {
                    Debug.Log(email + "�α��� �ϼ˽��ϴ�.");
                }
                else
                {
                    Debug.Log("�α��ο� ���� �ϼ˾��ϴ�.");
                }
            }
            );
    }

    public void enailJoin(string email, string passwd)
    {
        for (int i = 0; i < 100; i++)
        {
            string tempstr = Random.Range(0, 1000) + email;

            firebaseAuth.CreateUserWithEmailAndPasswordAsync(tempstr, passwd).ContinueWith(
            task =>
            {
                if (!task.IsCanceled && !task.IsFaulted)
                {
                    Debug.Log(email + " �� ȸ������ �ϼ̽��ϴ�.");
                }
                else
                {
                    Debug.Log("ȸ�����Կ� �����ϼ̽��ϴ�.");
                }
            }
            );
        }
    }

    #endregion // FireBase Email Login System

    #region FireBase Google Login System


    // ���� ���̾� ���̽� �α��� 
    public void GoogleLogin(string serverAuthCode)
    {
        //Debug.Log("serverAuth ::: "+serverAuthCode);
        //Debug.Log("null?::: " + firebaseAuth);
        if (firebaseAuth == null)
        {
            // ���̾� ���̽� ��ü�� ���̸� ? �ʱ�ȭ�� �մϴ�
            firebaseAuth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        }
        
        //Debug.Log("null?::: " + firebaseAuth);
        Credential credential = Firebase.Auth.PlayGamesAuthProvider.GetCredential(serverAuthCode);
        //Debug.Log("da");
        // Firebase.Auth.Credential credential =Firebase.Auth.PlayGamesAuthProvider.GetCredential(serverAuthCode);
        //Debug.Log("������� ���� Ȯ�� ��");
        firebaseAuth.SignInWithCredentialAsync(credential).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
        });
    }

    #endregion // FireBase Google Login System

}
