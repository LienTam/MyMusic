using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMusic.Models
{
    public class Role
    {

        /**
         * 
         */
        [Key]
        public int role { get; set; } = 0;

        public virtual HashSet<GroupRoles> listGroupRoles { get; set; }

        public Role()
        {
        }

        public Role(int role)
        {
            this.role = role;
        }



    }
}