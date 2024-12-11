using CoreLayout.DTOS.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection.Moi_Connection;
using DBConnection.TableEntitiy;
using CoreLayout.StatusHandlers;
namespace CoreLayout.Models.User
{
	public class UserService : IUserService
	{
		private readonly MoiDbConnection _dbConnection;
		public UserService(MoiDbConnection DBconnection)
		{
			_dbConnection = DBconnection;
		}
		public DBConnection.TableEntitiy.User Login(Login LoginDTOS)
		{
			var search = _dbConnection.users.SingleOrDefault(x=>x.userName == LoginDTOS.Username && x.passWord == PasswordHasher.HashPassword(LoginDTOS.Password));
			if (search != null )
			{
				return search;
			}
			else
			{
				search = null;
				return search;
			}
		}

		public StatusHandler Register(SignIn signInDTOS)
		{
			var search = _dbConnection.users.Any(x => x.Email == signInDTOS.Email);
			if (!search)
			{
				try
				{
					var user = _dbConnection.users.Add(new DBConnection.TableEntitiy.User()

					{
						fullName = signInDTOS.Fullname,
						isDelete = false,
						passWord = PasswordHasher.HashPassword(signInDTOS.Password),
						userName = signInDTOS.Username,
						userRole = userLevel.Standard , 
						Email = signInDTOS.Email,
					});
					_dbConnection.SaveChanges();
					var statusHandler = new StatusHandler();
					return statusHandler.Success("You signed in successfully");
				}
				catch ( Exception e)
				{
					var statusHandler = new StatusHandler();
					return statusHandler.Faild("Your information are wrong!");

				}
				
			}
			else
			{
				var statusHandler = new StatusHandler();
				return statusHandler.Faild("You are not signed in successfully");
			}
			
		}
	}
}
