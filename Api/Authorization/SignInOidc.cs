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
    /// ���������� ������ ����������� � ��������� ������������.
    /// </summary>
    /// <param name="model"></param>
    /// <returns>true ���� ����������� ������ �������, ����� false</returns>
    public async Task<bool> Authorize(SignInModel model)
    {
        var disco = await _httpClient.GetDiscoveryDocumentAsync(OidcOptions.Authority);
        if (disco.IsError)
        {
            //����� ���������� ����� ������
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
            //����� ���������� ����� ������
            return false;
        }

        var user = await GetUser(model.Username,tokenResponse.AccessToken);
        _userRepository.InsertUser(user);

        return true;
    }

    /// <summary>
    /// ���������� ������ ���������� � ������������
    /// </summary>
    /// <param name="email">Email ������������</param>
    /// <param name="token">����� ������������</param>
    /// <returns>���������� ������������</returns>
    private async Task<UserModel> GetUser(string email, string token)
    {
        var response = await _httpClient.GetAsync($"https://localhost:7086/api/User/User/userinfo?email={email}");
        var stringData = await response.Content.ReadAsStringAsync();

        var user = JsonConvert.DeserializeObject<UserModel>(stringData);
        user.Token = token;

        return user;
    }

}