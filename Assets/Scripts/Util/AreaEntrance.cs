using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;

    private void Start()
    {
        if (transitionName.Equals(PlayerController.instance.areaTransitionName))
        {
            PlayerController.instance.transform.position = transform.position;
        }
    }
}
