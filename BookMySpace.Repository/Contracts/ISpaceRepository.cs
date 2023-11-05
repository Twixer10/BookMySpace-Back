// <copyright file="ISpaceRepository.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity;
using BookMySpace.Entity.DTO;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Repository.Contracts;

/// <summary>
/// Interface for the SpaceRepository.
/// </summary>
public interface ISpaceRepository
{
    /// <summary>
    /// Create a space.
    /// </summary>
    /// <param name="sqlConnection"></param>
    /// <param name="createSpace"></param>
    /// <param name="space">Space to create.</param>
    /// <returns>The created space.</returns>
    public Task<int> CreateSpace(SqlConnection sqlConnection, CreateSpace createSpace);

    /// <summary>
    /// Get a space.
    /// </summary>
    /// <param name="sqlConnection">Sql connection.</param>
    /// <param name="idSpace">Id of the space.</param>
    /// <returns>The space.</returns>
    public Task<GetSpace> GetSpace(SqlConnection sqlConnection, int idSpace);

    /// <summary>
    /// Get options of a space.
    /// </summary>
    /// <param name="sqlConnection">Sql connection.</param>
    /// <param name="idSpace">Id of the space.</param>
    /// <returns>The options of the space.</returns>
    public Task<List<Option>> GetOptions(SqlConnection sqlConnection, int idSpace);


    public Task<List<SearchSpace>> SearchSpace(SqlConnection sqlConnection, int? capacity, string? startDateTime, string? endDateTime);
}