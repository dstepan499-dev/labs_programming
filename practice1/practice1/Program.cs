using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FileSystemEntry
{
    public string Name { get; set; }
    public string Type { get; set; }
    public long Size { get; set; }
    public DateTime Modified { get; set; }
    public bool IsDirectory => Type == "<DIR>";

    public string GetShortName()
    {
        string fullName = IsDirectory ? Name : $"{Name}.{Type}";
        if (fullName.Length <= 12)
        {
            return fullName;
        }
        string extension = "";
        string nameWithoutExt = fullName;

        if (!IsDirectory && fullName.Contains('.'))
        {
            extension = fullName.Substring(fullName.LastIndexOf('.'));
            nameWithoutExt = fullName.Substring(0, fullName.LastIndexOf('.'));
        }

        if (nameWithoutExt.Length > 8)
        {
            return $"{nameWithoutExt.Substring(0, 7)}~{extension}";
        }
        return fullName;
    }
}

public class NortonCommanderClone
{

    private const ConsoleColor PanelBackgroundColor = ConsoleColor.Blue;
    private const ConsoleColor PanelTextColor = ConsoleColor.Yellow;
    private const ConsoleColor FrameColor = ConsoleColor.Cyan;
    private const ConsoleColor HighlightColor = ConsoleColor.Black;
    private const ConsoleColor HighlightTextColor = ConsoleColor.White;
    private const ConsoleColor DirectoryColor = ConsoleColor.White;
    private const ConsoleColor BottomBarColor = ConsoleColor.Cyan;
    private const ConsoleColor BottomBarTextColor = ConsoleColor.Black;

    public static void Main(string[] args)
    {

        Console.OutputEncoding = Encoding.UTF8;
        Console.SetWindowSize(80, 25);
        Console.SetBufferSize(80, 25);
        Console.Title = "Norton Commander Clone";
        Console.CursorVisible = false;
        Console.BackgroundColor = PanelBackgroundColor;
        Console.Clear();

        var leftPanelData = GetPanelData();
        var rightPanelData = GetPanelData().OrderByDescending(f => f.Modified).ToList();

        DrawFrame();
        DrawPanels(leftPanelData, rightPanelData);
        DrawBottomBar();

        Console.ReadKey();
    }

    private static void DrawFrame()
    {

        DrawHorizontalLine(0, 0, 79, '─');
        DrawHorizontalLine(0, 23, 79, '─');

        WriteAt(39, 0, '┬', FrameColor);
        WriteAt(39, 23, '┴', FrameColor);

        WriteAt(2, 0, " Левая ", HighlightTextColor, HighlightColor);
        WriteAt(41, 0, " Правая ", PanelTextColor, PanelBackgroundColor);
    }

    private static void DrawPanels(List<FileSystemEntry> leftData, List<FileSystemEntry> rightData)
    {

        WriteAt(2, 1, "Имя", PanelTextColor);
        WriteAt(15, 1, "Имя", PanelTextColor);
        WriteAt(28, 1, "Имя", PanelTextColor);
        DrawVerticalLine(39, 1, 22, '│');

        int row = 2, col = 0;
        foreach (var entry in leftData)
        {
            int xPos = 2 + (col * 13);
            var color = entry.IsDirectory ? DirectoryColor : PanelTextColor;
            WriteAt(xPos, row, entry.GetShortName().PadRight(12), color);

            row++;
            if (row > 22)
            {
                row = 2;
                col++;
                if (col > 2) break;
            }
        }

        WriteAt(41, 1, "Имя", PanelTextColor);
        WriteAt(54, 1, "Размер", PanelTextColor);
        WriteAt(64, 1, "Дата", PanelTextColor);
        WriteAt(73, 1, "Время", PanelTextColor);

        row = 2;
        foreach (var entry in rightData)
        {
            var color = entry.IsDirectory ? DirectoryColor : PanelTextColor;

            WriteAt(41, row, entry.GetShortName().PadRight(12), color);

            if (!entry.IsDirectory)
            {
                WriteAt(54, row, entry.Size.ToString().PadLeft(8), color);
            }
            else
            {
                WriteAt(54, row, "<DIR>".PadLeft(8), color);
            }

            WriteAt(64, row, entry.Modified.ToString("dd.MM.yy"), color);
            WriteAt(73, row, entry.Modified.ToString("HH:mm"), color);

            row++;
            if (row > 22) break;
        }
    }

    private static void DrawBottomBar()
    {
        Console.BackgroundColor = BottomBarColor;
        Console.SetCursorPosition(0, 24);
        Console.Write(new string(' ', Console.WindowWidth));

        string[] menu = { "1Помощь", "2Меню", "3Вид", "4Правка", "5Копия", "6Перенос", "7Папка", "8Удалить", "9Настр", "10Выход" };
        int currentPosition = 1;

        foreach (var item in menu)
        {

            if (currentPosition >= Console.WindowWidth) break;

            Console.SetCursorPosition(currentPosition, 24);

            int splitIndex = item.StartsWith("10") ? 2 : 1;

            string number = item.Substring(0, splitIndex);
            string text = item.Substring(splitIndex);

            Console.ForegroundColor = PanelBackgroundColor;
            Console.Write(number);

            Console.ForegroundColor = BottomBarTextColor;
            Console.Write(text);

            currentPosition += item.Length + 1;
        }
    }

    #region Helper Methods

    private static void DrawHorizontalLine(int x, int y, int length, char symbol)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = FrameColor;
        Console.Write(new string(symbol, length));
    }

    private static void DrawVerticalLine(int x, int y, int height, char symbol)
    {
        Console.ForegroundColor = FrameColor;
        for (int i = 0; i < height; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write(symbol);
        }
    }

    private static void WriteAt(int x, int y, char text, ConsoleColor fg, ConsoleColor bg = PanelBackgroundColor)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = fg;
        Console.BackgroundColor = bg;
        Console.Write(text);
    }

    private static void WriteAt(int x, int y, string text, ConsoleColor fg, ConsoleColor bg = PanelBackgroundColor)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = fg;
        Console.BackgroundColor = bg;
        Console.Write(text);
    }

    #endregion

    private static List<FileSystemEntry> GetPanelData()
    {
        return new List<FileSystemEntry>
        {
            new FileSystemEntry { Name = "norton", Type = "<DIR>", Modified = new DateTime(2025, 10, 5, 10, 30, 0) },
            new FileSystemEntry { Name = "autoexec", Type = "bat", Size = 432, Modified = new DateTime(2025, 11, 1, 9, 15, 0) },
            new FileSystemEntry { Name = "config", Type = "sys", Size = 256, Modified = new DateTime(2025, 11, 1, 9, 15, 0) },
            new FileSystemEntry { Name = "command", Type = "com", Size = 54619, Modified = new DateTime(2024, 5, 11, 3, 10, 0) },
            new FileSystemEntry { Name = "MyFileWithLongName", Type = "txt", Size = 12345, Modified = new DateTime(2025, 9, 1, 18, 45, 0) },
            new FileSystemEntry { Name = "docs", Type = "<DIR>", Modified = new DateTime(2025, 10, 20, 11, 0, 0) },
            new FileSystemEntry { Name = "image", Type = "jpg", Size = 204800, Modified = new DateTime(2025, 8, 15, 22, 5, 0) },
            new FileSystemEntry { Name = "archive", Type = "zip", Size = 1536000, Modified = new DateTime(2025, 11, 5, 14, 20, 0) },
            new FileSystemEntry { Name = "readme", Type = "txt", Size = 1024, Modified = new DateTime(2024, 6, 1, 12, 0, 0) },
            new FileSystemEntry { Name = "another_long_filename", Type = "dat", Size = 9876, Modified = new DateTime(2025, 1, 1, 0, 0, 0) },
            new FileSystemEntry { Name = "system", Type = "<DIR>", Modified = new DateTime(2024, 3, 3, 3, 3, 0) },
            new FileSystemEntry { Name = "program", Type = "exe", Size = 76800, Modified = new DateTime(2025, 7, 21, 16, 10, 0) },
            new FileSystemEntry { Name = "data", Type = "bin", Size = 307200, Modified = new DateTime(2025, 10, 30, 8, 0, 0) }
        };
    }
}
