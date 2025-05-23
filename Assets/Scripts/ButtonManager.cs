
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public TMP_Text multText;

    public void Traffic(int num)
    {
        PlayerPrefs.SetInt("carFreq", num);
        SavePrefs();
    }

    public void Lanes(int num)
    {
        PlayerPrefs.SetInt("lanes", num);
        SavePrefs();
    }

    public void Play()
    {
        SceneManager.LoadScene($"{PlayerPrefs.GetInt("lanes", 3)}Lane");
    }

    private void SavePrefs()
    {
        PlayerPrefs.Save();
        print("Updated!");
    }

    public void BackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            float multiplier;

            multiplier = 2.2f - (PlayerPrefs.GetInt("lanes") * .2f);
            multiplier -= PlayerPrefs.GetInt("carFreq") * .2f;

            multText.text = $"Score Multiplier: {Mathf.Round(multiplier * 100) / 100}";
        }
    }
}
