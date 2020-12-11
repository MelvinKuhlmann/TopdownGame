using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string sceneToLoad = string.Empty;

    public string areaTransitionName = string.Empty;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tag.Player.ToString())
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
