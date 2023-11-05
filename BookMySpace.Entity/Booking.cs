// <copyright file="Booking.cs" company="Équipe 4 - BENEY, GUDEFIN, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, GUDEFIN, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

namespace BookMySpace.Entity;

/// <summary>
/// This class represents a booking.
/// </summary>
public class Booking
{
    /// <summary>
    /// Gets or sets the booking's id.
    /// </summary>
    public int IdBooking { get; set; }

    /// <summary>
    /// Gets or sets the booking's start date.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the booking's end date.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the booking's space.
    /// </summary>
    public Space Space { get; set; }

    /// <summary>
    /// Gets or sets the booking's user.
    /// </summary>
    public User CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the booking's creation date.
    /// </summary>
    public DateTime Created { get; set; }
}