using Assets.Scripts.Models;
using TMPro;
using UnityEngine;

public class SignInPresenter
{
	private SignInModel _signInModel;

	public SignInPresenter(SignInView view)
	{
		_signInModel = new SignInModel(view);
	}


	/// <summary>
	/// �������� ����� � ������ �� ����� ����� � �������� �� � ������
	/// </summary>
	/// <param name="username">���� ����� ������</param>
	/// <param name="password">���� ����� ������</param>
	public void SignIn(GameObject username, GameObject password)
	{
		var login = username.gameObject.GetComponent<TMP_InputField>().text;
		var pass = password.gameObject.GetComponent<TMP_InputField>().text;
		UnityEngine.Debug.Log(login+ " " + pass);
        _signInModel.Authorize(login, pass);
    }
}
