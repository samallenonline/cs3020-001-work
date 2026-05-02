/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #4 - Question #4

Objective: Write a program that downloads 
a file asynchronously.
*/

using System;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

public class AsyncFileDownloader
{
    private static readonly HttpClient client = new HttpClient();

    public async Task DownloadFileAsync (string url, string destinationPath)
    {
        Console.WriteLine("> Starting file download...");

        /* headers to avoid 403 Forbidden errors*/
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

        /* send the GET request asynchronously */
        using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
        {
            response.EnsureSuccessStatusCode(); // ensure a successful response 
            using (var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                /* open a stream to read the donwloaded content */
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    /* read and write the file in chunks to avoid high memory usage */
                    await stream.CopyToAsync(fileStream);
                    Console.WriteLine("> File downloaded successfully!");
                }
            }
        }
    }

    public static async Task Main(string[] args)
    {
        Console.WriteLine("\nTask 4: Async File Download\n");

        /* define downloader */
        var fileDownloader = new AsyncFileDownloader();
        string fileURL = "http://ipv4.download.thinkbroadband.com/1GB.zip";
        string destinationPath = "1GB.zip";

        /* start asynchronous download */
        await fileDownloader.DownloadFileAsync(fileURL, destinationPath);
    }
}