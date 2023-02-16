describe("md5EncryptFunction", function() {
    it("should return a 32 character hexadecimal string.", function() {
        expect(md5Encrypt("inputstring")).toMatch("^[0-9A-Fa-f]{32}$");
    })

    it("should return a string of the hashed value.", function() {
        expect(md5Encrypt("Lukmon")).toEqual("34096a00cbe6d617d7066990c2f32db5");
    })

    it("should return a specific string hashed value. (d41d8cd98f00b204e9800998ecf8427e) when the input string is an empty string", function() {
        expect(md5Encrypt("")).toEqual("d41d8cd98f00b204e9800998ecf8427e");
    })

});

describe("checkLoginfunction", function() {
    it("should use the md5Encrypt function, and return the Boolean true if the username and the password match a known username and matching password", function() {
        expect(checkLogin("Lukmon", "Wonders")).toEqual("true");
    })

    it("should use the md5Encrypt function, and return Invalid Username or Password if either username or the password does not match a known username and password", function() {
        expect(checkLogin("Lukmo", "Wonders")).toEqual("Invalid Username or Password.");
    })

    it("should return ‘No username entered.’ if the username is an empty string.", function() {
        expect(checkLogin("", "Wonders")).toEqual("No username entered");
    })

    it("should return ‘No password entered.’ if the password is an empty string.", function() {
        expect(checkLogin("Lukmon", "")).toEqual("No password entered");
    })


});