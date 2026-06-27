using System;
using System.IO;

var blockMapPath =
    @"C:\Users\radek\source\repos\Lab09_PackagedApp\Lab09_PackagedApp\msix-contents\AppxBlockMap.xml";

await using var stream = new FileStream(
    blockMapPath,
    FileMode.Open,
    FileAccess.Read);

using var reader = new StreamReader(stream);

int blockCount = 0;
string? line;

while ((line = await reader.ReadLineAsync()) is not null)
{
    if (line.Contains("<Block "))
        blockCount++;
}

await File.WriteAllTextAsync(
    @"C:\Users\radek\Desktop\wynik.txt",
    $"Liczba blokow w AppxBlockMap: {blockCount}");