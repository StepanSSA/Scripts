using Mono.Data.Sqlite;

public class UserRepository
{
    public delegate void TableDeleted();
    public static event TableDeleted OnTableDeleted;

    private readonly string _dbPath;
    private readonly SqliteConnection _connection;
    private readonly SqliteCommand _command;

    public UserRepository()
    {
        _dbPath = "URI=file:UserData.db";
        _connection = new SqliteConnection(_dbPath);
        _command = _connection.CreateCommand();
    }


    /// <summary>
    /// Создаёт таблицу пользователя, если она ещё не создана 
    /// </summary>
    public void CreateDataTable()
    {
        _connection.Open();

        _command.CommandText = "CREATE TABLE IF NOT EXISTS User (" +
           " id TEXT PRIMARY KEY," +
           " name VARCHAR(20)," +
           " lastname VARCHAR(20)," +
           " email VARCHAR(30)," +
           " birthDate VARCHAR(30)," +
           " role VARCHAR(20)," +
           " token VARCHAR(50))";
        _command.ExecuteNonQuery();
        _connection.Close();

    }

    /// <summary>
    /// Записывает пользователя в базу данных
    /// </summary>
    /// <param name="user"></param>
    public void InsertUser(UserModel user)
    {
        _connection.Open();

        _command.CommandText =
            "INSERT INTO User (id, name, lastname, email, birthDate, role,  token)" +
            $"VALUES('{user.Id}','{user.Name}','{user.Lastname}','{user.Email}','{user.BirthDate}','{user.Role}','{user.Token}')";
        _command.ExecuteNonQuery();

        _connection.Close();
    }

    /// <summary>
    /// Возвращает пользователя из базы данных
    /// </summary>
    /// <returns></returns>
    public UserModel SelectUser()
    {
        _connection.Open();

        _command.CommandText = "SELECT * FROM User";
        var reader = _command.ExecuteReader();

        var user = new UserModel()
        {
            Id = reader["id"].ToString(),
            Name = reader["name"].ToString(),
            Lastname = reader["lastname"].ToString(),
            Email = reader["email"].ToString(),
            BirthDate = reader["birthDate"].ToString(),
            Role = reader["role"].ToString(),
            Token = reader["token"].ToString()
        };

        reader.Close();
        _connection.Close();
        return user;
    }

    /// <summary>
    /// Обнавляет данные пользователя
    /// </summary>
    /// <param name="user"></param>
    public void UpdateUser(UserModel user)
    {
        _connection.Open();

        _command.CommandText = $"UPDATE User SET " +
            $"id = '{user.Id}'," +
            $"name = '{user.Name}'," +
            $"lastname = '{user.Lastname}'," +
            $"email = '{user.Email}'," +
            $"birthDate = '{user.BirthDate}'," +
            $"role = '{user.Role}'," +
            $"token = '{user.Token}' WHERE id = {user.Id}";
        _command.ExecuteNonQuery();

        _connection.Close();
    }


    public void DropTable() 
    {
        _connection.Open();

        _command.CommandText = "DROP TABLE User";
        _command.ExecuteNonQuery();

        _connection.Close();

        OnTableDeleted?.Invoke();
    }


    /// <summary>
    /// Поверяет наличие данных втаблице
    /// </summary>
    /// <returns></returns>
    public bool CheckingTableFilling()
    {
        _connection.Open();

        _command.CommandText = $"SELECT * FROM User";
        var reader = _command.ExecuteReader();

        var stringValue = reader.GetValue(0).ToString();
        if (string.IsNullOrEmpty(stringValue)) 
        {
            _connection.Close();
            return false;
        }
        reader.Close();
        _connection.Close();
        return true;
    }


    /// <summary>
    /// Возвращает токен доступа пользователя
    /// </summary>
    /// <returns></returns>
    public string GetUserToken()
    {
        _connection.Open();

        _command.CommandText = $"SELECT token FROM User";
        var reader = _command.ExecuteReader();

        var stringValue = reader.GetValue(0).ToString();
        if (string.IsNullOrEmpty(stringValue))
        {
            _connection.Close();
            return null;
        }

        var token = reader.GetValue(0).ToString();

        reader.Close();
        _connection.Close();

        return token;
    }
}
