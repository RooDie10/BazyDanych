﻿using Microsoft.Data.Sqlite;

public class UserInventorySQLite { //klasa do operacji na bazie danych
    private string _connectionString = "Data Source=Inventory.db";

    /// <summary>
    /// Insert into database
    /// </summary>
    /// <param name="newUser"></param>
    public void NewQuerry(User newUser) {
        var querry = $"insert into Users values({newUser.Id}, '{newUser.FirstName}', '{newUser.LastName}', {newUser.Age}, '{newUser.Mail}')";

        ExecuteCommand(querry);
    }

    /// <summary>
    /// Delete from database
    /// </summary>
    /// <param name="userId"></param>
    public void NewQuerry(int userId) {
        var querry = $"delete from Users where id = {userId}";

        ExecuteCommand(querry);
    }

    /// <summary>
    /// Update FirstName
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="newFirstName"></param>
    public void NewQuerry(int userId, string newFirstName) {
        var querry = $"update Users set FirstName = '{newFirstName}' where id={userId}";

        ExecuteCommand(querry);
    }

    /// <summary>
    /// Get all data
    /// </summary>
    /// <returns></returns>
    public IEnumerable<User> GetData() {
        var querry = $"select * from Users";

        var result = new List<User>();
        var sqlConnection = new SqliteConnection(_connectionString);
        sqlConnection.Open();

        var sqlCommand = new SqliteCommand(querry, sqlConnection);


        var reader = sqlCommand.ExecuteReader();

        while (reader.Read()) {
            var dbId = int.Parse(reader["Id"].ToString());
            var dbFirstName = $"{reader["FirstName"]}";
            var dbLastName = $"{reader["LastName"]}";
            var dbAge = int.Parse(reader["Age"].ToString());
            var dbMail = $"{reader["Mail"]}";

            result.Add(
                new User {
                    Id = dbId,
                    FirstName = dbFirstName,
                    LastName = dbLastName,
                    Age = dbAge,
                    Mail = dbMail
                }
            );
        }

        reader.Close();

        sqlCommand.Dispose();
        sqlConnection.Dispose();

        return result;
    }

    /// <summary>
    /// Put string that will be put after 'like'
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    public IEnumerable<User> GetData(string syntex) {
        var querry = $"select * from Users where FirstName like @Value"; //@value jako atrybut

        var result = new List<User>();
        var sqlConnection = new SqliteConnection(_connectionString);
        sqlConnection.Open();

        var sqlCommand = new SqliteCommand(querry, sqlConnection);

        sqlCommand.Parameters.AddWithValue("@Value", syntex + "%");

        var reader = sqlCommand.ExecuteReader();

        while (reader.Read()) {
            var dbId = int.Parse(reader["Id"].ToString());
            var dbFirstName = $"{reader["FirstName"]}";
            var dbLastName = $"{reader["LastName"]}";
            var dbAge = int.Parse(reader["Age"].ToString());
            var dbMail = $"{reader["Mail"]}";

            result.Add(
                new User {
                    Id = dbId,
                    FirstName = dbFirstName,
                    LastName = dbLastName,
                    Age = dbAge,
                    Mail = dbMail
                }
            );
        }

        reader.Close();

        sqlCommand.Dispose();
        sqlConnection.Dispose();

        return result;
    }


    private void ExecuteCommand(string querry) {
        var sqlConnection = new SqliteConnection(_connectionString);
        sqlConnection.Open();

        var sqlCommand = new SqliteCommand(querry, sqlConnection);
        sqlCommand.ExecuteNonQuery();

        sqlCommand.Dispose();
        sqlConnection.Dispose();
    }


}