using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTest
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string path = @"C:\ServiceTest\";

                //Creamos el directorio
                Directory.CreateDirectory(path);

                //Establecemos la ubicación del fichero de texto
                path += "output.txt";

                //Escribimos en el fichero
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"Hello world from the {DateTime.Now}");
                }

                //Se ejecutará cada 1000 ms = 1 segundo
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
