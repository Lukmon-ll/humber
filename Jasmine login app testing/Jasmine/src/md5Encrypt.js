function md5Encrypt(stringIn) {
    "use strict";
    var md5string = new CryptoJS.MD5(stringIn);
    return md5string.toString();
}//END md5Encrypt