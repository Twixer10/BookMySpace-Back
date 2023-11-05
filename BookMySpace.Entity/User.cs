// <copyright file="User.cs" company="Équipe 4 - BENEY, GUDEFIN, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, GUDEFIN, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

namespace BookMySpace.Entity;

/// <summary>
/// This class represents a user.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets the user's id.
    /// </summary>
    public int IdUser { get; set; }

    /// <summary>
    /// Gets or sets the user's first name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Get or sets the user's last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the user's email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the user's password hash.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the user's role.
    /// </summary>
    public Role Role { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is external.
    /// </summary>
    public bool IsExternal { get; set; }
}