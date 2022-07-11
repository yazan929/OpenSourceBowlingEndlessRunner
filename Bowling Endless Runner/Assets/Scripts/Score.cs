using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public bool autoIncrement;
    public int scorePerSecond;
    public TextMeshProUGUI scoreText;

    public static Score Instance;
    void Awake() => Instance = this;

    void StopAutoIncrement(){

        autoIncrement = false;
    }

    IEnumerator Start(){

        Player.Instance.health.onDeathEvent.AddListener(StopAutoIncrement);

        WaitForSecondsRealtime waitASecond = new WaitForSecondsRealtime(1);

        while (true){

            if(autoIncrement){

                yield return waitASecond;
                Increment(scorePerSecond);
            }
        }
    }

    public void Increment(int x){

        int currentScore = int.Parse(scoreText.text);
        currentScore += x;
        LeanTween.scale(scoreText.gameObject, new Vector3(1.5f, 1.5f), 0.2f).setEase(LeanTweenType.punch);
        scoreText.text = currentScore.ToString();
    }
}
