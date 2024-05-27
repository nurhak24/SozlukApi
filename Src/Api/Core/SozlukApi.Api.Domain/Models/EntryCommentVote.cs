using SozlukApi.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Domain.Models
{
    public class EntryCommentVote : BaseEntity
    {

        public Guid EntryCommentId { get; set; }
        public VoteType VoteType { get; set; }

        public Guid CreateById { get; set; }
        public virtual EntryComment EntryComment { get; set; }


    }
}
