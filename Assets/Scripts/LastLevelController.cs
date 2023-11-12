using UnityEngine;

public class LastLevelController : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameManager.RemainBoxes ==0)
            SaveResults.Save();
    }
}