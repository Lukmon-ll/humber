/**
 * MD5 Encryption function to encrypt provided string.
 * Returns string of encrypted hash.
 * @param {string} stringIn
 */
function md5Encrypt(stringIn) {
    "use strict";
    var md5string = new CryptoJS.MD5(stringIn);
    return md5string.toString();
}//END md5Encrypt

//console.log(md5Encrypt("Lukmon"));
//console.log(md5Encrypt("Lasisi"));

//console.log(md5Encrypt(1));
