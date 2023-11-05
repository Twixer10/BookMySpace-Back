// <copyright file="SpaceController.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity.DTO;
using BookMySpace.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BookMySpace.API.Controllers;

/// <summary>
/// Controller for the Space.
/// </summary>
[ApiController]
public class SpaceController : ControllerBase
{
    /// <summary>
    /// SpaceService.
    /// </summary>
    private ISpaceService _spaceService;
    /// <summary>
    /// Configuration.
    /// </summary>
    private IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpaceController"/> class.
    /// </summary>
    /// <param name="spaceService"></param>
    public SpaceController(ISpaceService spaceService, IConfiguration configuration)
    {
        this._spaceService = spaceService;
        this._configuration = configuration;
    }

    /// <summary>
    /// Create a space.
    /// </summary>
    /// <param name="createSpace">Object to create a space.</param>
    /// <returns>The created space.</returns>
    [HttpPost]
    [Route("[controller]")]
    public async Task<IActionResult> CreateSpace(CreateSpace createSpace)
    {
        try
        {
            var sqlConnection = new SqlConnection(this._configuration.GetConnectionString("msSqlConnectionString"));
            var createdSpace = await this._spaceService.CreateSpace(sqlConnection, createSpace);
            return this.Ok(createdSpace);
        }
        catch (Exception e)
        {
            return this.Problem(e.Message);
        }
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<IActionResult> GetSpace(int idSpace)
    {
        try
        {
            var sqlConnection = new SqlConnection(this._configuration.GetConnectionString("msSqlConnectionString"));
            var space = await this._spaceService.GetSpace(sqlConnection, idSpace);
            return this.Ok(space);
        }
        catch (Exception e)
        {
            return this.Problem(e.Message);
        }
    }

    [HttpGet]
    [Route("[controller]/[action]")]
    public async Task<IActionResult> SearchSpace(string? date, string? startHour, string? endHour, int? capacity)
    {
        try
        {
            var sqlConnection = new SqlConnection(this._configuration.GetConnectionString("msSqlConnectionString"));
            var searchSpace = await this._spaceService.SearchSpace(sqlConnection, date, startHour, endHour, capacity);
            return this.Ok(searchSpace);
        }
        catch (Exception e)
        {
            return this.Problem(e.Message);
        }
    }
}