using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumManager : MonoBehaviour
{
    public float score;
    public float multiplier;

    private void Start()
    {

        multiplier = 1.6f - (PlayerPrefs.GetInt("lanes") * .2f);
        multiplier -= PlayerPrefs.GetInt("carFreq") * .2f;

        StartCoroutine("ScorePlus");
    }

    private IEnumerator ScorePlus()
    {
        score += 1 * multiplier;
        yield return new WaitForSeconds(.2f);
        PlayerPrefs.SetFloat("score", score);
        PlayerPrefs.Save();

        StartCoroutine("ScorePlus");
    }
}
