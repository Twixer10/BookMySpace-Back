// <copyright file="IOptionRepository.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity.DTO;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Repository.Contracts;

/// <summary>
/// Interface for the OptionRepository.
/// </summary>
public interface IOptionRepository
{
    /// <summary>
    /// Create an option.
    /// </summary>
    /// <param name="sqlConnection">SQL connection.</param>
    /// <param name="createOption">Option to create.</param>
    /// <returns>Id of the created option.</returns>
    public Task<int> CreateOption(SqlConnection sqlConnection, CreateOption createOption);

    /// <summary>
    /// Attach an option to a space.
    /// </summary>
    /// <param name="sqlConnection">SQL connection.</param>
    /// <param name="idSpace">Id of the space.</param>
    /// <param name="idOption">Id of the option.</param>
    /// <returns>True if the option has been attached to the space, false otherwise.</returns>
    public Task<bool> AttachOptionToSpace(SqlConnection sqlConnection, int idSpace, int idOption);
}