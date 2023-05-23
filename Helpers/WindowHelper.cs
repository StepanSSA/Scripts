using UnityEngine;

public class WindowHelper : MonoBehaviour
{

    /// <summary>
    /// ��������� ������� GameObject � ���������� ���������
    /// </summary>
    /// <param name="currentWindow">������� ������</param>
    /// <param name="nextWindow">��������� ������</param>
    public static void ChangeWindow(GameObject currentWindow, GameObject nextWindow)
    {
        currentWindow.SetActive(false);
        nextWindow.SetActive(true);
        Debug.Log($"ChangeWindow from {currentWindow.name} to {nextWindow.name}");
    }
}
