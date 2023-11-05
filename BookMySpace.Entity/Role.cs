// <copyright file="Role.cs" company="Équipe 4 - BENEY, GUDEFIN, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, GUDEFIN, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

namespace BookMySpace.Entity;

/// <summary>
/// This class represents a role.
/// </summary>
public class Role
{
    /// <summary>
    /// Gets or sets the role's id.
    /// </summary>
    public int IdRole { get; set; }

    /// <summary>
    /// Gets or sets the role's name.
    /// </summary>
    public string Name { get; set; }
}