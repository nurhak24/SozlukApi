﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Common.ViewModel.Page
{
    public class PagedViewModel<T> where T: class
    {


        public PagedViewModel(): this(new List<T>(),new Page())
        {

        }

        public PagedViewModel(IList<T> results ,Page pageInfo)
        {
            Results = results;
            PageInfo = pageInfo;


        }

        public IList<T> Results { get; set; }
        public Page PageInfo { get; set; }


    }
}
