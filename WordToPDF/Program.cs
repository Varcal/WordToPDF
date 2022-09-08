// See https://aka.ms/new-console-template for more information
using Spire.Doc;

var doc = new Document();
doc.LoadFromFile("D:\\Users\\varcal\\Desktop\\Eu.docx");

doc.Replace("@nome", "Varçal", true, true);

doc.SaveToFile("D:\\Users\\varcal\\Desktop\\meudoc.pdf", FileFormat.PDF);

var pdf = new MemoryStream();
doc.SaveToStream(pdf, FileFormat.PDF);

var file = Convert.ToBase64String(pdf.ToArray());

Console.WriteLine(file);

Console.ReadKey();
