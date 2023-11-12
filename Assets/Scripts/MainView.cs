using UnityEngine;

public class MainView : MonoBehaviour
{
    [SerializeField] private GameObject _leaderboardUI;
    [SerializeField] private GameObject _inputNicknameUI;
    private void Start()
    {
        _leaderboardUI.SetActive(false);
        _inputNicknameUI.SetActive(false);
    }
    public void GoInputNickname()
    {
        this.gameObject.SetActive(false);
        _inputNicknameUI.SetActive(true);
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void GoToLeaderboard()
    {
        this.gameObject.SetActive(false);
        _leaderboardUI.SetActive(true);
    }
}