using System.Data.Common;

namespace MedicalWeb.BE.Infrastructure.Data;
public interface IOnBoardDbConnection
{
    public DbConnection Connection { get; }
}
