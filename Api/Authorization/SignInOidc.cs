using Assets.Scripts.Models;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json;

public class SignInOidc
{
    private readonly UserRepository _userRepository;
    private HttpClient _httpClient;
    public SignInOidc()
    {
        _httpClient = new HttpClient();
        _userRepository = new UserRepository();
    }


    /// <summary>
    /// Отправляет запрос авторизации и сохраняет пользователя.
    /// </summary>
    /// <param name="model"></param>
    /// <returns>true если авторизация прошла успешно, иначе false</returns>
    public async Task<bool> Authorize(SignInModel model)
    {
        var disco = await _httpClient.GetDiscoveryDocumentAsync(OidcOptions.Authority);
        if (disco.IsError)
        {
            //Нужно реализоват вывод ошибки
            return false;
        }

        var tokenClient = new TokenClient(_httpClient, new TokenClientOptions()
        {
            ClientId = OidcOptions.ClientId,
            ClientSecret = OidcOptions.ClientSecret,
            Address = disco.TokenEndpoint,
        });
        var tokenResponse = await tokenClient.RequestPasswordTokenAsync(model.Username, model.Password, OidcOptions.Scope);

        if (tokenResponse.IsError)
        {
            //Нужно реализоват вывод ошибки
            return false;
        }

        var user = await GetUser(model.Username,tokenResponse.AccessToken);
        _userRepository.InsertUser(user);

        return true;
    }

    /// <summary>
    /// Отправляет запрос информации о пользователе
    /// </summary>
    /// <param name="email">Email пользователя</param>
    /// <param name="token">Токен пользователя</param>
    /// <returns>Возвращает пользователя</returns>
    private async Task<UserModel> GetUser(string email, string token)
    {
        var response = await _httpClient.GetAsync($"https://localhost:7086/api/User/User/userinfo?email={email}");
        var stringData = await response.Content.ReadAsStringAsync();

        var user = JsonConvert.DeserializeObject<UserModel>(stringData);
        user.Token = token;

        return user;
    }

}