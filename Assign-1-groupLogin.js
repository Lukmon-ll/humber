var Amember = window.prompt("Please enter your team number: ");
var firstN;
var access;


if (Amember == 4) {
    firstN = window.prompt("Please enter your first name ");

    switch (firstN.toUpperCase()) {
        case "LUKMON":
            alert("Welcome to the team Lukmon Lasisi");
            access = "first";
            break;
        case "NICOLE":
            alert("Welcome to the team Nicole Yeung");
            access = "first";
            break;
        case "MARY":
            alert("Welcome to the team Mary Louise");
            access = "first";
            break;
        case "BENJAMIN":
            alert("Welcome to the team Benjamin Miethnner");
            access = "first";
            break;
        case "KEE":
            alert("Welcome to the team Kee Fung");
            access = "first";
            break;
        case "YOUNGJU":
            alert("Welcome to the team Youngju Lee");
            access = "first";
            break;
            
        default:
            alert("Access is denied for " + firstN );
            
    
    }
} else {
    alert("Your access to the team is denied")
    
    
}











