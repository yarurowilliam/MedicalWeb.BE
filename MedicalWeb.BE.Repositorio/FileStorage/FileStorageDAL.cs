using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MedicalWeb.BE.Repositorio.Interfaces;

namespace MedicalWeb.BE.Infraestructura
{
    public class FileStorageDAL : IFileStorageDAL
    {
        private readonly string _storagePath;

        public FileStorageDAL()
        {
            _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads"); // Carpeta base
            Directory.CreateDirectory(_storagePath); // Asegura que la carpeta exista
        }

        public async Task<string> UploadFileAsync(IFormFile file, string path, CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("El archivo no puede estar vacío");

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var directoryPath = Path.Combine(_storagePath, path);
            var filePath = Path.Combine(directoryPath, fileName);

            // Asegura que la carpeta existe antes de guardar
            Directory.CreateDirectory(directoryPath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            return Path.Combine(path, fileName); // Retorna la ruta relativa
        }

        public async Task<List<string>> GetFilesAsync(string directory, CancellationToken cancellationToken)
        {
            string path = Path.Combine(_storagePath, directory);

            if (!Directory.Exists(path))
                return new List<string>();

            var files = Directory.GetFiles(path)
                                 .Select(f => Path.Combine(directory, Path.GetFileName(f)))
                                 .ToList();

            return await Task.FromResult(files);
        }
    }
}