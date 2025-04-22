using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumManager : MonoBehaviour
{
    public int lives;

    public float score;
    public float multiplier;

    private void Start()
    {
        lives = PlayerPrefs.GetInt("lives");

        multiplier = 1.6f - (PlayerPrefs.GetInt("lanes") * .2f);
        multiplier -= PlayerPrefs.GetInt("carFreq") * .2f;

        if (lives != 1)
            multiplier /= 2;

        StartCoroutine("ScorePlus");
    }

    private IEnumerator ScorePlus()
    {
        score += 1 * multiplier;
        yield return new WaitForSeconds(.2f);

        StartCoroutine("ScorePlus");
    }
}
