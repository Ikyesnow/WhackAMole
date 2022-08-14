using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class HighScoreController : MonoBehaviour
{
    [SerializeField] private GameObject _painel;
    [SerializeField] private GameObject _loading;

    public void Start()
    {
        _painel.SetActive(false);
        _loading.SetActive(true);

        
        GetHighScore();
    }

    private void GetHighScore()
    {
        var scoreClient = new ScoresClient();
        var scores = scoreClient.GetHighScores();

        var scoreRows = _painel.GetComponentsInChildren<RectTransform>()
            .Where(x => x.name.Contains("Panel"))
            .ToArray();


        for (int i = 0; i < scores.Count; i++)
        {
            
            var textsComponents = scoreRows[i].GetComponentsInChildren<TextMeshProUGUI>();
            textsComponents[0].text = scores[i].Nome;
            textsComponents[1].text = scores[i].Ponto.ToString();
        }
        _loading.SetActive(false);
        _painel.SetActive(true);
    }
}
