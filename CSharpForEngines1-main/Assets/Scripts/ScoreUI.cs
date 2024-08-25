using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreUI : MonoBehaviour
{
    //public ScoreSystem scoreSystem;

    public TMPro.TextMeshProUGUI scoreLabel;
    public TMPro.TextMeshProUGUI diamondCountLabel;
    
        void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            scoreLabel.text = "Score: " + ScoreSystem.score; //changes score on ui //gets value from ScoreSystem script
            diamondCountLabel.text = "x " + DiamondSystem.diamondCount; //changes score on ui //gets value from DiamondSystem script

    }
}



