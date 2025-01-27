﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Domain.Models
{
    public class EntryFavorite : BaseEntity
    {

        public Guid EntryId { get; set; }
        public Guid CreateById { get; set; }

        public virtual Entry Entry { get; set; }
        public virtual User CreatedUser { get; set; }

    }
}
