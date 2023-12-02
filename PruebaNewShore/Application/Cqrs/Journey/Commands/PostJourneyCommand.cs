using Application.Common.Response;
using Application.DTOs.Journey;
using Application.Interfaces.Journey;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Journey.Commands
{
    public class PostJourneyCommand : IRequest<ApiResponse<JourneyDto>>
    {
        public JourneyDto JourneyDto { get; set; }
    }
    public class PostJourneyCommandHandler : IRequestHandler<PostJourneyCommand, ApiResponse<JourneyDto>>
    {
        private readonly IJourneyService _journeyService;
        public PostJourneyCommandHandler(IJourneyService JourneyService)
        {
            _journeyService = JourneyService;
        }

        public async Task<ApiResponse<JourneyDto>> Handle(PostJourneyCommand request, CancellationToken cancellationToken)
        {
            return await _journeyService.AddJourney(request);
        }
    }
}
