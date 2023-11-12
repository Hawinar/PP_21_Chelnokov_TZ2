using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputNicknameView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nicknameInputField;
    [SerializeField] private TextMeshProUGUI _incorrectNicknameTMP;

    private WaitForSeconds seconds = new WaitForSeconds(3);
    public void StartNewGame()
    {

        if (_nicknameInputField.text != "")
        {
            GameManager.Nickname = _nicknameInputField.text;
            SceneManager.LoadScene("Level1");
        }
        else
        {
            StartCoroutine(AlarmIncorreckNickname("Никнейм должен содержать символы"));
        }
    }
    private IEnumerator AlarmIncorreckNickname(string text)
    {
        _incorrectNicknameTMP.text = text;
        _incorrectNicknameTMP.gameObject.SetActive(true);
        yield return seconds;
        _incorrectNicknameTMP.gameObject.SetActive(false);
    }
}
