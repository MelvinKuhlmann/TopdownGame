using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [Scene]
    public string sceneToLoad = string.Empty;

    public string areaTransitionName = string.Empty;

   /* public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;*/

    private void Start()
    {
      /*  if (UIFade.instance != null)
        {
            UIFade.instance.FadeFromBlack();
        }*/
    }

    private void Update()
    {
       /* if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                FindObjectOfType<TopDownNetworkManager>().ServerChangeScene(sceneToLoad);
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tag.Player.ToString())
        {
            FindObjectOfType<TopDownNetworkManager>().ChangeScene(sceneToLoad);
            /* shouldLoadAfterFade = true;
             UIFade.instance.FadeToBlack();*/
        }
    }
}
