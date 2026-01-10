using BlozorSozluk.Common.ViewModels.Queries;
using MediatR;

namespace BlozorSozluk.Api.Application.Features.Queries.GetEntries
{
    public class GetEntriesQuery : IRequest<List<GetEntriesViewModel>>
    {
        public bool TodayEntries { get; set; } // Bugune ait kayitlari dondurmek icin
        public int Count { get; set; } = 100; // Varsayilan olarak 100 kayit listelenecek
    }
}
