using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Common.ViewModel.Queries
{
    public class SearchEntryQuery : IRequest<List<SearchEntryViewModel>>
    {

        public string SearchText { get; set; }
        public SearchEntryQuery(string searchText) 
        {
        
            SearchText = searchText;
        }


    }
}
