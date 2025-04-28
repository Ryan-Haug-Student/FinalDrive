using System.Collections;
using System.Collections.Generic;
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

    public void Lives(int num)
    {
        PlayerPrefs.SetInt("lives", num);
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

    private void Update()
    {
        float multiplier;
        int lives;

        multiplier = 2.2f - (PlayerPrefs.GetInt("lanes") * .2f);
        multiplier -= PlayerPrefs.GetInt("carFreq") * .2f;

        lives = PlayerPrefs.GetInt("lives");

        if (lives != 1)
            multiplier /= 2;

        multText.text = $"Score Multiplier: {Mathf.Round(multiplier * 100) / 100}";
    }
}
