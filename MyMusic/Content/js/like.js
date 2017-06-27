    function like(i){
        urlLike = $("#myLink_"+i).attr("href");
        $.ajax({
            type: 'GET',
            url: urlLike
            
        });
        };

