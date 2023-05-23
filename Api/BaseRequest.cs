using IdentityModel.Client;
using System;
using System.Net.Http;

public class BaseRequest
{
    protected const string _requestBasePath = "https://localhost:7083/api";
    protected HttpClient _httpClient;
    protected UserRepository _userRepository;

    public BaseRequest()
    {
        _userRepository = new UserRepository();
        _httpClient = new HttpClient();
        _httpClient.SetBearerToken(_userRepository.GetUserToken());
        _httpClient.BaseAddress = new Uri(_requestBasePath);
    }
}
