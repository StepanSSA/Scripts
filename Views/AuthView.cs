using UnityEngine;
using UnityEngine.UI;

public class AuthView : MonoBehaviour
{
    [SerializeField]
    private Button SignInBtn;
    [SerializeField] 
    private Button RegisterBtn;
    [SerializeField]
    private GameObject AuthBtnWindow;
    [SerializeField]
    private GameObject SignInWindow;

    void Start()
    {
        SignInBtn.onClick.AddListener(OnClickSignInBtn);
        RegisterBtn.onClick.AddListener(OnClickRegisterBtn);
    }

    /// <summary>
    /// ������������ ������� ������ �����������
    /// </summary>
    private void OnClickRegisterBtn()
    {
        Application.OpenURL(OidcOptions.Authority + "/Auth/Register?returnUrl=Desktop");
        Debug.Log("Register");
    }

    /// <summary>
    /// ������������ ������� ������ �����������
    /// </summary>
    private void OnClickSignInBtn()
    {
        WindowHelper.ChangeWindow(AuthBtnWindow, SignInWindow);
        Debug.Log("Sign");
    }

}
