using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListReport1._3.Data;
using ListReport1._3.Models;

namespace ListReport1._3.Controllers
{
    public class ShippingDetailsController : Controller
    {
        private readonly ShippingDetailsContext _context;

        public ShippingDetailsController(ShippingDetailsContext context)
        {
            _context = context;
        }
        private bool ShippingDetailsExists(int id)
        {
            return (_context.ShippingDetails?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        // GET: ShippingDetails
        public async Task<IActionResult> Table()
        {
            if (_context.ShippingDetails == null)
                return Problem("Entity set 'ShippingDetailsContext.ShippingDetails' is null.");

            // Only return rows that are not deleted (Flag != 1)
            var shippingDetails = await _context.ShippingDetails
                .Where(x => x.Flag != 1) // skip rows with Flag = 1 (soft deleted)
                .ToListAsync();

            return View("Shipment Details/Table", shippingDetails);
        }
        //Payables
        public async Task<IActionResult> Payables()
        {
            if (_context.ShippingDetails == null)
                return Problem("Entity set 'ShippingDetailsContext.ShippingDetails' is null.");

            // SAME logic as Table
            var shippingDetails = await _context.ShippingDetails
                .Where(x => x.Flag != 1)
                .ToListAsync();

            return View("~/Views/ShippingDetails/Payables/Payables.cshtml", shippingDetails);
        }
        // GET: ShippingDetails
        public async Task<IActionResult> Billing()
        {
            if (_context.ShippingDetails == null)
                return Problem("Entity set 'ShippingDetailsContext.ShippingDetails' is null.");

            // Only return rows that are not deleted (Flag != 1)
            var shippingDetails = await _context.ShippingDetails
                .Where(x => x.Flag != 1) // skip rows with Flag = 1 (soft deleted)
                .ToListAsync();

            return View("~/Views/ShippingDetails/Billing Statement/Billing.cshtml", shippingDetails);
        }

        //// GET: ShippingDetails/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.ShippingDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    var shippingDetails = await _context.ShippingDetails
        //        .FirstOrDefaultAsync(m => m.ID == id);

        //    if (shippingDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(shippingDetails);
        //}
        /*PRINT shipment details*/
        [HttpPost]
        public IActionResult Print([FromBody] List<ShippingDetails> visibleData)
        {
            if (visibleData == null || !visibleData.Any())
            {
                return BadRequest("No data to print.");
            }

            return View("Shipment Details/Print", visibleData);
        }
        /*PRINT payables*/
        [HttpPost]
        public IActionResult PrintPayables([FromBody] List<ShippingDetails> visibleData)
        {
            if (visibleData == null || !visibleData.Any())
            {
                return BadRequest("No data to print.");
            }

            return View("Payables/PrintPayables", visibleData);
        }
        /*PRINT Billing*/
        [HttpPost]
        public IActionResult PrintBilling([FromBody] List<ShippingDetails> visibleData)
        {
            if (visibleData == null || !visibleData.Any())
            {
                return BadRequest("No data to print.");
            }

            return View("Billing Statement/PrintBilling", visibleData);
        }

        // GET: ShippingDetails/Create
        public async Task<IActionResult> Create()
        {
            var trades = await _context.Trades.ToListAsync(); // ✅ now allowed
            ViewBag.Trades = trades;
            return PartialView("Shipment Details/Create");
        }

        // POST: ShippingDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShippingDetails model)
        {
            if (ModelState.IsValid)
            {
                // ✔ set default flag
                model.Flag = 0;

                // ✔ save
                _context.Add(model);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }

            return PartialView("Shipment Details/Create", model);
        }
        // GET: ShippingDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var trades = await _context.Trades.ToListAsync(); // ✅ now allowed
            ViewBag.Trades = trades;
            if (id == null || _context.ShippingDetails == null)
            {
                return NotFound();
            }

            var shippingDetails = await _context.ShippingDetails.FindAsync(id);
            if (shippingDetails == null)
            {
                return NotFound();
            }
            return PartialView("Shipment Details/Edit", shippingDetails);
        }

        // POST: ShippingDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
    int id,
    [Bind("ID,JobNo,Trade,HblNo,MblNo,Ata,PolPod,Shipper,Vessel,Commodity,Teus,Volume,Measurement")]
    ShippingDetails model)
        {
            if (id != model.ID)
                return NotFound();

            var existing = await _context.ShippingDetails.FindAsync(id);
            if (existing == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // ✅ ONLY UPDATE SHIPMENT FIELDS
                    existing.JobNo = model.JobNo;
                    existing.Trade = model.Trade;
                    existing.HblNo = model.HblNo;
                    existing.MblNo = model.MblNo;
                    existing.Ata = model.Ata;
                    existing.PolPod = model.PolPod;
                    existing.Shipper = model.Shipper;
                    existing.Vessel = model.Vessel;
                    existing.Commodity = model.Commodity;
                    existing.Teus = model.Teus;
                    existing.Volume = model.Volume;
                    existing.Measurement = model.Measurement;

                    // keep flag safe
                    existing.Flag = existing.Flag ?? 0;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingDetailsExists(model.ID))
                        return NotFound();
                    else
                        throw;
                }

                return Json(new { success = true });
            }

            return PartialView("Shipment Details/Edit", model);
        }

        // GET: ShippingDetails/Delete/5
        [HttpPost]
        public async Task<JsonResult> DeleteFlag(int id)
        {
            if (_context.ShippingDetails == null)
                return Json(new { success = false });

            var shippingDetails = await _context.ShippingDetails.FindAsync(id);
            if (shippingDetails != null)
            {
                shippingDetails.Flag = 1; // mark as deleted
                _context.Update(shippingDetails);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        //GET: CreatePayables
        public async Task<IActionResult> CreatePayable()
        {
            // List of Trades
            var trades = await _context.Trades.ToListAsync();
            ViewBag.Trades = trades;

            // List of JobNo from ShippingDetails
            var jobnos = await _context.ShippingDetails
                                       .Where(x => x.Flag != 1) // optional filter
                                       .Select(x => new { x.JobNo })
                                       .Distinct()
                                       .ToListAsync();
            ViewBag.JobNo = jobnos;

            return PartialView("Payables/CreatePayable"); // Partial view only
        }

        //Post: Create Payables
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePayable(ShippingDetails model)
        {
            if (!ModelState.IsValid)
                return PartialView("CreatePayable", model);

            _context.ShippingDetails.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        // GET: Payables/EditPayable/5
        public async Task<IActionResult> EditPayable(int? id)
        {
            var trades = await _context.Trades.ToListAsync(); // ✅ now allowed
            ViewBag.Trades = trades;
            if (id == null || _context.ShippingDetails == null)
            {
                return NotFound();
            }

            var shippingDetails = await _context.ShippingDetails.FindAsync(id);
            if (shippingDetails == null)
            {
                return NotFound();
            }
            return PartialView("Payables/EditPayable", shippingDetails);
        }

        //Post: Payable Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPayable(int id, ShippingDetails model)
        {
            if (id != model.ID) return NotFound();

            var existing = await _context.ShippingDetails.FindAsync(id);
            if (existing == null) return NotFound();

            if (ModelState.IsValid)
            {
                existing.AgentName = model.AgentName;
                existing.AgentInvoiceNo = model.AgentInvoiceNo;
                existing.AgentAmount = model.AgentAmount;
                existing.AgentDateIssued = model.AgentDateIssued;
                existing.AgentDatePaid = model.AgentDatePaid;
                existing.SlPayable = model.SlPayable;
                existing.SlInvoiceNo = model.SlInvoiceNo;
                existing.SlAmount = model.SlAmount;
                existing.SlDateIssued = model.SlDateIssued;
                existing.SlDatePaid = model.SlDatePaid;

                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }

            return PartialView("Payables/EditPayable", model);
        }

        // GET: Payables/EditBilling/5
        public async Task<IActionResult> EditBilling(int? id)
        {
            var trades = await _context.Trades.ToListAsync(); // ✅ now allowed
            ViewBag.Trades = trades;
            if (id == null || _context.ShippingDetails == null)
            {
                return NotFound();
            }

            var shippingDetails = await _context.ShippingDetails.FindAsync(id);
            if (shippingDetails == null)
            {
                return NotFound();
            }
            return PartialView("Billing Statement/EditBilling", shippingDetails);
        }

        //Post: Billing Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBilling(int id, ShippingDetails model)
        {
            if (id != model.ID) return NotFound();

            var existing = await _context.ShippingDetails.FindAsync(id);
            if (existing == null) return NotFound();

            if (ModelState.IsValid)
            {
                // ✅ ONLY UPDATE BILLING FIELDS
                existing.SlNum = model.SlNum;
                existing.SlNumAmount = model.SlNumAmount;
                existing.Ewt = model.Ewt;
                existing.EwtTotal = model.EwtTotal;
                existing.DmPhp = model.DmPhp;
                existing.DmPhpAmount = model.DmPhpAmount;
                existing.DmUsd = model.DmUsd;
                existing.DmUsdAmount = model.DmUsdAmount;
                existing.Revenue = model.Revenue;
                existing.ProfitFrom = model.ProfitFrom;
                existing.ProfitAmount = model.ProfitAmount;

                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }

            return PartialView("Billing Statement/EditBilling", model);
        }

    }
}
