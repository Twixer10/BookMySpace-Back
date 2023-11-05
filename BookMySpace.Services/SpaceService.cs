// <copyright file="SpaceService.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity;
using BookMySpace.Entity.DTO;
using BookMySpace.Repository.Contracts;
using BookMySpace.Services.Contracts;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Services;

/// <summary>
/// Service for the Space.
/// </summary>
public class SpaceService : ISpaceService
{
    private readonly ISpaceRepository _spaceRepository;
    private readonly ITypeSpaceRepository _typeSpaceRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpaceService"/> class.
    /// </summary>
    /// <param name="spaceRepository">Space repository.</param>
    public SpaceService(ISpaceRepository spaceRepository, ITypeSpaceRepository typeSpaceRepository)
    {
        this._spaceRepository = spaceRepository;
        this._typeSpaceRepository = typeSpaceRepository;
    }

    /// <summary>
    /// Create a space.
    /// </summary>
    /// <param name="sqlConnection"></param>
    /// <param name="createSpace">The space to create.</param>
    /// <returns>The created space.</returns>
    public async Task<Space> CreateSpace(SqlConnection sqlConnection, CreateSpace createSpace)
    {
        try
        {
            var typeSpace = await this._typeSpaceRepository.GetTypeSpace(sqlConnection, createSpace.IdTypeSpace);
            var newSpaceId = await this._spaceRepository.CreateSpace(sqlConnection, createSpace);
            var space = new Space()
            {
                Description = createSpace.Description,
                IdSpace = newSpaceId,
                MaxCapacity = createSpace.MaxCapacity,
                Name = createSpace.Name,
                TypeSpace = typeSpace,
                Url = createSpace.Url,
            };
            return space;
        }
        catch (Exception e)
        {
            throw new Exception("Error while creating space", e);
        }
    }

    /// <inheritdoc/>
    public async Task<Space> GetSpace(SqlConnection sqlConnection, int idSpace)
    {
        try
        {
            var getSpace = await this._spaceRepository.GetSpace(sqlConnection, idSpace);
            var typeSpace = await this._typeSpaceRepository.GetTypeSpace(sqlConnection, getSpace.IdSpace);
            var options = await this._spaceRepository.GetOptions(sqlConnection, idSpace);

            var space = new Space()
            {
                Description = getSpace.Description,
                IdSpace = getSpace.IdSpace,
                MaxCapacity = getSpace.MaxCapacity,
                Name = getSpace.Name,
                TypeSpace = typeSpace,
                Url = getSpace.Url,
                Options = options,
            };

            //space.TypeSpace = typeSpace;

            //space.Options = options;
            return space;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<List<Space>> SearchSpace(SqlConnection sqlConnection, string? date, string? startHour, string? endHour, int? capacity)
    {
        try
        {
            var startDateTime = date + 'T' + startHour;
            var endDateTime = date + 'T' + endHour;

            var selectedSpaces = await this._spaceRepository.SearchSpace(sqlConnection, capacity, startDateTime, endDateTime);

            var resultSpaces = new List<Space>();

            foreach (var space in selectedSpaces)
            {
                var typeSpace = await this._typeSpaceRepository.GetTypeSpace(sqlConnection, space.TypeSpaceId);
                resultSpaces.Add(new Space()
                {
                    IdSpace = space.IdSpace,
                    Name = space.Name,
                    Description = space.Description,
                    MaxCapacity = space.MaxCapacity,
                    TypeSpace = typeSpace,
                    Url = space.Url,
                });
            }

            return resultSpaces;
        }
        catch (Exception e)
        {
            throw new Exception("Error searching space", e);
        }
    }
}