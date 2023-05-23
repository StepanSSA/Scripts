using UnityEngine;

namespace Assets.Scripts.Models
{
    public class SignInModel
    {
        private SignInView _view;
        private SignInOidc _signInOidc;

        public string Username { get; private set; }
        public string Password { get; private set; }

        public SignInModel(SignInView view)
        {
            _view=view;
            _signInOidc = new SignInOidc();
        }


        /// <summary>
        /// Создает модель авторизации и переает её в метод авторизации.
        /// При успешной авторизации вызывает метод SignInView.ChangeWindow
        /// </summary>
        /// <param name="username">Логин</param>
        /// <param name="password">Пароль</param>
        public async void Authorize(string username, string password)
        {
            Username = username;
            Password = password;
            var boolResult = await _signInOidc.Authorize(this);
            if (!boolResult)
            {
                Debug.Log("Authorize Error");
                return;
            }

            _view.ChangeWindow();
        }

    }
}
