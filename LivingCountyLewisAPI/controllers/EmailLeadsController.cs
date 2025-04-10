using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LivingCountyLewisAPI.Data;
using LivingCountyLewisAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LivingCountyLewisAPI.Controllers
{
    [Route("api/emailleads")]
    [ApiController]
    public class EmailLeadsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EmailLeadsController> _logger;

        public EmailLeadsController(AppDbContext context, ILogger<EmailLeadsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // ✅ POST: api/emailleads
        [HttpPost]
        public async Task<IActionResult> PostEmailLead([FromBody] EmailLead emailLead)
        {
            if (emailLead == null)
            {
                _logger.LogWarning("Received null EmailLead.");
                return BadRequest("Invalid data.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("❌ Model state invalid for email lead: {@EmailLead}", emailLead);
                return BadRequest(ModelState);
            }

            try
            {
                emailLead.SubmittedAt = DateTime.UtcNow;
                _context.EmailLeads.Add(emailLead);
                await _context.SaveChangesAsync();

                _logger.LogInformation("✅ Email lead saved: {Email}", emailLead.Email);
                return Ok(new { message = "Email saved successfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "🚨 Error saving email lead.");
                return StatusCode(500, "An error occurred while saving your information.");
            }
        }

        // ✅ GET: api/emailleads
        [HttpGet]
        public IActionResult GetAllLeads()
        {
            try
            {
                var leads = _context.EmailLeads
                    .OrderByDescending(l => l.SubmittedAt)
                    .ToList();

                _logger.LogInformation("📋 Returning {Count} email leads.", leads.Count);
                return Ok(leads);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "🚨 Failed to fetch email leads.");
                return StatusCode(500, "Error retrieving email leads.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailLead(int id)
        {
            var allIds = _context.EmailLeads.Select(e => e.Id).ToList();
            _logger.LogInformation("🧠 All EmailLead IDs in DB: {Ids}", string.Join(", ", allIds));

            var lead = await _context.EmailLeads.FindAsync(id);
            if (lead == null)
            {
                _logger.LogWarning("❌ Lead with ID {Id} not found.", id);
                return NotFound();
            }

            try
            {
                _context.EmailLeads.Remove(lead);
                await _context.SaveChangesAsync();

                _logger.LogInformation("🗑️ Deleted email lead with ID: {Id}", id);
                return Ok(new { message = "Lead deleted successfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "🚨 Error deleting email lead with ID: {Id}", id);
                return StatusCode(500, "Error deleting lead.");
            }
        }
    }
}