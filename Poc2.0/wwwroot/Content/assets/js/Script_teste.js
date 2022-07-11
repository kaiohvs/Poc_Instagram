
function usuario() {

    var usuario_perfile = document.getElementById("usuario_perfile").value;
    console.log(usuario_perfile);

    var token = "EAAIlM1oZCHHEBAG1Hf9ald0tKseI15F4yDr3AA8WcaHp5KJIzKK87u2BiSwjfP8kBZBAn6TbBbSugAQt3cQdZC4wCsGr1M9JuFFcVi4yXJH0aoc0dUN1ZB2VKi9VhsFvp0JX7yV0RRPqniSJuyM5TvIS9o11uBuN2ThTcZCfzJEGRLWZB5PBVZBofbQrEGyehSZCDnvywXFvLJQxuW9THzDj";
    var urls = "https://graph.facebook.com/v14.0/17841453664235456?fields=business_discovery.username(" + usuario_perfile + "){followers_count,follows_count,username,id,media_count,media{id,media_url,media_type,permalink,like_count,comments_count,caption,username,timestamp}}&access_token=" + token;

    $.get(urls).then(function (response) {
        console.log('retorno: ', response.business_discovery.media.data);
        console.log('retorno: ', response);

        let feed = response.business_discovery;
        console.log('feed: ', feed.id);
        
        let conteudo = "";
        conteudo += "<table class='table'><thead><tr><th>#</th><th>Username</th><th>Followers Count</th><th>Follows_count</th><th>Media Count</th>";
        conteudo += "</tr></thead>";
        conteudo += "<tbody>";
        conteudo += "<tr>";
        conteudo += "<td>" + feed.id + "</td>";
        conteudo += "<td>" + feed.username + "</td>";
        conteudo += "<td>" + feed.followers_count + "</td>";
        conteudo += "<td>" + feed.follows_count + "</td>";
        conteudo += "<td>" + feed.media_count + "</td>";        
        conteudo += "</tr>";
        conteudo += "</tbody></table>";

       $("#list_perfile").html(conteudo);
    });
};

function insight() {
    var usuario_select = document.getElementById("select_insight").value;
    var usuario_insight = document.getElementById("usuario_insight").value;
    console.log(usuario_insight);
    console.log(usuario_select);

    var token = "EAAIlM1oZCHHEBAG1Hf9ald0tKseI15F4yDr3AA8WcaHp5KJIzKK87u2BiSwjfP8kBZBAn6TbBbSugAQt3cQdZC4wCsGr1M9JuFFcVi4yXJH0aoc0dUN1ZB2VKi9VhsFvp0JX7yV0RRPqniSJuyM5TvIS9o11uBuN2ThTcZCfzJEGRLWZB5PBVZBofbQrEGyehSZCDnvywXFvLJQxuW9THzDj";
    var urls = "https://graph.facebook.com/v14.0/17841453664235456?fields=business_discovery.username(" + usuario_insight + "){followers_count,follows_count,username,id,media_count,media{id,media_url,media_type,permalink,like_count,comments_count,caption,username,timestamp, media_product_type}}&access_token=" + token;
        
    if (usuario_select == 1) {
        $.get(urls).then(function (response) {
            let dadosJson = response.business_discovery.media.data;                                   
            let conteudo = "";
            conteudo += "<table class='table'><thead><tr><th>#</th><th>Media Type</th><th>Caption</th><th>Like Count</th><th>Comments Count</th><th>Permalink</th>";
            conteudo += "</tr></thead>";
            conteudo += "<tbody>";

            for (let p = 0; p < dadosJson.length; p++) {
                let feed = dadosJson[p]; 
                let titulo = feed.caption !== null ? feed.caption : '';

                conteudo += "<tr>";

                if (feed.media_type == "IMAGE") {
                    conteudo += "<td><img src=" + feed.media_url + " style='width:100px; height:100px;'></td>";
                }
                else if (feed.media_type == "VIDEO") {
                    conteudo += "<td><video style='width:100px; height:100px;'controls><source src=" + feed.media_url + "type='video/mp4'></video></td>";
                }
                else {
                    conteudo += "<td><img src=" + feed.media_url + " style='width:100px; height:100px;'></td>";
                }

                conteudo += '<td>' + feed.media_type + '</td>';
                conteudo += '<td>' + titulo + '</td>';
                conteudo += '<td>' + feed.like_count + '</td>';
                conteudo += '<td>' + feed.comments_count + '</td>';
                conteudo += '<td>' + feed.permalink + '</td>';
                conteudo += '</tr>';               

            }
            conteudo += "</tbody></table>";

            $("#list_insight").html(conteudo);
        });
    }
    else if (usuario_select == 2) {
        $.get(urls).then(function (response) {
            let dadosJson = response.business_discovery.media.data;
            let conteudo = "";
            conteudo += "<table class='table'><thead><tr><th>Video</th><th>Media Type</th><th>Caption</th><th>Like Count</th><th>Comments Count</th><th>Permalink</th>";
            conteudo += "</tr></thead>";
            conteudo += "<tbody>";
           
            for (let p = 0; p < dadosJson.length; p++) {
                let feed = dadosJson[p];
                let titulo = feed.caption !== null ? feed.caption : '';

                if (feed.media_product_type == 'REELS') {
                    conteudo += "<tr>";
                    conteudo += "<td><video style='width:100px;height: 100px;'controls><source src=" + feed.media_url +" type='video/mp4'></video></td>";
                    conteudo += '<td>' + feed.media_product_type + '</td>';
                    conteudo += '<td>' + titulo + '</td>';
                    conteudo += '<td>' + feed.like_count + '</td>';
                    conteudo += '<td>' + feed.comments_count + '</td>';
                    conteudo += '<td>' + feed.permalink + '</td>';
                    conteudo += '</tr>';
                }

            }
            conteudo += "</tbody></table>";

            $("#list_insight").html(conteudo);
        });
    }
    else if (usuario_select == 3) {
        console.log("Stories");
    }
    else{
        console.log("Você não selecionou nenhum campo no select");
    }

   
    
};
