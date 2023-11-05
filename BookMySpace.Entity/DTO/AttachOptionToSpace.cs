// <copyright file="AttachOptionToSpace.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

namespace BookMySpace.Entity.DTO;

/// <summary>
/// DTO for the attach option to space.
/// </summary>
public class AttachOptionToSpace
{
    /// <summary>
    /// Gets or sets the id of the space.
    /// </summary>
    public int IdSpace { get; set; }

    /// <summary>
    /// Gets or sets the id of the option.
    /// </summary>
    public int IdOption { get; set; }
}