// <copyright file="OptionController.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity.DTO;
using BookMySpace.Services.Contracts;
using Microsoft.Data.SqlClient;

namespace BookMySpace.API.Controllers;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for the Option entity.
/// </summary>
[ApiController]
public class OptionController : ControllerBase
{
    /// <summary>
    /// OptionService.
    /// </summary>
    private readonly IOptionService _optionService;

    /// <summary>
    /// Configuration.
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="OptionController"/> class.
    /// </summary>
    /// <param name="optionService">Instance of the OptionService.</param>
    /// <param name="configuration">Instance of the configuration.</param>
    public OptionController(IOptionService optionService, IConfiguration configuration)
    {
        this._optionService = optionService;
        this._configuration = configuration;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<IActionResult> CreateOption(CreateOption createOption)
    {
        try
        {
            var sqlConnection = new SqlConnection(this._configuration.GetConnectionString("msSqlConnectionString"));
            var createdOption = await this._optionService.CreateOption(sqlConnection, createOption);
            return this.Ok(createdOption);
        }
        catch (Exception e)
        {
            return this.Problem(e.Message);
        }
    }

    [Route("[controller]/[action]")]
    [HttpPost]
    public async Task<IActionResult> AttachToSpace(AttachOptionToSpace attachOptionToSpace)
    {
        try
        {
            var sqlConnection = new SqlConnection(this._configuration.GetConnectionString("msSqlConnectionString"));
            var attachedOption = await this._optionService.AttachOptionToSpace(sqlConnection,
                attachOptionToSpace.IdSpace, attachOptionToSpace.IdOption);
            return this.Ok(attachedOption);
        }
        catch (Exception e)
        {
            return this.Problem(e.Message);
        }
    }
}