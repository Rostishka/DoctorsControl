using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
