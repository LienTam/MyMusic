
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMusic.Models
{
    public class GroupRoles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }
        public string name { get; set; }


        public virtual List<User> listUser { get; set; }

        public virtual Role roles { get; set; }

        public List<User> getListUser()
        {
            return listUser;
        }

        public GroupRoles(string name, Role roles)
        {
            this.name = name;
            this.roles = roles;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public Role getRoles()
        {
            return roles;
        }

        public void setRoles(Role roles)
        {
            this.roles = roles;
        }

        public GroupRoles()
        {
        }
    }

}