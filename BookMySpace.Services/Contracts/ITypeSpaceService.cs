// <copyright file="ITypeSpaceService.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using Microsoft.Data.SqlClient;

namespace BookMySpace.Services.Contracts;

/// <summary>
/// Interface for the TypeSpaceService.
/// </summary>
public interface ITypeSpaceService
{

    public Task<bool> AttachTypeSpaceToSpace(SqlConnection sqlConnection, int idSpace, int idTypeSpace);

}