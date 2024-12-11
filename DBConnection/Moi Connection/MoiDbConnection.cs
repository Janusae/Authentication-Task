using DBConnection.TableEntitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection.Moi_Connection
{
	public class MoiDbConnection : DbContext
	{
		public MoiDbConnection(DbContextOptions<MoiDbConnection> options) : base (options){ }
		public DbSet<User> users { get; set; }
	}
}
