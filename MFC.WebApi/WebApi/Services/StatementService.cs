
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Minio;
using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class StatementService(IStatementRepository repository) : IStatementService
{
    private static readonly string SaveDir = Path.Combine(Directory.GetCurrentDirectory(), "statements");

    private static string PathToFile(string fileName)
    {
        return Path.Combine(SaveDir, fileName);
    }

    public static void CheckSaveDir()
    {
        if (Directory.Exists(SaveDir))
        {
            //TODO Если в директории есть файлы, но их нет в БД, то добавить ссылки
            return;
        };
        
        Directory.CreateDirectory(SaveDir);
        // TODO удалить все пред файлы в базе?/
        
    }
    
    
    public async Task<List<string>> GetFilesList()
    { 
        
        if (!Directory.Exists(SaveDir))
        {
            throw new Exception("На данном сервере нет файлов");
        }
  
        
        var statements = await repository.ReadAllFilesAsync();
        
        
        return statements
            .Where(statement => File.Exists(statement.Path))
            .Select(statement => statement.Name)
            .ToList();
    }
    
    public async Task CreateFile(string fileName, Stream stream)
    {
        
        var pathToFile = PathToFile(fileName);

        try
        {
            await using Stream outStream = File.OpenWrite(pathToFile);
            await stream.CopyToAsync(outStream);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        // TODO синхронизация должна проводиться при старте программы
        // var existInDb = repository.FileIsExist(fileName);
        //
        // //Если файл существует, надо проверить, есть ли он в базе и записать, если нет
        // if (File.Exists(pathToFile))
        // {
        //     if (existInDb)
        //     {
        //         // Файл уже существует
        //         throw new Exception($"File: {pathToFile} - already exist!");
        //     } 
        //     
        //     // Файл существует только локально. Можно перезаписать
        //     
        // }
        // else
        // {
        //     if (existInDb)
        //     {
        //         repository.UpdateFile(fileName, pathToFile);
        //     }
        // }
        //     
        
        repository.CreateFile(fileName, pathToFile);
    }
    
    public async Task UpdateFile(string fileName, Stream stream)
    {
        var pathToFile = PathToFile(fileName);
        
        if (!File.Exists(pathToFile))
            throw new Exception($"File: {pathToFile} - doesnt exist!");
        
        // TODO Как синхронизировать базу и локальное хранилище......
        File.Delete(pathToFile);
        
        await using Stream outStream = File.OpenWrite(pathToFile);
        await stream.CopyToAsync(outStream);
    }
    
    public void DeleteFile(string fileName)
    {
        
        var pathToFile = PathToFile(fileName);
        
        if (!File.Exists(pathToFile))
            throw new Exception($"File: {pathToFile} - doesnt exist!");
        
        File.Delete(pathToFile);
        
        repository.DeleteFile(fileName);
        
    }
    
    
    public FileStream ReadFileStream(string fileName)
    {
        var statement = repository.ReadFile(fileName);
        if (statement == null) throw new NullReferenceException();

        try
        {
            var stream = File.OpenRead(PathToFile(statement.Name));

            return stream;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}