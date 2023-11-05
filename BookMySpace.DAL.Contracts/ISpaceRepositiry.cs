// <copyright file="ISpaceRepositiry.cs" company="Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE">
// Copyright (c) Équipe 4 - BENEY, DESRAYAUD, TANQUEREL, TECHER, TANIERE. All rights reserved.
// </copyright>

using BookMySpace.Entity;

namespace BookMySpace.DAL.Contracts;

/// <summary>
/// Interface for the SpaceRepository.
/// </summary>
public interface ISpaceRepositiry
{
    /// <summary>
    /// Create a space.
    /// </summary>
    /// <param name="space"></param>
    /// <returns></returns>
    public Task<Space> CreateSpace(Space space);
}