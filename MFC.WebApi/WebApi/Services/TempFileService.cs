using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace WebApi.Services;

public class RedisService
{
    private void ClearOldFiles()
    {
        // удалить файлы старше N дней 
        int delDay= 1; // дни (через сколько удалять старые файлы)
        string[] files = Directory.GetFiles(""); // получаем все файлы из указанного каталога
        foreach (string file in files) // удаление старых файлов в цикле
        {
            FileInfo fi = new FileInfo(file);
            if (fi.CreationTime < DateTime.Now.AddDays(-delDay)) { fi.Delete(); } // если дата создания файла меньше (сегодня - delDay), то удаляем файл
        }
    }
    // private ConnectionMultiplexer redis;
    // IDatabase _database;
    //
    // public RedisService()
    // {
    //     redis = ConnectionMultiplexer.Connect("localhost");
    //     _database = redis.GetDatabase();
    // }

    // public void SetFile()
    // {
    //     _database.S()
    // }
    // void test()
    // {
    //     
    // }
}