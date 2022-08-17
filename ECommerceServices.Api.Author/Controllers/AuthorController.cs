using ECommerceServices.Api.Author.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceServices.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<Model.Author>>> GetAuthors()
        {
            return await _mediator.Send(new Query.AuthorList());
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<Model.Author>> GetAuthor(string guid)
        {
            return await _mediator.Send(new QueryFilter.AuthorUnic { AuthorGuid = guid });
        }

        [HttpPost("saveFluent")]
        public async Task<ActionResult<Unit>> CreateFluent(NewFluent.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet("getMapperAuthors")]
        public async Task<ActionResult<List<AuthorDto>>> GetMapperAuthors()
        {
            return await _mediator.Send(new QueryMapper.AuthorList());
        }

        [HttpGet("getMapperAuthor/{guid}")]
        public async Task<ActionResult<AuthorDto>> GetMapperAuthor(string guid)
        {
            return await _mediator.Send(new QueryFilterMapper.AuthorUnic { AuthorGuid = guid });
        }
    }
}
