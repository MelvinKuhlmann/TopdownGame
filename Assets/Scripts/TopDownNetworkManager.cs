using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class TopDownNetworkManager : NetworkManager
{
    [Header("UI")]
    public GameObject menuPanel;
    public GameObject gamePanel;

    [Header("Scene Transition")]
    public Image fadeScreen;
    public float fadeSpeed;
    public float initialWaitToLoad = 1f;
    private float waitToLoad;
    private bool shouldLoadAfterFade;
    private string sceneToLoad = string.Empty;

    private bool shouldFadeToBlack;
    private bool shouldFadeFromBlack;

    public void Host()
    {
        StartHost();
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void SetIpAddress(string value)
    {
        networkAddress = value;
    }

    public void Join()
    {
        StartClient();
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void Stop()
    {
        if (mode == NetworkManagerMode.Host)
        {
            StopHost();
        }
        if (mode == NetworkManagerMode.ClientOnly)
        {
            StopClient();
        }
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public override void Start()
    {
        waitToLoad = initialWaitToLoad;
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        base.Start();
    }

    void Update()
    {
        Transition();
        ShouldLoadAfterTransition();
    }

    private void Transition()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    private void ShouldLoadAfterTransition()
    {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                base.ServerChangeScene(sceneToLoad);
            }
        }
    }

    private void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    private void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
  
    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        base.OnClientSceneChanged(conn);
        FadeFromBlack();
        shouldLoadAfterFade = false;
        waitToLoad = initialWaitToLoad;
        sceneToLoad = string.Empty;
    }

    public void ChangeScene(string newSceneName)
    {
        sceneToLoad = newSceneName;
        shouldLoadAfterFade = true;
        FadeToBlack();
    }

}
