using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using SuivImmo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuivImmo.Services
{
    public class GestionDatabase
    {
        #region Attributs
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        #endregion
        #region Constructeurs
        public GestionDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }
        #endregion
        #region Methodes
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constantes.DatabasePath, Constantes.Flags);
        });
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Biens).Name))
                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Biens)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(EvolutionPrix)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Photos)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Villes)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<T>> GetItemsAsync<T>() where T : new()
        {

            return Database.Table<T>().ToListAsync();
        }

        public Task<List<T>> GetItemsAsyncTodoItemEvent<T>() where T : new()
        {

            return Database.Table<T>().ToListAsync();
        }

       /* public Task<List<T>> GetItemsNotDoneAsync<T>() where T : new()
        {
            return Database.QueryAsync<T>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }
       */
        public Task<T> GetItemAsync<T>(int id) where T : new()
        {
            return Database.FindAsync<T>(id); ;
        }
        
        public Task<int> SaveItemAsync<T>(T item,int ID)
        {
            if (ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync<T>(T item)
        {
            return Database.DeleteAsync(item);
        }
        public Task UpdateRelation<T>(T item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }
       

        public Task<T> GetRelation<T>(T item) where T : new()
        {
            return Database.GetWithChildrenAsync<T>(item);
        }


        #endregion
    }
}
