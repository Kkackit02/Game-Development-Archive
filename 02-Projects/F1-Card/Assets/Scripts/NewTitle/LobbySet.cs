using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySet : MonoBehaviour
{
    [SerializeField] Text Gold;
    [SerializeField] Text LP;
    [SerializeField] Text Rank;

    public void Init()
    {
        Gold.text = PlayerPrefs.GetInt("gold", 0).ToString();
        LP.text = PlayerPrefs.GetInt("lp", 0).ToString();
        Rank.text = PlayerPrefs.GetInt("rank", 0).ToString();//이 부분은 후에 서버 붙치고 변경 될 내용들

    }
}
