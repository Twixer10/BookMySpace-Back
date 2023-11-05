// <copyright file="AdoCreateOptionRepository.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity.DTO;
using BookMySpace.Repository.Contracts;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Repository;

/// <summary>
/// Repository for the creation of an option.
/// </summary>
public class AdoOptionRepository : IOptionRepository
{
    public async Task<int> CreateOption(SqlConnection sqlConnection, CreateOption createOption)
    {
        var command = new SqlCommand("INSERT INTO BMS.dbo.[option] (name) OUTPUT INSERTED.idOption VALUES (@Name)", sqlConnection);
        command.Parameters.AddWithValue("@Name", createOption.Name);

        await sqlConnection.OpenAsync();
        var id = (int)command.ExecuteScalar();
        await sqlConnection.CloseAsync();

        return id;
    }

    public async Task<bool> AttachOptionToSpace(SqlConnection sqlConnection, int idSpace, int idOption)
    {
        var command = new SqlCommand("INSERT INTO BMS.dbo.[optionSpace] (idSpace, idOption) VALUES (@IdSpace, @IdOption)", sqlConnection);
        command.Parameters.AddWithValue("@IdSpace", idSpace);
        command.Parameters.AddWithValue("@IdOption", idOption);

        await sqlConnection.OpenAsync();
        var rowsAffected = await command.ExecuteNonQueryAsync();
        await sqlConnection.CloseAsync();

        return rowsAffected > 0;
    }
}