using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public NetworkManager networkManager;
    public GameObject menuPanel;
    public GameObject gamePanel;

    public void Host()
    {
        networkManager.StartHost();
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void SetIpAddress(string value)
    {
        networkManager.networkAddress = value;
    }

    public void Join()
    {
        networkManager.StartClient();
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void Stop()
    {
        if (networkManager.mode == NetworkManagerMode.Host)
        {
            networkManager.StopHost();
        }
        if (networkManager.mode == NetworkManagerMode.ClientOnly)
        {
            networkManager.StopClient();
        }
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    private void Start()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void ServerChangeScene(string newSceneName)
    {
        networkManager.ServerChangeScene(newSceneName);
    }
}
