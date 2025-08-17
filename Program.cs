using Google.Protobuf.WellKnownTypes;
using SQLThing.indexing.impl;
using SQLThing.indexing.models;
using SQLThing.matching;
using System.Text;

namespace mew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var storage = new MySqlBasedInvertedTokenStorage();
            var dict = new Dictionary<string, long>()
            {

                { "token2", 10 },
                { "token3", 15 },
                { "token4", 12 },
                { "token8", 8 },
                { "token12", 242 }

            };
            var dindex = new DocumentIndex
            {
                FrequencyDict = dict,
                DocumentLink = "http://example.com/document/88"

            };


            //storage.StoreIndex(dindex);
            Token[] tokens = storage.ResolveTokens(new string[] { "token1", "token12", "token2" });
            Matcher matcher = new Matcher(storage);
            /*matcher.MatchToken(new Token[] { new Token
            {
                Id= "4",
                Value="token4"
            } });*/
            //time query
            var startTime = DateTime.Now;
            /*var documents = matcher.MatchToken(new Token[] { new Token
            {
                Id= "4",
                Value="token4"
            }, new Token{ 
                Id= "7",
                Value="token8"
            }, new Token{
                Id= "8",
                Value="token12"
            } });

            var endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;
            Console.WriteLine($"Query executed in: {elapsedTime.TotalMilliseconds} ms");
            // Define column headers
            var headers = new List<string> { "ID", "Document Link", "Document Type", "Total Terms" };
            var columnWidths = new Dictionary<string, int>
        {
            
            { "Document Link", 30 },
            { "Document Type", 20 },
            { "Total Terms", 15 }
        };

            // Dynamically adjust column widths based on the longest string
            if (documents != null && documents.Any())
            {
                columnWidths["ID"] = Math.Max(columnWidths["ID"], documents.Max(d => d.Id.Length));
                columnWidths["Document Link"] = Math.Max(columnWidths["Document Link"], documents.Max(d => d.DocumentLink.Length));
                columnWidths["Document Type"] = Math.Max(columnWidths["Document Type"], documents.Max(d => d.DocumentType.Length));
                columnWidths["Total Terms"] = Math.Max(columnWidths["Total Terms"], documents.Max(d => d.totalTermCount.ToString().Length));
            }

            // Create the header row
            var headerBuilder = new StringBuilder();
            foreach (var header in headers)
            {
                headerBuilder.Append($"| {header.PadRight(columnWidths[header])} ");
            }
            headerBuilder.Append("|");

            // Create the separator line
            var separator = new string('-', headerBuilder.Length);

            Console.WriteLine(separator);
            Console.WriteLine(headerBuilder.ToString());
            Console.WriteLine(separator);

            // Print each document's data
            if (documents != null)
            {
                foreach (var doc in documents)
                {
                    var rowBuilder = new StringBuilder();
                    rowBuilder.Append($"| {doc.Id.PadRight(columnWidths["ID"])} ");
                    rowBuilder.Append($"| {doc.DocumentLink.PadRight(columnWidths["Document Link"])} ");
                    rowBuilder.Append($"| {doc.DocumentType.PadRight(columnWidths["Document Type"])} ");
                    rowBuilder.Append($"| {doc.totalTermCount.ToString().PadRight(columnWidths["Total Terms"])} ");
                    rowBuilder.Append("|");
                    Console.WriteLine(rowBuilder.ToString());
                }
            }

            Console.WriteLine(separator);
        }
        *//* List<DocumentIndex> documentIndexes = storage.MatchTokens(new Token[] { new Token
         {
             Id= "1",
             Value="token1"
         } });
         //print the document indexes in a tabular format
         Console.WriteLine("Document Indexes:");
         Console.WriteLine("Id\tDocumentLink\tToken\tFrequency");
         foreach (var documentIndex in documentIndexes) { 
             foreach (var kvp in documentIndex.FrequencyDict)
             {
                 Console.WriteLine($"{documentIndex.Id}\t{documentIndex.DocumentLink}\t{kvp.Key}\t{kvp.Value}");
             }
         }*/


        }
    }
}

    
    

   
