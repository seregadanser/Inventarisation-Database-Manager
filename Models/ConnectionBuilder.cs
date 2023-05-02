using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.DBModels;

namespace DB_course.Models
{
    public interface IConnection
    {
        public string Type { get; set; }
    }

    public class ConnectionBuilder
    {
    public ConnectionBuilder(IConfigurationRoot config)
    {

    }

    public IConnection CreateMSSQLconnection()
    {
            return null;
    }

    public IConnection CreateMongoConnection ()
    {
            return null;
    }
    }
}
