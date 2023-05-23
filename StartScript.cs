using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    private readonly UserRepository _userRepository = new UserRepository();
    [SerializeField]
    private GameObject AuthScreen;
    [SerializeField]
    private GameObject MainScreen;


    void Start()
    {
        _userRepository.CreateDataTable();
        CheckAuth();
        UserRepository.OnTableDeleted += OpenAuthScreen;
    }

    /// <summary>
    /// ������������� ����� ����� ������ �� ��������
    /// </summary>
    private void OpenAuthScreen()
    {
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadSceneAsync(0);
        _userRepository.CreateDataTable();
        MainScreen.SetActive(false);
        AuthScreen.SetActive(true);
    }

    /// <summary>
    /// ��������� ������� ������������ � ��
    /// ���� ������������ ����, �������� ������� ��������, 
    /// ����� �������� �������� ��������������
    /// </summary>
    private void CheckAuth()
    {
        if(_userRepository.CheckingTableFilling())
        {
            MainScreen.SetActive(true);
            MainScreen.GetComponent<CourseListView>()?.StartFilling();
            
            return;
        }
        AuthScreen.SetActive(true);
    }
}
