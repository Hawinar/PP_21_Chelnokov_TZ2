using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerTMP;
    [SerializeField] private TextMeshProUGUI _remainBoxes;
    private int _allBoxes;
    private float _time;
    private int _minutes = 0;
    private int _seconds = 0;
    private void Start()
    {
        Time.timeScale = 1f;
        _allBoxes = GameObject.FindGameObjectsWithTag("Box").Count();
        GameManager.RemainBoxes = _allBoxes;
    }

    private void Update()
    {
        if (Time.time > _time)
        {
            GameManager.Seconds++;
            _seconds++;
            Debug.Log(GameManager.Seconds);
            switch (_seconds)
            {
                case 60:
                    _minutes++;
                    _seconds = 0;
                    break;
            }

            _time = Time.time + 1;
            _remainBoxes.text = $"{_allBoxes - GameManager.RemainBoxes}/{_allBoxes}";
            _timerTMP.text = _minutes + ":" + _seconds;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
