/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #5 - Question #2

Objective: Create a C# console application that 
implements a robust asynchronous file downloader.
*/

using System;
using System.Net.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class AsyncFileDownloader
{
    private static readonly HttpClient client = new HttpClient();

    /* asynchronous method to download a large file with cancellation support */
    public async Task DownloadFileAsync(string url, string destinationPath, CancellationToken cancellationToken)
    {
        Console.WriteLine("Starting file download...");

        /* add headers to avoid 403 forbidden errors */
        if (!client.DefaultRequestHeaders.Contains("User-Agent"))
        {
            client.DefaultRequestHeaders.Add("User-Agent", 
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 " +
            "(KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
        }

        /* send the GET request asynchronously with cancellation support */
        using (HttpResponseMessage response = await client.GetAsync(
            url, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
        {
            response.EnsureSuccessStatusCode(); /* ensure a successfull resposne */

            /* open a stream to write the downloaded file */
            using (var fileStream = new FileStream(destinationPath, FileMode.Create, 
            FileAccess.Write, FileShare.None))
            {
                /* open a stream to read the downloaded content */
                using (var stream = await response.Content.ReadAsStreamAsync(cancellationToken))
                {
                    /* read and write the file in chunks with cancellation support */
                    await stream.CopyToAsync(fileStream, 81920, cancellationToken);
                    Console.WriteLine("File downloaded successfully!");
                }
            }
        }
    }

    public static async Task Main(string[] args)
    {
        var downloader = new AsyncFileDownloader();
        /* define file paths */
        string fileUrl = "http://ipv4.download.thinkbroadband.com/1GB.zip";
        string destinationPath = "1GB.zip"; 

        /* implement cancellation functionality */
        using CancellationTokenSource cts = new CancellationTokenSource();
        
        /* removing the below line allows the file to download completely, 
        otherwise it is cancelled and a "download canceled" message appears */
        cts.CancelAfter(TimeSpan.FromSeconds(10));

        Console.WriteLine("Press any key to cancel the downloader...");

        Task keyPressTask = Task.Run(() => Console.ReadKey(true));
        var downloadTask = downloader.DownloadFileAsync(fileUrl, destinationPath, cts.Token);
        var completedTask = await Task.WhenAny(downloadTask, keyPressTask);

        /* if key pressed first, cancel operation */
        if (completedTask == keyPressTask)
        {
            cts.Cancel();
            Console.WriteLine("Cancellation requested.");
        }

        /* await the download task to observe any exceptions */
        try
        {
            await downloadTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Download canceled by user.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Download failed: {ex.Message}");
        }
    }
}