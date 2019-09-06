using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image blackPanel;
	public Text winOrLoseText;
    public int timeToFade = 3;
    public Text timer;
    public Text obstaclesHit;

    private float _timeLeft = 60.0f;

    private void Start()
    {
        blackPanel.CrossFadeColor(Color.clear, timeToFade, false, true);
        timer.text = "60";
        winOrLoseText.text = "";
    }

    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        timer.text = System.Math.Round(_timeLeft).ToString(CultureInfo.CurrentCulture);

        if (_timeLeft < 0)
        {
            EndGame(1);
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void EndGame(int endCode)
    {
		blackPanel.CrossFadeColor(Color.black, timeToFade, false, true);
        if (endCode == 0)
        {
            winOrLoseText.text = "Win!";
            winOrLoseText.color = Color.green;
        }
        else
        {
            winOrLoseText.text = "Lose!";
            winOrLoseText.color = Color.red;
        }
    }

    public void PlayerHit(int hits)
    {
        obstaclesHit.text = $"Obstacles Hit: {hits.ToString()}";
    }
}
