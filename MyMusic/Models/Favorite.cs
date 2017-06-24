using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyMusic.Models
{

    public class Favorite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, ForeignKey("OwnFavorite")]
        public int id { get; set; }
                
        public virtual List<Post> listPostFavorite { get; set; }
        
        public virtual Member OwnFavorite { get; set; }
        
    }
}
     

