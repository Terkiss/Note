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
                Debug.Log("Create and hold a reference to your FirebaseApp, 만들다 파이어 베이스 앱");
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                if (app == null)
                {
                    Debug.Log("널입니다");
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
            Debug.Log("널입니다");
            
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
                    Debug.Log(email + "로그인 하셧습니다.");
                }
                else
                {
                    Debug.Log("로그인에 실패 하셧씁니다.");
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
                    Debug.Log(email + "로그인 하셧습니다.");
                }
                else
                {
                    Debug.Log("로그인에 실패 하셧씁니다.");
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
                    Debug.Log(email + " 로 회원가입 하셨습니다.");
                }
                else
                {
                    Debug.Log("회원가입에 실패하셨습니다.");
                }
            }
            );
        }
    }

    #endregion // FireBase Email Login System

    #region FireBase Google Login System


    // 구글 파이어 베이스 로그인 
    public void GoogleLogin(string serverAuthCode)
    {
        //Debug.Log("serverAuth ::: "+serverAuthCode);
        //Debug.Log("null?::: " + firebaseAuth);
        if (firebaseAuth == null)
        {
            // 파이어 베이스 객체가 널이면 ? 초기화를 합니다
            firebaseAuth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        }
        
        //Debug.Log("null?::: " + firebaseAuth);
        Credential credential = Firebase.Auth.PlayGamesAuthProvider.GetCredential(serverAuthCode);
        //Debug.Log("da");
        // Firebase.Auth.Credential credential =Firebase.Auth.PlayGamesAuthProvider.GetCredential(serverAuthCode);
        //Debug.Log("여기까지 실행 확인 증");
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
