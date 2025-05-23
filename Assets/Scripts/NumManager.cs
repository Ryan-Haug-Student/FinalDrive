using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumManager : MonoBehaviour
{
    public float score;
    public float multiplier;

    public TMP_Text scoreText;

    private void Start()
    {

        multiplier = 1.6f - (PlayerPrefs.GetInt("lanes") * .2f);
        multiplier -= PlayerPrefs.GetInt("carFreq") * .2f;

        StartCoroutine("ScorePlus");
    }

    private IEnumerator ScorePlus()
    {
        score += 100;
        score = Mathf.Round(score);
        score /= 100;

        score += 1 * multiplier;
        scoreText.text = $"Current Distance: {score}Mi";

        yield return new WaitForSeconds(.2f);
        PlayerPrefs.SetFloat("score", score);
        PlayerPrefs.Save();

        StartCoroutine("ScorePlus");
    }
}
