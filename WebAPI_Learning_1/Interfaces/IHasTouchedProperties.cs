using System;

namespace WebAPI_Learning_1.Interfaces
{
    public interface IHasTouchedProperties
    {
        DateTime? CreatedAt { get; }
        DateTime? ModifiedAt { get; set; }
    }
}