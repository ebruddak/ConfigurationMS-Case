
using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Setting : Entity
    {
        public string ConnectionString { get; set; }
        public string MaxItemCount { get; set; }
    }
}