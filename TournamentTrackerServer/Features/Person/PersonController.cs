﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TournamentTracker.Features.Person.Models;
using TournamentTracker.Features.Person.Services;
using TournamentTracker.Features.Team.Services;

namespace TournamentTracker.Features.Person
{
    [Route("api/teams/{teamId}/persons")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository personRepository, ITeamRepository teamRepository, IMapper mapper)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet(Name = nameof(GetPersonsForTeam))]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetPersonsForTeam(int teamId)
        {
            if (!await _teamRepository.TeamExistsAsync(teamId))
            {
                return NotFound();
            }

            var persons = await _personRepository.GetPersonsAsync(teamId);

            var personsDTO = _mapper.Map<IEnumerable<PersonDTO>>(persons);

            return Ok(personsDTO);
        }


        [HttpGet("{personId}", Name = nameof(GetSinglePerson))]
        public async Task<ActionResult<PersonModel>> GetSinglePerson(int teamId, int personId)
        {
            if (!await _teamRepository.TeamExistsAsync(teamId))
            {
                return NotFound();
            }
            var person = await _personRepository.GetSinglePersonAsync(teamId, personId);

            if (person == null)
            {
                return NotFound();
            }

            var personDTO = _mapper.Map<PersonDTO>(person);

            return Ok(personDTO);
        }


        [HttpPost(Name = nameof(CreatePersonForTeam))]
        public async Task<ActionResult<PersonModel>> CreatePersonForTeam(int teamId, PersonAddDTO personDTO)
        {
            if (!await _teamRepository.TeamExistsAsync(teamId))
            {
                return NotFound();
            }
            var person = _mapper.Map<PersonModel>(personDTO);
            await _personRepository.AddPerson(teamId, person);

            var personDTOForReturn = _mapper.Map<PersonDTO>(person);

            return CreatedAtAction(nameof(GetSinglePerson), new { teamId, personId = personDTOForReturn.Id }, personDTOForReturn);
        }


        [HttpPut("{personId}")]
        public async Task<ActionResult<PersonDTO>> UpdatePersonForTeam(int teamId, int personId, PersonUpdateDTO personDTO)
        {
            if (!await _teamRepository.TeamExistsAsync(teamId))
            {
                return NotFound();
            }

            var person = await _personRepository.GetSinglePersonAsync(teamId, personId);

            if (person == null)
            {
                var personToAdd = _mapper.Map<PersonModel>(personDTO);
                personToAdd.Id = personId;
                await _personRepository.AddPerson(teamId, personToAdd);

                var personDTOForReturn = _mapper.Map<PersonDTO>(personToAdd);

                return CreatedAtRoute(nameof(GetSinglePerson), new
                {
                    teamId,
                    personId = personDTOForReturn.Id
                }, personDTOForReturn);
            }

            _mapper.Map(personDTO, person);

            await _personRepository.UpdatePerson(person);

            return NoContent();
        }


        [HttpDelete("{personId}")]
        public async Task<IActionResult> DeletePersonFromTeam(int teamId, int personId)
        {
            if (!await _teamRepository.TeamExistsAsync(teamId))
            {
                return NotFound();
            }

            var person = await _personRepository.GetSinglePersonAsync(teamId, personId);

            if (person == null)
            {
                return NotFound();
            }

            await _personRepository.DeletePerson(person);

            return NoContent();
        }
    }
}
