using Microsoft.AspNetCore.Mvc;
using BudgetPlanner.Models;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace BudgetPlanner.Controllers
{
    public class BudgetController : Controller
    {
        static List<Transaction> transactions = new();
        static int nextId = 1;

        public IActionResult Index()
        {
            return View(transactions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Transaction t)
        {
            if (t.Type == "Expense" && t.Amount > 0)
                t.Amount *= -1;

            t.Id = nextId++;
            transactions.Add(t);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var transaction = transactions.FirstOrDefault(x => x.Id == id);
            if (transaction != null)
            {
                transactions.Remove(transaction);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var transaction = transactions.FirstOrDefault(x => x.Id == id);
            if (transaction == null)
                return NotFound();

            return View(transaction);
        }

        [HttpPost]
        public IActionResult Edit(Transaction updated)
        {
            var transaction = transactions.FirstOrDefault(x => x.Id == updated.Id);
            if (transaction != null)
            {
                transaction.Description = updated.Description;
                transaction.Category = updated.Category;
                transaction.Amount = updated.Amount;
                transaction.Date = updated.Date;
            }

            return RedirectToAction("Index");
        }



public IActionResult ExportToExcel()
{
    var list = transactions;

    using var package = new ExcelPackage();
    var worksheet = package.Workbook.Worksheets.Add("Transactions");

    worksheet.Cells[1, 1].Value = "Date";
    worksheet.Cells[1, 2].Value = "Description";
    worksheet.Cells[1, 3].Value = "Category";
    worksheet.Cells[1, 4].Value = "Type";
    worksheet.Cells[1, 5].Value = "Amount";

    using (var range = worksheet.Cells[1, 1, 1, 5])
    {
        range.Style.Font.Bold = true;
        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
        range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
    }

    for (int i = 0; i < list.Count; i++)
    {
        var t = list[i];
        worksheet.Cells[i + 2, 1].Value = t.Date.ToShortDateString();
        worksheet.Cells[i + 2, 2].Value = t.Description;
        worksheet.Cells[i + 2, 3].Value = t.Category;
        worksheet.Cells[i + 2, 4].Value = t.Type;
        worksheet.Cells[i + 2, 5].Value = t.Amount;
    }

    worksheet.Cells.AutoFitColumns();

    var stream = new MemoryStream();
    package.SaveAs(stream);
    stream.Position = 0;

    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Transactions.xlsx");
}




    }
}
