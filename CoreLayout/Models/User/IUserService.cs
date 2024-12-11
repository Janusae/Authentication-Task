using CoreLayout.DTOS.User;
using CoreLayout.StatusHandlers;
using DBConnection.TableEntitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection.TableEntitiy;
namespace CoreLayout.Models.User
{
	public interface IUserService
	{
		DBConnection.TableEntitiy.User Login(Login LoginDTOS);
		StatusHandler Register(SignIn signInDTOS);
	}
}
