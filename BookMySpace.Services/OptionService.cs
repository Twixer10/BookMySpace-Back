// <copyright file="OptionService.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity.DTO;
using BookMySpace.Repository.Contracts;
using BookMySpace.Services.Contracts;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Services;

/// <summary>
/// This class represents the service for the options.
/// </summary>
public class OptionService : IOptionService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OptionService"/> class.
    /// </summary>
    private readonly IOptionRepository _optionRepository;

    public OptionService(IOptionRepository optionRepository)
    {
        _optionRepository = optionRepository;
    }

    /// <inheritdoc/>
    public Task<int> CreateOption(SqlConnection sqlConnection, CreateOption createOption)
    {
        return _optionRepository.CreateOption(sqlConnection, createOption);
    }

    /// <inheritdoc/>
    public Task<bool> AttachOptionToSpace(SqlConnection sqlConnection, int idSpace, int idOption)
    {
        return _optionRepository.AttachOptionToSpace(sqlConnection, idSpace, idOption);
    }
}