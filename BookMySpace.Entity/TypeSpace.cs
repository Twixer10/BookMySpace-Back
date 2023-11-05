// <copyright file="TypeSpace.cs" company="Équipe 4 - BENEY, GUDEFIN, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, GUDEFIN, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

namespace BookMySpace.Entity;

/// <summary>
/// This class represents a type of space.
/// </summary>
public class TypeSpace
{
    /// <summary>
    /// Gets or sets the type of space's id.
    /// </summary>
    public int IdTypeSpace { get; set; }

    /// <summary>
    /// Gets or sets the type of space's name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of space's description.
    /// </summary>
    public List<Option> Options { get; set; }
}