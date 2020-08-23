using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;

public class AzureMobileService
{
    public MobileServiceClient Client { get; private set; }
    private IMobileServiceSyncTable<Log> LogTable;

    private async Task Initialize()
    {
        Client = new MobileServiceClient("https://mediinapp.azurewebsites.net");

        var path = Path.Combine(MobileServiceClient.DefaultDatabasePath, "DBRNCL.db");

        var store = new MobileServiceSQLiteStore(path);

        store.DefineTable<Log>();

        await Client.SyncContext.InitializeAsync(store);

        LogTable = Client.GetSyncTable<Log>();
    }
    private async Task SyncLog()
    {
        await LogTable.PullAsync(null, LogTable.CreateQuery());
        await Client.SyncContext.PushAsync();
    }
    public async Task<List<Log>> GetAllLogs()
    {
        await Initialize();
        await SyncLog();
        
        return await LogTable.ToListAsync();       
    }
    public async Task<bool> UpdateLog(Log log)
    {
        try
        {
            await LogTable.InsertAsync(log);
            await SyncLog();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
