using NPOI.SS.UserModel;

namespace WeatherArchive.BL.Helpers;

public static class Helper
{
    public static string ParseCellToString(this ICell cell)
    {
        if (cell.CellType == CellType.String)
            return cell.StringCellValue;

        return string.Empty;
    }

    public static DateTime? ParseCellToDateTime(this ICell cell)
    {
        if (DateTime.TryParse(cell.StringCellValue, out var date))
            return date;
        return null;
    }

    public static double? ParseCellToDouble(this ICell cell)
    {
        if (cell.CellType == CellType.Numeric)
            return cell.NumericCellValue;

        if (cell.CellType == CellType.String && double.TryParse(cell.StringCellValue, out var number))
            return number;

        return null;
    }

    public static int? ParseCellToInt(this ICell cell)
    {
        if (cell.CellType == CellType.Numeric)
            return (int)cell.NumericCellValue;

        if (cell.CellType == CellType.String && int.TryParse(cell.StringCellValue, out var number))
            return number;

        return null;
    }

    public static TimeSpan? ParseCellToTimeSpan(this ICell cell)
    {
        if (cell.CellType == CellType.String && TimeSpan.TryParse(cell.StringCellValue, out var time))
            return time;

        return null;
    }
}