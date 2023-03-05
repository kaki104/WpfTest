using System;

namespace PrismStep7.Models
{
    public interface IAppContext
    {
        DateTime Connection { get; set; }
        Guid ConnectionId { get; set; }
        string Id { get; set; }
        string Name { get; set; }
    }
}