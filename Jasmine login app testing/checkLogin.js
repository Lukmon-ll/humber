/**
 * Login user input validation function to validate the input username and password.
 * Returns boolean true if the inputs validates.
 * Returns false if the inputs did not validates
 * @param {string} stringIn1, @param {string} stringIn2
 */

/**
 * SPECS for checkLogin function
 * checkLogin function should return true if input username is "34096a00cbe6d617d7066990c2f32db5"
 * checkLogin function should return false if input username is not "34096a00cbe6d617d7066990c2f32db5"
 * should return true if input password is "15ffe0bd8bce2d0b53d34e09656d7be6" 
 * should return false if input password is not "15ffe0bd8bce2d0b53d34e09656d7be6"
 */

function checkLogin(stringIn1, stringIn2) {
    
    var username = stringIn1;
    var password = stringIn2;

    //username - Lukmon - 34096a00cbe6d617d7066990c2f32db5
    //password - Wonders - 15ffe0bd8bce2d0b53d34e09656d7be6
    //empty string - d41d8cd98f00b204e9800998ecf8427e

    var message = "";
    if (md5Encrypt(username) === "34096a00cbe6d617d7066990c2f32db5" && md5Encrypt(password) === "15ffe0bd8bce2d0b53d34e09656d7be6") {
        message = "true";
        
    }else if (md5Encrypt(username) === "d41d8cd98f00b204e9800998ecf8427e") {
        message = "No username entered";

    }else if (md5Encrypt(password) === "d41d8cd98f00b204e9800998ecf8427e") {
        message = "No password entered";

    }else if (md5Encrypt(username) != "34096a00cbe6d617d7066990c2f32db5" || md5Encrypt(password) != "15ffe0bd8bce2d0b53d34e09656d7be6" ) {
        message = "Invalid Username or Password.";

    }
    
    return message;
};

//console.log(checkLogin("Lukmon", "Wonders"));

