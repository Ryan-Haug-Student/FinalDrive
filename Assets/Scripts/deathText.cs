using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class deathText : MonoBehaviour
{
    public TMP_Text text;

    public float score;

    private void Start()
    {
        score = PlayerPrefs.GetFloat("score");

        text.text = $"Your final drive is over.\r\nFinal Score - {score}Mi";
    }
}
