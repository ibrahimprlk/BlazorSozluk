using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BlozorSozluk.Common.ViewModels.Queries
{
    public class SearchEntryQuery : IRequest<List<SearchEntryViewModel>>
    {
        public SearchEntryQuery()
        {

        }
        public SearchEntryQuery(string searchText)
        {
            SearchText = searchText;
        }

        public string SearchText { get; set; }
    }
}
