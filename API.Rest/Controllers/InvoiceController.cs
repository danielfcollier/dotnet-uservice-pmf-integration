using System.Xml;
using Microsoft.AspNetCore.Mvc;

using Jobs;
using Models;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult> GetInvoice(string id)
    {
        try
        {
            {
                string partnerId = "#0001";

                // TODO: 1) Authentication (JWT)

                // 2) Get Partner Data
                Partner? partner = await DBHandler.GetPartnerData(partnerId);
                if (partner is null)
                {
                    return NotFound();
                }

                // 3) Start Jobs
                Producer producer = new(partner);
                Consumer consumer = new(partner);

                // 4) Produce Payload
                List<(XmlDocument, string)> payloads = await producer.GetPayloadsToProcess();

                // 5) Process Payload
                foreach (var item in payloads)
                {
                    (XmlDocument payload, string payloadId) = item;

                    var (response, statusCode) = await consumer.Run(payloadId, payload);

                    // 6) Save Response
                    // if (statusCode is not HttpStatusCode.OK)
                    // {

                    // }

                    // XmlDocument xmlResponse = new() { PreserveWhitespace = true };
                    // xmlResponse.Load(response);
                    // InvoiceResponse result = XmlHandler.DeserializeResponse<InvoiceResponse>(xmlResponse);
                }
            }

            return Ok();
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult> GetInvoice([FromQuery(Name = "year")] string? year, [FromQuery(Name = "month")] string? month)
    {
        try
        {
            {
                string partnerId = "#0001";

                // TODO: 1) Authentication (JWT)

                // 2) Get Partner Data
                Partner? partner = await DBHandler.GetPartnerData(partnerId);
                if (partner is null)
                {
                    return NotFound();
                }

                // 3) Start Jobs
                Producer producer = new(partner);
                Consumer consumer = new(partner);

                // 4) Produce Payload
                List<(XmlDocument, string)> payloads = await producer.GetPayloadsToProcess();

                // 5) Process Payload
                foreach (var item in payloads)
                {
                    (XmlDocument payload, string id) = item;

                    var (response, statusCode) = await consumer.Validate(id, payload);

                    // 6) Save Response
                    // if (statusCode is not HttpStatusCode.OK)
                    // {

                    // }

                    // XmlDocument xmlResponse = new() { PreserveWhitespace = true };
                    // xmlResponse.Load(response);
                    // InvoiceResponse result = XmlHandler.DeserializeResponse<InvoiceResponse>(xmlResponse);
                }
            }

            return Ok();
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpPost("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult> PostInvoice(string id, [FromBody] Customer customer)
    {
        try
        {
            {
                string partnerId = "#0001";

                // TODO: 1) Authentication (JWT)

                // 2) Get Partner Data
                Partner? partner = await DBHandler.GetPartnerData(partnerId);
                if (partner is null)
                {
                    return NotFound();
                }

                // 3) Start Jobs
                Producer producer = new(partner);
                Consumer consumer = new(partner);

                // 4) Produce Payload
                List<(XmlDocument, string)> payloads = await producer.GetPayloadsToProcess();

                // 5) Process Payload
                foreach (var item in payloads)
                {
                    (XmlDocument payload, string payloadId) = item;

                    var (response, statusCode) = await consumer.Validate(payloadId, payload);

                    // 6) Save Response
                    // if (statusCode is not HttpStatusCode.OK)
                    // {

                    // }

                    // XmlDocument xmlResponse = new() { PreserveWhitespace = true };
                    // xmlResponse.Load(response);
                    // InvoiceResponse result = XmlHandler.DeserializeResponse<InvoiceResponse>(xmlResponse);
                }
            }

            return Ok();
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    /// <summary>
    /// Deletes a specific TodoItem.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteInvoice(string id)
    {
        try
        {
            {
                string partnerId = "#0001";

                // TODO: 1) Authentication (JWT)

                // 2) Get Partner Data
                Partner? partner = await DBHandler.GetPartnerData(partnerId);
                if (partner is null)
                {
                    return NotFound();
                }

                // 3) Start Jobs
                Producer producer = new(partner);
                Consumer consumer = new(partner);

                // 4) Produce Payload
                List<(XmlDocument, string)> payloads = await producer.GetPayloadsToProcess();

                // 5) Process Payload
                foreach (var item in payloads)
                {
                    (XmlDocument payload, _) = item;

                    var (response, statusCode) = await consumer.Validate(id, payload);

                    // 6) Save Response
                    // if (statusCode is not HttpStatusCode.OK)
                    // {

                    // }

                    // XmlDocument xmlResponse = new() { PreserveWhitespace = true };
                    // xmlResponse.Load(response);
                    // InvoiceResponse result = XmlHandler.DeserializeResponse<InvoiceResponse>(xmlResponse);
                }
            }

            return Ok();
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
