using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIHandler : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button rankingButton;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI text;
    private void Start()
    {
        startButton.onClick.AddListener(ClickStartButton);
        rankingButton.onClick.AddListener(ClickRankingButton);
    }

    void ClickStartButton()
    {
        if (inputField.text == "Player Name..." || inputField.text == "Input Player Name!")
        {
            inputField.text = "Input Player Name!";
            return;
        }

        GameManager.instance.SetPlayerName(inputField.text);
        SceneManager.LoadScene(1);
    }

    void ClickRankingButton()
    {

    }
}
