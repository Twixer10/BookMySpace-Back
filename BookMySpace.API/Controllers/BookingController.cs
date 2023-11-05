// <copyright file="BookingController.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using BookMySpace.Services.Contracts;
using Microsoft.Data.SqlClient;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    private IBookingService _bookingService;
    private IConfiguration _configuration;
    public BookingController(IBookingService bookingService, IConfiguration configuration)
    {
        this._bookingService = bookingService;
        this._configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> GetBookingByUserId(int userId)
    {
        var sqlConnection = new SqlConnection(this._configuration.GetConnectionString("msSqlConnectionString"));
        var bookingByUserId = await this._bookingService.GetBookingByUserId(sqlConnection, userId);
        return this.Ok(bookingByUserId);
    }
}
