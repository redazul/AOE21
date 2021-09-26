using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{

    [Tooltip("This is the amount of viable zombies the player has ressurected")]
    private int _score;


    [Tooltip("This is the text for the amount of zomies the player has ressurected ")]
    [SerializeField]
    private TextMeshProUGUI numberTotal, gameOverScore;


    private void Start()
    {
        SetValue = 0;
    }
    public int SetValue
    {
        get { return _score; }
        set
        {
            _score = value;
            numberTotal.text = SetValue.ToString();
            gameOverScore.text = SetValue.ToString();
            //   numberTotal.text = "Cois collected: " + SetValue.ToString();
           // PlayerPrefs.SetInt("ZombiesSaved", SetValue);

        }
    }
}
