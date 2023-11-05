namespace BookMySpace.Entity.DTO;

public class CreateSpace
{
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
    public int IdTypeSpace { get; set; }

    /// <summary>
    /// Gets or sets the space's address.
    /// </summary>
    public List<int>? Options { get; set; }

    /// <summary>
    /// Gets or sets the space's address.
    /// </summary>
    public string Url { get; set; }
}