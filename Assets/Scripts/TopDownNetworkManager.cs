using Mirror;
using UnityEngine;

public class TopDownNetworkManager : NetworkManager
{
    [Header("UI")]
    public GameObject menuPanel;
    public GameObject gamePanel;

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
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        base.Start();
    }

    public override void ServerChangeScene(string newSceneName)
    {
        base.ServerChangeScene(newSceneName);
    }

}
