// <copyright file="ISpaceService.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity;
using BookMySpace.Entity.DTO;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Services.Contracts;

/// <summary>
/// Interface for the SpaceService.
/// </summary>
public interface ISpaceService
{
    public Task<Space> CreateSpace(SqlConnection sqlConnection, CreateSpace createSpace);
    public Task<Space> GetSpace(SqlConnection sqlConnection, int idSpace);
    public Task<List<Space>> SearchSpace(SqlConnection sqlConnection, string? date, string? startHour, string? endHour, int? capacity);
}