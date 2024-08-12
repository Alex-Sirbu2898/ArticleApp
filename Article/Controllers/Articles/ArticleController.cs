using ArticleApp.Business.Articles.Commands.Create;
using ArticleApp.Business.Articles.Commands.Delete;
using ArticleApp.Business.Articles.Commands.Update;
using ArticleApp.Business.Articles.Queries.GetAll;
using ArticleApp.Business.Articles.Queries.GetById;
using ArticleApp.Business.Articles.Queries.Paginate;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ArticleApp.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticleController : ControllerBase
    {

        private readonly ILogger<ArticleController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ArticleController(IMediator mediator, IMapper mapper, ILogger<ArticleController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CreateArticleRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateArticleCommand>(request);

            var result = await _mediator.Send(command,cancellationToken);

            return Ok(result);
        }

        [HttpPut()]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UpdateArticleRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateArticleCommand>(request);

            var result = await _mediator.Send(command,cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            var query = new GetArticleByIdQuery(id);

            var result = await _mediator.Send(query,cancellationToken);

            return result is null ? (IActionResult)NotFound() : Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllQuery();

            var result = await _mediator.Send(query, cancellationToken);

            return result is null ? (IActionResult)NotFound() : Ok(result);
        }
        [HttpGet("paginate")]
        public async Task<IActionResult> GetPaginated([FromBody] PagedArticleRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<PagedArticleQuery>(request);

            var result = await _mediator.Send(query, cancellationToken);

            return result is null ? (IActionResult)NotFound() : Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            if(id <= 0)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var command = _mapper.Map<DeleteArticleCommand>(id);

            var result = await _mediator.Send(command, cancellationToken);

            return result is null ? (IActionResult)NotFound() : Ok(result);
        }
    }
}