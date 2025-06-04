using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace Excel;

internal class Program
{
    public static void Main(string[] args)
    {
        List<Person> persons =
        [
            new Person("Oleg", "Olegov", 45, "+79998887766"),
            new Person("Ivan", "Ivanov", 23, "-67778889900"),
            new Person("Petr", "Ogurtsov", 25, "+53330002277"),
            new Person("Vladislav", "Ignatiev", 25, "+12223334455")
        ];

        ExcelPackage.License.SetNonCommercialOrganization("Non commercial organization");

        using var package = new ExcelPackage();
        var ws = package.Workbook.Worksheets.Add("Persons");

        ws.Cells.LoadFromCollection(persons, PrintHeaders: true);
        ws.Cells.AutoFitColumns();

        var header = ws.Cells["A1:D1"];
        header.Style.Font.Bold = true;
        header.Style.Fill.PatternType = ExcelFillStyle.Solid;
        header.Style.Fill.BackgroundColor.SetColor(Color.LightSteelBlue);

        foreach (var columnAddress in ws.Cells)
        {
            columnAddress.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            columnAddress.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            columnAddress.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            columnAddress.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }

        package.SaveAs(new FileInfo("Persons.xlsx"));
    }
}

