using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace MyMusic.Models
{
    
public class Admin : Manager
    {

        // list nhung nguoi duoc tang quyen
   

    public virtual HashSet<Editor> listEditerConfirm { get; set; }
    // list nhung bai dang da dang

  

    public Admin()
    {
        
    }

}

}