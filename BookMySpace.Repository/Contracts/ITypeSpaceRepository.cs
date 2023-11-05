// <copyright file="ITypeSpaceRepository.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Repository.Contracts;

/// <summary>
/// Interface for the TypeSpaceRepository.
/// </summary>
public interface ITypeSpaceRepository
{
    public Task<TypeSpace> GetTypeSpace(SqlConnection sqlConnection, int idTypeSpace);
}