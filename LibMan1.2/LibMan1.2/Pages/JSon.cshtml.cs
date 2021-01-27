using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using LibMan1._2.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibMan1._2.Pages
{
    public class JSonModel : PageModel
    {

        private static readonly HttpClient client = new HttpClient();
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int PageNumber { get; set; }
        public string Publisher { get; set; }
        public string BookSummary { get; set; }
        public string Categories { get; set; }
        public string ReadingStatus { get; set; }
        public byte[] Image { get; set; }



        private readonly LibMan1._2.Models.DB.LibManContext _context;

        public JSonModel(LibMan1._2.Models.DB.LibManContext context)
        {
            _context = context;
        }

        public IList<TableBookInfo> TableBookInfo { get; set; }

        public String berke { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            TableBookInfo = await _context.TableBookInfo.ToListAsync();

            List<TableBookInfo> m = new List<TableBookInfo>(); //llşiste oluştu
            foreach (var repo in TableBookInfo)
            {
                m.Add(new TableBookInfo
                {
                    BookName = repo.BookName,
                    AuthorName = repo.AuthorName,
                    PageNumber = repo.PageNumber,
                    Publisher = repo.Publisher,
                    ReadingStatus = repo.ReadingStatus,
                    BookSummary = repo.BookSummary,
                    Categories = repo.Categories,
                    Image = repo.Image

                }); 
            }

            berke = Newtonsoft.Json.JsonConvert.SerializeObject(m);

            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/jsonExport", "ExportJSonData.json");

            using (StreamWriter sw = new StreamWriter(SavePath))
            {
                sw.Write(berke);
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/jsonExport", "ExportJSonData.json");

            //string filePath = Directory.GetCurrentDirectory() + "wwwroot/Files/ExportJSON";
            string fileName = "ExportJSonData.json";

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/x-msdownload", fileName);
        }

        static async Task Main(string[] args)
            {



            /*
                var repositories = await ProcessRepositories();
                foreach (var repo in repositories)
                {
                    Console.WriteLine(repo.BookName);
                    Console.WriteLine(repo.AuthorName);
                    Console.WriteLine(repo.PageNumber);
                    Console.WriteLine(repo.Publisher);
                    Console.WriteLine(repo.BookSummary);
                    Console.WriteLine(repo.Categories);
                    Console.WriteLine(repo.ReadingStatus);
                    Console.WriteLine(repo.Image);
                    Console.WriteLine(repo.BookId);

                    Console.WriteLine();
                }*/

           

            }

            private static async Task<List<TableBookInfo>> ProcessRepositories()
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
                var repositories = await JsonSerializer.DeserializeAsync<List<TableBookInfo>>(await streamTask);
           
                return repositories;
            }
        }
    }