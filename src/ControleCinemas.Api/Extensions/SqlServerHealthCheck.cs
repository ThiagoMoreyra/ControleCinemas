using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ControleCinemas.Api.Extensions
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        readonly string _connection;
        public SqlServerHealthCheck(string connection)
        {
            _connection = connection;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                using (var connetion = new SqlConnection(_connection))
                {
                    await connetion.OpenAsync(cancellationToken);

                    var command = connetion.CreateCommand();
                    command.CommandText = "select count(id) from tbAtor";

                    return Convert.ToInt32(await command.ExecuteScalarAsync(cancellationToken)) > 0 ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
                }
            }
            catch (Exception)
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}