// <copyright file="Space.cs" company="Équipe 4 - BENEY, GUDEFIN, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, GUDEFIN, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMySpace.Entity;

/// <summary>
/// This class represents a space.
/// </summary>
public class Space
{
    /// <summary>
    /// Gets or sets the space's id.
    /// </summary>
    public int IdSpace { get; set; }

    /// <summary>
    /// Gets or sets the space's name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the space's description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the space's address.
    /// </summary>
    public int MaxCapacity { get; set; }

    /// <summary>
    /// Gets or sets the space's address.
    /// </summary>
    public TypeSpace TypeSpace { get; set; }

    /// <summary>
    /// Gets or sets the space's address.
    /// </summary>
    public List<Option> Options { get; set; }

    /// <summary>
    /// Gets or sets the space's address.
    /// </summary>
    public string Url { get; set; }
}