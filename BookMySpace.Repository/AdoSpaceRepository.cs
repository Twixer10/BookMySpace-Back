// <copyright file="AdoSpaceRepository.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity;
using BookMySpace.Entity.DTO;
using BookMySpace.Repository.Contracts;
using Microsoft.Data.SqlClient;
using Net.Code.ADONet;

namespace BookMySpace.Repository;

/// <summary>
/// Repository for the Space.
/// </summary>
public class AdoSpaceRepository : ISpaceRepository
{
    /// <summary>
    /// Create a space.
    /// </summary>
    /// <param name="sqlConnection1"></param>
    /// <param name="createSpace">Space to create.</param>
    /// <returns>The created space.</returns>
    public async Task<int> CreateSpace(SqlConnection sqlConnection, CreateSpace createSpace)
    {
        SqlCommand command = new SqlCommand("INSERT INTO BMS.dbo.[space] (name, description, maxCapacity, urlImage, idTypeSpace) OUTPUT INSERTED.idSpace VALUES (@Name, @Description, @MaxCapacity, @UrlImage, @IdTypeSpace)", sqlConnection);

        command.Parameters.AddWithValue("@Name", createSpace.Name);
        command.Parameters.AddWithValue("@Description", createSpace.Description);
        command.Parameters.AddWithValue("@MaxCapacity", createSpace.MaxCapacity);
        command.Parameters.AddWithValue("@UrlImage", createSpace.Url);
        command.Parameters.AddWithValue("@IdTypeSpace", createSpace.IdTypeSpace);

        await sqlConnection.OpenAsync();
        var id = (int)command.ExecuteScalar();
        await sqlConnection.CloseAsync();

        return id;
    }

    public async Task<List<SearchSpace>> SearchSpace(SqlConnection sqlConnection, int? capacity, string? startDateTime, string? endDateTime)
    {
        SqlCommand command = new SqlCommand("SELECT * FROM dbo.GetAvailableSpaces(@StartDate, @EndDate, @MinCapacity)", sqlConnection);

        command.Parameters.AddWithValue("@StartDate", startDateTime);
        command.Parameters.AddWithValue("@EndDate", endDateTime);
        command.Parameters.AddWithValue("@MinCapacity", capacity);

        await sqlConnection.OpenAsync();

        SqlDataReader reader = await command.ExecuteReaderAsync();
        var spacesList = new List<SearchSpace>();

        while (await reader.ReadAsync())
        {
            spacesList.Add(new SearchSpace
            {
                IdSpace = (int)reader["idSpace"],
                Name = (string)reader["name"],
                Description = (string)reader["description"],
                MaxCapacity = (int)reader["maxCapacity"],
                Url = (string)reader["urlImage"],
                TypeSpaceId = (int)reader["idTypeSpace"],
            });
        }
        await sqlConnection.CloseAsync();

        return spacesList;
    }

    /// <inheritdoc/>
    public async Task<GetSpace> GetSpace(SqlConnection sqlConnection, int idSpace)
    {
        SqlCommand command = new SqlCommand(
            "SELECT * FROM BMS.dbo.V_Space_Details vsd WHERE idSpace = @IdSpace",
            sqlConnection);

        command.Parameters.AddWithValue("@IdSpace", idSpace);

        await sqlConnection.OpenAsync();
        SqlDataReader reader = await command.ExecuteReaderAsync();
        await reader.ReadAsync();

        var space = new GetSpace()
        {
            IdSpace = (int)reader["idSpace"],
            Name = (string)reader["SpaceName"],
            Description = (string)reader["SpaceDescription"],
            MaxCapacity = (int)reader["MaxCapacity"],
            Url = (string)reader["ImageUrl"],
        };
        await sqlConnection.CloseAsync();

        return space;
    }

    /// <inheritdoc/>
    public async Task<List<Option>> GetOptions(SqlConnection sqlConnection, int idSpace)
    {
        SqlCommand command = new SqlCommand(
            @"SELECT o.idOption, o.name 
        FROM[BMS].[dbo].[option] o
        INNER JOIN[BMS].[dbo].[optionSpace] os ON o.idOption = os.idOption
        INNER JOIN[BMS].[dbo].[space] s ON os.idSpace = s.idSpace
        WHERE s.idSpace = @IdSpace",
            sqlConnection);

        command.Parameters.AddWithValue("@IdSpace", idSpace);

        await sqlConnection.OpenAsync();
        SqlDataReader reader = await command.ExecuteReaderAsync();
        var options = new List<Option>();
        while (await reader.ReadAsync())
        {
            options.Add(new Option
            {
                IdOption = (int)reader["idOption"],
                Name = (string)reader["name"],
            });
        }

        return options;
    }
}

