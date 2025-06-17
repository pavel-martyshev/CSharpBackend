using ClosedXML.Excel;

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

        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Persons");

        ws.Cell("A1").InsertTable(persons, tableName: "Persons");

        var header = ws.Range("A1:D1");
        header.Style.Font.Bold = true;
        header.Style.Fill.PatternType = XLFillPatternValues.Solid;
        header.Style.Fill.SetBackgroundColor(XLColor.BlueGray);

        foreach (var columnAddress in ws.Cells())
        {
            columnAddress.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            columnAddress.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        }

        ws.Columns().AdjustToContents();

        wb.SaveAs("Persons.xlsx");
    }
}