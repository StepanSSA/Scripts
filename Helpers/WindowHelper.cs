using UnityEngine;

public class WindowHelper : MonoBehaviour
{

    /// <summary>
    /// Выключает текущий GameObject и активирует следующий
    /// </summary>
    /// <param name="currentWindow">Текущий объект</param>
    /// <param name="nextWindow">Следубщий объект</param>
    public static void ChangeWindow(GameObject currentWindow, GameObject nextWindow)
    {
        currentWindow.SetActive(false);
        nextWindow.SetActive(true);
        Debug.Log($"ChangeWindow from {currentWindow.name} to {nextWindow.name}");
    }
}
