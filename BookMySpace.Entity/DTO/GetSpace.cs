using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMySpace.Entity.DTO;

public class GetSpace
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
    public string Url { get; set; }
}  


