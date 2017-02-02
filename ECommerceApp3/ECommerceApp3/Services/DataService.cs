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

        public void SaveProducts(List<Product> products)
        {
            using (var da = new DataAccess())
            {
                var oldProducts = da.GetList<Product>(false);
                foreach (var product in oldProducts)
                {
                    da.Delete(product);
                }
                foreach (var product in products)
                {
                    da.Insert(product);
                }
            }
        }

        public List<Product> GetProducts(string filter)
        {
            try
            {
                using (var da = new DataAccess())
                {
                    return da.GetList<Product>(true)
                        .Where(p => p.Description.ToUpper().Contains(filter.ToUpper()))
                        .OrderBy(p => p.Description).ToList();
                }
            }
            catch (Exception Ex)
            {
                return new List<Product>();
            }
        }

        public List<Product> Getproducts()
        {
            try
            {
                using (var da = new DataAccess())
                {
                    return da.GetList<Product>(true).OrderBy(p => p.Description).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public Response Login(string userEmail, string password)
        {
            try
            {
                using (var da = new DataAccess())
                {
                    var user = da.First<User>(true);
                    if (user == null)
                    {
                        return new Response
                        {
                            IsSucess = false,
                            Message = "Não há conexão com Internet e não existe um usuário previamente cadastrado!"
                        };
                    }

                    if (user.UserName.ToUpper() == userEmail.ToUpper() && user.Password == password)
                    {
                        return new Response
                        {
                            IsSucess = true,
                            Message = "Login OK!",
                            Result = user
                        };
                    }
                    else
                    {
                        return new Response
                        {
                            IsSucess = false,
                            Message = "Usuário e/ou Senha incorretos!"
                        };
                    }
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
        }
    }
}
