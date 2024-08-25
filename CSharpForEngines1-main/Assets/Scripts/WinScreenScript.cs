using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textBoxText;

    public static int finalScore;
    public static int finalDiamonds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textBoxText.text = "You won!! You reached your goal having earned \n " + ScoreSystem.score + " \n points and collected " + DiamondSystem.diamondCount + " diamonds.";
    }
}
