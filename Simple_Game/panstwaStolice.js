$(document).ready(function ()
{
    function downloadData()
    {
        var dataFiles = ["./countries/easy.txt", "./countries/hard.txt"];
        $.each(dataFiles, function(i, v){

            $.post(v, function (data){
                if (i == 0)
                    easy = data;
                else
                    hard = data;
            })
                .fail( function () {
                    $("#pomocTxt").after("<div style='color: red;'> Nie udało się załadować pliku" + v + "! </div>")
                    $("#start").prop("disabled", true);
                });
        });
    }

    function playAudio(file)
    {
        var audio = new Audio("./sounds/" + file);
        audio.addEventListener('loadeddata', function()
        {
            audio.play();
        }, false);

        audio.addEventListener('error' , function()
        {
            console.log("Nie udało się załadować pliku ./sounds/" + file + "!");
        }, false);
    }

    function Player(name, score, lives)
    {
        this.name = name;
        this.score = score;
        this.lives = lives;

        this.setTextScore = function()
        {
            var pointsText = "";
            if (this.score == 1)
                pointsText = " punkt";
            else if (this.score > 1 && this.score < 5)
                pointsText = " punkty";
            else
                pointsText = " punktów";
            return pointsText;
        }

        this.printScore = function()
        {
            var pointsText = this.setTextScore();
            $("#punkty").val(this.name + " ma " + this.score + pointsText);
        }
    }

    function Game(diff, data)
    {
        var difficulty = diff;
        var capitals = [];
        var countries = [];
        var drawn = [];

        var rows = data.split("\n");
        for (var i = 0; i < rows.length; ++i)
        {
            var row = rows[i].split(";");
            countries.push(row[0].trim());
            capitals.push(row[1].trim());
        }

        this.remain = countries.length;
        for (var i = 0; i < countries.length; ++i)
            drawn[i] = false;

        this.printMeter = function ()
        {
            $("#pozostalo").text("Flaga " + parseInt(countries.length - this.remain) + "/" + countries.length);
            var meterVal = $("meter").val();
            $("meter").val(meterVal + 0.06);
        }

        this.removeHelpers = function ()
        {
            $("#panstwo").removeClass("bad good")
                .val("");
            $("#stolica").removeClass("bad good")
                .val("");
            $(".goodSign").remove();
            $(".badSign").remove();
        }

        this.setFlag = function ()
        {
            this.removeHelpers();
            var i = Math.floor(Math.random() * countries.length);
            while (drawn[i] == true)
                i = Math.floor(Math.random() * countries.length);
            --this.remain;
            drawn[i] = true;
            $("#flaga").attr("src", "./flags_" + difficulty + "/" + countries[i] + ".png")
                .attr("alt", countries[i]);
            this.printMeter();
        }

        this.checkAnswer = function (country, capital, player)
        {
            country = country.toLowerCase().trim();
            capital = capital.toLowerCase().trim();

            for (var i = 0; i < capitals.length; ++i)
            {
                if (countries[i] === country && capitals[i] === capital)
                {
                    playAudio("applause.mp3");
                    $("#panstwo").addClass("good")
                        .after("<span class='goodSign'> &#10003; </span>");
                    $("#stolica").addClass("good")
                        .after("<span class='goodSign'> &#10003; </span>");
                    alert("Gratulacje! :) Obie odpowiedzi są poprawne.\nOtrzymujesz dwa punkty.");
                    return 2;
                }
                else if (countries[i] === country && capitals[i] !== capital)
                {
                    playAudio("half.mp3");
                    $("#panstwo").addClass("good")
                        .after("<span class='goodSign'> &#10003; </span>");
                    $("#stolica").addClass("bad")
                        .after("<span class='badSign'> &#10007; </span>");
                    alert("Prawidłowo podałeś tylko nazwę kraju.\nOtrzymujesz punkt.");
                    return 1;
                }
                else if (countries[i] !== country && capitals[i] === capital)
                {
                    playAudio("half.mp3");
                    $("#panstwo").addClass("bad")
                        .after("<span class='badSign'> &#10007; </span>");
                    $("#stolica").addClass("good")
                        .after("<span class='goodSign'> &#10003; </span>");
                    alert("Prawidłowo podałeś tylko stolicę kraju.\nOtrzymujesz punkt.");
                    return 1;
                }
            }
            playAudio("boo.mp3");
            --player.lives;
            $("#live" + player.lives).remove();
            $("#panstwo").addClass("bad")
                .after("<span class='badSign'> &#10007; </span>");
            $("#stolica").addClass("bad")
                .after("<span class='badSign'> &#10007; </span>");
            alert("Niestety, ale obie odpowiedzi były złe!\nNie otrzymujesz punktów i tracisz szansę!");
            return 0;
        }
    }

    var game = undefined;
    var player = undefined;
    var easy = [];
    var hard = [];
    downloadData();

    $("#imie").focus(function ()
    {
        $(this).removeClass("bad");
        $(".badSign").remove();
    });

    $("#pomoc").click(function ()
    {
        $("#pomocTxt").toggle("slow");
    });

    $("#start").click(function ()
    {
        $(".badSign").remove();
        var name = $("#imie").val().trim();
        var diff = $("input:radio:checked").val();

        if (name != "")
        {
            $("#menu").remove();
            $("#gra").show();
            $("#formGra").before("<img src='' alt='' id='flaga' /> <br />");

            if (diff === "easy")
            {
                player = new Player(name, 0, 5);
                game = new Game(diff, easy);
            }
            else
            {
                player = new Player(name, 0, 3);
                game = new Game(diff, hard);
            }
            game.setFlag();
            for (var i = 0; i < player.lives; ++i)
                $("#szanse").after("<span id='live"+ i +"'> &#128147; <span> &nbsp;");
            player.printScore();
        }
        else
            $("#imie").addClass("bad")
                .after("<span class='badSign'> &#10007; </span>");
    });

    $("#sprawdz").click(function ()
    {
        var country = $("#panstwo").val();
        var capital = $("#stolica").val();
        player.score += game.checkAnswer(country, capital, player);
        if (player.lives > 0 && game.remain > 0)
        {
            game.setFlag();
            player.printScore();
        }
        else if (player.lives == 0)
        {
            playAudio("lose.mp3");
            setTimeout(function(){ alert("Przykro mi, ale przekroczyłeś limit złych odpowiedzi!\nPrzegrywasz grę " + player.name + "!"); location.reload(); }, 3000);
        }
        else
        {
            var pointsText = player.setTextScore();
            playAudio("win.mp3");
            setTimeout(function(){ alert("Udało Ci się skończyć grę " + player.name + "! Zdobyłeś " + player.score + pointsText);
                location.reload(); }, 3000);
        }
    });

});