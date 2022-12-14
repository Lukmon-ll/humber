window.onload = pageload;
function pageload(){
    //alert("This is my test");

    var myApiKey = "2a19473ece0b015136d90398301bd2e4";
    const url1 = "https://api.openweathermap.org/data/2.5/weather?q=Toronto&appid=" + myApiKey + "&units=metric";
    const url2 = "https://api.openweathermap.org/data/2.5/weather?q=Mississauga&appid=" + myApiKey + "&units=metric";
    //var RES = "";
    //console.log(url);
    var BU1 = document.getElementById("Toronto");
    var BU2 = document.getElementById("Yourtown");
    var city = document.getElementById("location");
    var TEMP = document.getElementById("temperature");
    var WC = document.getElementById("conditions");
    var IC = document.getElementById("icon");
    var WS = document.getElementById("ws");
    //var thetest = document.getElementById("THETEST");

    BU1.onclick = button1;
    BU2.onclick = button2;

    function button1(){

        //console.log("This is nice for testing onclicking is working");
        var Out1 = document.getElementById("output");
        Out1.style.display = "block";

        let xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function(){

            if (xhttp.readyState == 4 & xhttp.status == 200){

                //thetest.innerHTML = xhttp.response;
                const RES = xhttp.response;
                
                //console.log(RES);
                //console.log(RES.main.temp);
                //console.log(RES.weather[0].description);
                //console.log(RES.weather[0].icon);
                city.innerHTML = "Toronto";
                TEMP.innerHTML = RES.main.temp + "'C";
                WC.innerHTML = RES.weather[0].description;
                let ICdata = RES.weather[0].icon;
                console.log(ICdata);
                IC.innerHTML = '"' + '<img src=' + '"' + 'http://openweathermap.org/img/wn/' + ICdata + '.png' + '"' + '/>' + '"';
                WS.innerHTML = RES.wind.speed;

            }
        } 
       xhttp.open('GET', url1);
       xhttp.responseType = "json";
       xhttp.send(null);

       //console.log(RES.name);
       //console.log(RES.main.temp)

    }

    function button2(){


        var Out2 = document.getElementById("output");
        Out2.style.display = "block";

        let xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function(){

            if (xhttp.readyState == 4 & xhttp.status == 200){

                //thetest.innerHTML = xhttp.response;
                const RES = xhttp.response;
                
                console.log(RES);
                console.log(RES.main.temp);
                console.log(RES.weather[0].description);
                console.log(RES.weather[0].icon);
                city.innerHTML = "Mississauga";
                TEMP.innerHTML = RES.main.temp + "'C";
                WC.innerHTML = RES.weather[0].description;
                let ICdata = RES.weather[0].icon;
                console.log(ICdata);
                IC.innerHTML = '"' + '<img src=' + '"' + 'http://openweathermap.org/img/wn/' + ICdata + '.png' + '"' + '/>' + '"';
                WS.innerHTML = RES.wind.speed;

            }
        } 
       xhttp.open('GET', url2);
       xhttp.responseType = "json";
       xhttp.send(null);

       //console.log(RES.name);
       //console.log(RES.main.temp);
    }

}