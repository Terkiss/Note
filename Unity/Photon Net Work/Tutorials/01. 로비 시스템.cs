using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 아래 게임 오브젝트가 필요 합니다.
[RequireComponent(typeof(InputField))]
public class PlayNameInputField : MonoBehaviour
{

    private const string playNamePrefKey = "playerName";
    // Start is called before the first frame update
    void Start()
    {
        string defaultName = string.Empty;
        InputField inputField = this.GetComponent<InputField>();

        if (inputField != null)
        {
            if (PlayerPrefs.HasKey(playNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playNamePrefKey);
                inputField.text = defaultName;
            }
        }

        PhotonNetwork.NickName = defaultName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetPlayerName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            Debug.Log("player name is null  or empty");
            return;
        }

        PhotonNetwork.NickName = value;

        PlayerPrefs.SetString(playNamePrefKey, value);
    }
}
