﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Advanced.Net.Data;
using ProjectModels;

namespace Project.Advanced.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentHistoryController : ControllerBase
    {
        private readonly IAppointmentHistoryRepository _historyRepository;

        public AppointmentHistoryController(IAppointmentHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        // Hämta alla historikposter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentHistory>>> Get()
        {
            var history = await _historyRepository.GetAllAsync();
            return Ok(history);
        }

        // Hämta historikposter för en specifik bokning
        [HttpGet("{appointmentId}")]
        public async Task<ActionResult<IEnumerable<AppointmentHistory>>> GetByAppointmentId(int appointmentId)
        {
            var history = await _historyRepository.GetByAppointmentIdAsync(appointmentId);
            return Ok(history);
        }
    }
}

