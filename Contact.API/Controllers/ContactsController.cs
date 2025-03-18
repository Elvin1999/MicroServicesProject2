using AutoMapper;
using Contact.API.Dtos;
using Contact.API.Infrasturucture;
using Contact.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContactDto>> Get()
        {
            var items=_contactService.GetAll();
            var dtos=_mapper.Map<IEnumerable<ContactDto>>(items);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ContactDto> Get(int id)
        {
            var item = _contactService.GetContactById(id);
            var dto=_mapper.Map<ContactDto>(item);
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<ContactDto> Post([FromBody] ContactDto dto)
        {
            var model = _mapper.Map<ContactModel>(dto);
            var result = _contactService.Add(model);
            var dtoToReturn = _mapper.Map<ContactDto>(result);
            return Ok(dtoToReturn);
        }

        [HttpPut("{id}")]
        public ActionResult<ContactDto> Put(int id, [FromBody] ContactDto dto)
        {
            var obj = _mapper.Map<ContactModel>(dto);
            var result = _contactService.Update(id,obj);
            if (result == null) return NotFound();
            var dtoToReturn=_mapper.Map<ContactDto>(result);
            return Ok(dtoToReturn);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hasDeleted = _contactService.Delete(id);
            if (hasDeleted) return NoContent();
            return NotFound();
        }

    }
}
