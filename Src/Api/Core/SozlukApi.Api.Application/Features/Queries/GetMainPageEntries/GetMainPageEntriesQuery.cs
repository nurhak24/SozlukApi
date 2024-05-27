using MediatR;
using SozlukApi.Common.ViewModel.Page;
using SozlukApi.Common.ViewModel.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Queries.GetMainPageEntries
{
    public class GetMainPageEntriesQuery : BasePagedQuery, IRequest<PagedViewModel<GetEntryDetailViewModel>>
    {

        public GetMainPageEntriesQuery(Guid? userId,int page,int pageSize) : base(page, pageSize)
        {

        } 

        public Guid? UserId { get; set; }

    }


}
