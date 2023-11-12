using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private GameObject _gameOverUI;

    [SerializeField] private string _nextSceneName;
    void Start()
    {
        _gameOverUI.SetActive(false);
    }

    private void Update()
    {
        _rigidbody2D.gravityScale = 0.5f;
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        switch (xDirection)
        {
            case -1:
                _rigidbody2D.gravityScale = 0;
                if (!(transform.eulerAngles.z >= 25 && transform.eulerAngles.z <= 45))
                    transform.Rotate(0, 0, 60 * Time.deltaTime);
                else
                    transform.Rotate(0, 0, -60 * Time.deltaTime);
                break;
            case 1:
                _rigidbody2D.gravityScale = 0;
                if (!(transform.eulerAngles.z >= 360 && transform.eulerAngles.z <= 45))
                    transform.Rotate(0, 0, -60 * Time.deltaTime);
                else
                    transform.Rotate(0, 0, -0 * Time.deltaTime);
                break;
        }
        _rigidbody2D.AddForce(new Vector2(xDirection * 10 * Time.deltaTime, yDirection * 250 * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Box":
                Destroy(collision.gameObject);
                GameManager.RemainBoxes--;
                break;

            case "Border":

                break;

            case "Finish":
                if (GameManager.RemainBoxes == 0)
                    SceneManager.LoadScene(_nextSceneName);
                break;
            default:
                _gameOverUI.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
}
