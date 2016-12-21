using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp3.Data;
using ECommerceApp3.Models;

namespace ECommerceApp3.Services
{
    public class DataService
    {
        public Response UpdateUser(User user)
        {
            try
            {
                using (var da = new DataAccess())
                {
                    da.Update(user);
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSucess = false,
                    Message = ex.Message
                };
            }

            return new Response
            {
                IsSucess = true,
                Message = "Usuário atualizado com sucesso",
                Result = user
            };
        }
        public User GetUser()
        {
            using (var da = new DataAccess())
            {
                return da.First<User>(true);
            }

        }

        public Response InsertUser(User user)
        {
            try
            {
                using (var da = new DataAccess())
                {
                    var oldUser = da.First<User>(false);
                    if (oldUser != null)
                    {
                        da.Delete(oldUser);
                    }

                    da.Insert(user);
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSucess = false,
                    Message = ex.Message
                };
            }

            return new Response
            {
                IsSucess = true,
                Message = "Usuário cadastro OK",
                Result = user
            };
        }
    }
}
