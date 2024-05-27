using SozlukApi.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Domain.Models
{
    public class EntryVote : BaseEntity
    {

        public Guid EntryId { get; set; }
        public VoteType VoteType {  get; set; }

        public Guid CreateById { get; set; }
        public virtual Entry Entry { get; set; }

      

    }
}
