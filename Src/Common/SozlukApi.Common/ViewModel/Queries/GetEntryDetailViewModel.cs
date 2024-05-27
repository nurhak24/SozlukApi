using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Common.ViewModel.Queries
{
    public class GetEntryDetailViewModel : BaseFooterRateFavoritedViewModel
    {

        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
