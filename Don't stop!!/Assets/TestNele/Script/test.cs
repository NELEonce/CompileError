using UnityEngine;
using Doozy.Engine.UI;

public class test : MonoBehaviour
{
    [SerializeField]
    string PopupName;

    public void PopupShow()
    {
        UIPopup popup = UIPopupManager.GetPopup(PopupName);
        UIPopupManager.ShowPopup(popup, popup.AddToPopupQueue, false);
    }
}