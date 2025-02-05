using DataBaseConnection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Interfaces;

namespace WorkerService1
{
    public class EntityToDataBase:IEntityToDataBase
    {
        public async void EntityToDataBaseSave(Obss obsEntity, ConfigSerialize config, ILogger logger)
        {
            logger.LogInformation("Подключение к БД {time}", DateTime.Now);

            string connectionString = config.PSQL.Host + config.PSQL.Port + config.PSQL.Database +
                                      config.PSQL.Username + config.PSQL.PasswordSQL;

            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            await using var conn = await dataSource.OpenConnectionAsync();

            logger.LogInformation("Начало транзакции {time}", DateTime.Now);
            await using var tx = await conn.BeginTransactionAsync();
            try
            {
                var sql = "INSERT INTO weatherobservations (DATE, TEMP_C, CONDITION, NAME, JSONRESPONSE) " +
                    "VALUES (@date,@temp_c, @condition, @name, @jsonresponce)";
                await using var cmd1 = new NpgsqlCommand(sql, conn, tx)
                {
                    Parameters =
                    {
                new("@date", obsEntity.DATE),
                new("@temp_c", obsEntity.TEMP_C),
                new("@condition", obsEntity.CONDITION),
                new("@name", obsEntity.NAME),
                new("@jsonresponce", obsEntity.JSONRESPONSE)
                    }
                };
                logger.LogInformation("Запись в БД {time}", DateTime.Now);
                await cmd1.ExecuteNonQueryAsync();
                await tx.CommitAsync();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Roll back the transaction
                await tx.RollbackAsync();
            }
        }
    }
}
