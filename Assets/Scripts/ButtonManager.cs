using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
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

    public void ArcadeMode(int num)
    {
        PlayerPrefs.SetInt("arcadeBool", num);
        SavePrefs();
    }

    public void Play()
    {
        //SceneManager.LoadScene($"{PlayerPrefs.GetInt("lanes")}Lane");
        print($"{PlayerPrefs.GetInt("lanes")}Lane");
    }

    private void SavePrefs()
    {
        PlayerPrefs.Save();
        print("Updated!");
    }
}
