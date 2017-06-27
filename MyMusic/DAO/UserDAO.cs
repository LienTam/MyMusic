using MyMusic.Context;
using MyMusic.Models;
using System;
using System.Linq;


namespace MyMusic.DAO
{
    public class UserDAO
    {
        ModelContext db = new ModelContext();
        public User getMemberFromId(int id)
        {
            return db.Users.Find(id);
        }

        public bool editRoleForUser(int idUser, int idGroupWantAddUser, int idGroupWantRemoveUser)
        {
            try
            {
                User user = db.Users.Find(idUser);
                GroupRoles groupRoleWantAddUser = db.GroupRoles.Find(idGroupWantAddUser);
                groupRoleWantAddUser.listUser.Add(user);
                GroupRoles groupRoleWantRemoveUser = db.GroupRoles.Find(idGroupWantRemoveUser);
                groupRoleWantRemoveUser.listUser.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public User editUserName(int idUserName, string userName)
        {
            User user = db.Users.Find(idUserName);
            user.userName = userName;
            db.SaveChanges();
            return user;

        }

        public bool editPassword(int idUser, string password)
        {
            try
            {
                db.Users.Find(idUser).password = password;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }

        public bool editFullName(int idUser, string fullName)
        {
            try
            {
                db.Users.Find(idUser).fullName = fullName;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }

        public bool editAvatar(int idUser, Image avatar)
        {
            try
            {
                db.Users.Find(idUser).avatar = avatar;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }

        public bool editEmail(int idUser, string email)
        {
            try
            {
                db.Users.Find(idUser).email = email;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public User getUser(int idUser)
        {
            return db.Users.Find(idUser);
        }



        //kiểm tra thong tin dang ki bằng email
        public bool checkEmail(String mail)
        {
            return db.Users.Count(x => x.email.Equals(mail)) > 0;
        }
        //tim theo email
        public User GetByid(string mail)
        {
            try
            {
                return db.Users.Where(u => u.email.Equals(mail)).First();
            }
            catch (Exception)
            {
                throw new Exception("-------------------------------------------");
            }
            
        }

        //kiểm tra thông tin email và pass khi user đăng nhập
        public int checkLogin(String mail, String pass)
        {
            var result = db.Users.SingleOrDefault(x => x.email.Equals(mail));
            if (result != null)
            {
                if (result.password.Equals(pass))
                {
                    return 1;

                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;

            }

        }

        // thêm 1 thành viên
        public long Insert(User u)
        {
            Member u1 = new Member();
            u1.userName = u.userName;
            u1.email = u.email;
            u1.password = u.password;
            u1.fullName = "Please insert Full Name";
            u1.avatar = db.Images.Find(1);
            var gr = db.GroupRoles.Find(1);
            gr.listUser.Add(u1);
            db.Users.Add(u1);
            db.SaveChanges();
            return u1.id;

        }



        // sửa thông tin thành viên
        public bool Update(User m)
        {
            try
            {
                var u1 = db.Users.Find(m.id);
                u1.userName = m.userName;
                u1.email = m.email;
                u1.password = m.password;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // tìm thành viên theo id
        public User ViewDetail(long id)
        {
            return db.Users.Find(id);
        }

        //xóa 1 thành viên
        public bool Delete(long id)
        {
            try
            {
                var menu = db.Users.Find(id);
                db.Users.Remove(menu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}