using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    public static string playerName { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        SetName();
    }

    public void SetName()
    {
        playerName = playerNameInput.text;
    }

    public void DisplayName()
    {
        Debug.Log(playerName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
