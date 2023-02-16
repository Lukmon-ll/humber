//My JS code with JSLint

window.onload = function()
 {
    "use strict";
    var Form_1 = document.forms.form_1;
    //console.log(Form_1);
    Form_1.onsubmit = function()
    {

        var UserN = document.getElementById("username");
        var PassW = document.getElementById("password");
        var outputValue = document.getElementById("outPut");
        var UserText = document.getElementById("outputText1");
        var PassText = document.getElementById("outputText2");

var UserInput = UserN.value;
var PassInput = PassW.value;
//console.log(UserInput);
//console.log(PassInput);

//calling the checkLogin function to invoke the md5Encrypt function
var checkLOutput = checkLogin(UserInput, PassInput);

//Logic to output the output messages
var newMessage = "";
if(checkLOutput === "true") {
    newMessage = "Successful Login: Welcome Back!";
}else if(checkLOutput === "Invalid Username or Password.") {
    newMessage = "ERROR: Invalid username or password."
}else if(checkLOutput === "No username entered") {
    newMessage = "No username entered.";
}else if(checkLOutput === "No password entered") {
    newMessage = "No password entered";
}


outputValue.innerHTML = newMessage;

//UserText.innerHTML = UserInput;
//PassText.innerHTML = PassInput;

if(UserInput === "") {
    UserN.classList.add("login__txt_error");
    //UserN.style.backgroundColor = "red";
    UserN.focus();
    return false;

}if(PassInput === "") {
    PassW.classList.add("login__txt_error");
    //PassW.style.backgroundColor = "red";
    PassW.focus();
    return false;
}

outputValue.style.display = "block";

        return false;//onsubmit function
    };


};

