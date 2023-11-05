// <copyright file="TypeSpaceRepository.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity;
using BookMySpace.Repository.Contracts;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Repository;

/// <summary>
/// This class represents a type space repository.
/// </summary>
public class AdoTypeSpaceRepository : ITypeSpaceRepository
{
    public async Task<TypeSpace> GetTypeSpace(SqlConnection sqlConnection, int idTypeSpace)
    {
        SqlCommand command = new SqlCommand("SELECT * FROM BMS.dbo.[typeSpace] WHERE idTypeSpace = @IdTypeSpace", sqlConnection);

        command.Parameters.AddWithValue("@IdTypeSpace", idTypeSpace);

        await sqlConnection.OpenAsync();
        SqlDataReader reader = await command.ExecuteReaderAsync();
        await reader.ReadAsync();
        var typeSpace = new TypeSpace
        {
            IdTypeSpace = (int)reader["idTypeSpace"],
            Name = (string)reader["name"],
        };
        await sqlConnection.CloseAsync();

        return typeSpace;
    }
}