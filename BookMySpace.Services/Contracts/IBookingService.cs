// <copyright file="IBookingService.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity;
using BookMySpace.Entity.DTO;
using Microsoft.Data.SqlClient;

namespace BookMySpace.Services.Contracts;

/// <summary>
/// Interface for the BookingService.
/// </summary>
public interface IBookingService
{
    public Task<List<BookingByUserId>> GetBookingByUserId(SqlConnection sqlConnection, int userId);
}