using UnityEngine;

public class DialogEvents : MonoBehaviour
{
    public delegate void DialogClosedEventHandler();
    public static event DialogClosedEventHandler OnDialogClose;

    public static void OnDialogClosed()
    {
        if (OnDialogClose != null)
        {
            OnDialogClose();
        }
    }
}
