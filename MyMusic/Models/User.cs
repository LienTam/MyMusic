using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMusic.Models
{
   public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]

        public int id { get; set; }


        [Required(ErrorMessage = "Bạn chưa nhập tên!")]
        public string userName { get; set; }

        [StringLength(30, MinimumLength = 8, ErrorMessage = "Độ dài mật khẩu ít nhất 8 kí tự!")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!")]
        public string password { get; set; }

        public string fullName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ email!")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
        ErrorMessage = "Định dạng Email chưa chính xác!")]
        public string email { get; set; }
        public DateTime dateRegister { get; set; }

        public virtual Image avatar { get; set; }
        
        public virtual HashSet<Comment> listCmt { get; set; }

        public virtual GroupRoles groupRoles { get; set; }
        
        public virtual HashSet<Likes> listLikes { get; set; }

        public virtual HashSet<Share> listShare { get; set; }

        public User()
        {
         dateRegister = DateTime.Now;
        }

     
        
        public void addListComment(Comment comment)
        {
            listCmt.Add(comment);
        }
        
    }

}