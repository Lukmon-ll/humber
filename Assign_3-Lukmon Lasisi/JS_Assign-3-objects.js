//alert("This is it");

var programLang = {
    name: "javaScript",
    typed: "notStronglyTyped",
    clientServer: "client",
    prospect: 60,
    nameType: function(x){
        //var x = prompt("Enter the name of the programming language you are currently learning!");

        programLang.name = x;
        var entry = x.toUpperCase();

        if (entry == "JAVASCRIPT") {
            alert(x + " is not a typed language");
            programLang.typed = notStronglyTyped;
            
        }else if (entry == "CEE SHARP") {
            alert(x + " is a strongly typed language");
            programLang.typed = "isStronglyTyped";
            alert("name has been updated to " + programLang.name + " and the type has also been updated to " + programLang.typed);
        }else if (entry == "PYTHON") {
            alert(x + " is a strongly typed language");
            programLang.typed = "isStronglyTyped";
            programLang.clientServer = "server";
            programLang.prospect = 90;
            alert("name has been updated to " + programLang.name + " and the type has also been updated to " + programLang.typed);
        }else {
            alert("Out of scope of the program");
            programLang.typed = "I really can't say";
            alert("name has been updated to " + programLang.name + " and the type has also been updated to " + programLang.typed);
            programLang.clientServer = "I don't know";
            programLang.prospect = 30;
        }
        
    }
};
//console.log(programLang.nameType());
//console.log(programLang);

console.log(programLang);
var userinput = prompt("Enter your programming language of choice", programLang.name);
programLang.name = userinput;
var usersecondinput = prompt("is your programming language strongly typed or not, enter isStronglyTyped or notStronglyTyped", programLang.typed);
programLang.typed = usersecondinput;
programLang.nameType("cee sharp");
console.log(programLang);

