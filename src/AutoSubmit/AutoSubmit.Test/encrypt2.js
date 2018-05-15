var encrypt2 = {};
encrypt2.cipher = function (h, d) {
    for (var b = 4,
        g = d.length / b - 1,
        a = [[], [], [], []], c = 0; c < 4 * b; c++) a[c % 4][Math.floor(c / 4)] = h[c];
    a = encrypt2.addRoundKey(a, d, 0, b);
    for (var e = 1; e < g; e++) {
        a = encrypt2.subBytes(a, b);
        a = encrypt2.shiftRows(a, b);
        a = encrypt2.mixColumns(a, b);
        a = encrypt2.addRoundKey(a, d, e, b)
    }
    a = encrypt2.subBytes(a, b);
    a = encrypt2.shiftRows(a, b);
    a = encrypt2.addRoundKey(a, d, g, b);
    for (var f = new Array(4 * b), c = 0; c < 4 * b; c++) f[c] = a[c % 4][Math.floor(c / 4)];
    return f
};
encrypt2.keyExpansion = function (f) {
    for (var g = 4,
        c = f.length / 4,
        h = c + 6,
        e = new Array(g * (h + 1)), d = new Array(4), a = 0; a < c; a++) {
        var i = [f[4 * a], f[4 * a + 1], f[4 * a + 2], f[4 * a + 3]];
        e[a] = i
    }
    for (var a = c; a < g * (h + 1); a++) {
        e[a] = new Array(4);
        for (var b = 0; b < 4; b++) d[b] = e[a - 1][b];
        if (a % c == 0) {
            d = encrypt2.subWord(encrypt2.rotWord(d));
            for (var b = 0; b < 4; b++) d[b] ^= encrypt2.rCon[a / c][b]
        } else if (c > 6 && a % c == 4) d = encrypt2.subWord(d);
        for (var b = 0; b < 4; b++) e[a][b] = e[a - c][b] ^ d[b]
    }
    return e
};
encrypt2.subBytes = function (c, d) {
    for (var b = 0; b < 4; b++) for (var a = 0; a < d; a++) c[b][a] = encrypt2.sBox[c[b][a]];
    return c
};
encrypt2.shiftRows = function (c, e) {
    for (var d = new Array(4), b = 1; b < 4; b++) {
        for (var a = 0; a < 4; a++) d[a] = c[b][(a + b) % e];
        for (var a = 0; a < 4; a++) c[b][a] = d[a]
    }
    return c
};
encrypt2.mixColumns = function (d) {
    for (var b = 0; b < 4; b++) {
        for (var a = new Array(4), c = new Array(4), e = 0; e < 4; e++) {
            a[e] = d[e][b];
            c[e] = d[e][b] & 128 ? d[e][b] << 1 ^ 283 : d[e][b] << 1
        }
        d[0][b] = c[0] ^ a[1] ^ c[1] ^ a[2] ^ a[3];
        d[1][b] = a[0] ^ c[1] ^ a[2] ^ c[2] ^ a[3];
        d[2][b] = a[0] ^ a[1] ^ c[2] ^ a[3] ^ c[3];
        d[3][b] = a[0] ^ c[0] ^ a[1] ^ a[2] ^ c[3]
    }
    return d
};
encrypt2.addRoundKey = function (c, f, d, e) {
    for (var b = 0; b < 4; b++) for (var a = 0; a < e; a++) c[b][a] ^= f[d * 4 + a][b];
    return c
};
encrypt2.subWord = function (b) {
    for (var a = 0; a < 4; a++) b[a] = encrypt2.sBox[b[a]];
    return b
};
encrypt2.rotWord = function (a) {
    for (var c = a[0], b = 0; b < 3; b++) a[b] = a[b + 1];
    a[3] = c;
    return a
};
encrypt2.sBox = [99, 124, 119, 123, 242, 107, 111, 197, 48, 1, 103, 43, 254, 215, 171, 118, 202, 130, 201, 125, 250, 89, 71, 240, 173, 212, 162, 175, 156, 164, 114, 192, 183, 253, 147, 38, 54, 63, 247, 204, 52, 165, 229, 241, 113, 216, 49, 21, 4, 199, 35, 195, 24, 150, 5, 154, 7, 18, 128, 226, 235, 39, 178, 117, 9, 131, 44, 26, 27, 110, 90, 160, 82, 59, 214, 179, 41, 227, 47, 132, 83, 209, 0, 237, 32, 252, 177, 91, 106, 203, 190, 57, 74, 76, 88, 207, 208, 239, 170, 251, 67, 77, 51, 133, 69, 249, 2, 127, 80, 60, 159, 168, 81, 163, 64, 143, 146, 157, 56, 245, 188, 182, 218, 33, 16, 255, 243, 210, 205, 12, 19, 236, 95, 151, 68, 23, 196, 167, 126, 61, 100, 93, 25, 115, 96, 129, 79, 220, 34, 42, 144, 136, 70, 238, 184, 20, 222, 94, 11, 219, 224, 50, 58, 10, 73, 6, 36, 92, 194, 211, 172, 98, 145, 149, 228, 121, 231, 200, 55, 109, 141, 213, 78, 169, 108, 86, 244, 234, 101, 122, 174, 8, 186, 120, 37, 46, 28, 166, 180, 198, 232, 221, 116, 31, 75, 189, 139, 138, 112, 62, 181, 102, 72, 3, 246, 14, 97, 53, 87, 185, 134, 193, 29, 158, 225, 248, 152, 17, 105, 217, 142, 148, 155, 30, 135, 233, 206, 85, 40, 223, 140, 161, 137, 13, 191, 230, 66, 104, 65, 153, 45, 15, 176, 84, 187, 22];
encrypt2.rCon = [[0, 0, 0, 0], [1, 0, 0, 0], [2, 0, 0, 0], [4, 0, 0, 0], [8, 0, 0, 0], [16, 0, 0, 0], [32, 0, 0, 0], [64, 0, 0, 0], [128, 0, 0, 0], [27, 0, 0, 0], [54, 0, 0, 0]];
encrypt2.Ctr = {};
encrypt2.Ctr.encrypt = function (g, i, e) {
    e = e || 256;
    var f = 16;
    if (!(e == 128 || e == 192 || e == 256)) return "";
    g = Utf8.encode(g);
    i = Utf8.encode(i);
    for (var n = e / 8,
        m = new Array(n), a = 0; a < n; a++) m[a] = isNaN(i.charCodeAt(a)) ? 0 : i.charCodeAt(a);
    var j = encrypt2.cipher(m, encrypt2.keyExpansion(m));
    j = j.concat(j.slice(0, n - 16));
    for (var c = new Array(f), r = (new Date).getTime(), w = r % 1e3, v = Math.floor(r / 1e3), u = Math.floor(Math.random() * 65535), a = 0; a < 2; a++) c[a] = w >>> a * 8 & 255;
    for (var a = 0; a < 2; a++) c[a + 2] = u >>> a * 8 & 255;
    for (var a = 0; a < 4; a++) c[a + 4] = v >>> a * 8 & 255;
    for (var q = "",
        a = 0; a < 8; a++) q += String.fromCharCode(c[a]);
    for (var s = encrypt2.keyExpansion(j), k = Math.ceil(g.length / f), p = new Array(k), d = 0; d < k; d++) {
        for (var b = 0; b < 4; b++) c[15 - b] = d >>> b * 8 & 255;
        for (var b = 0; b < 4; b++) c[15 - b - 4] = d / 4294967296 >>> b * 8;
        for (var t = encrypt2.cipher(c, s), o = d < k - 1 ? f : (g.length - 1) % f + 1, h = new Array(o), a = 0; a < o; a++) {
            h[a] = t[a] ^ g.charCodeAt(d * f + a);
            h[a] = String.fromCharCode(h[a])
        }
        p[d] = h.join("")
    }
    var l = q + p.join("");
    l = Base64.encode(l);
    return l
};
encrypt2.Ctr.decrypt = function (d, b, f) {
    f = f || 256;
    b = b + String.fromCharCode(99);
    b = b + String.fromCharCode(101);
    b = b + String.fromCharCode(97);
    b = b + String.fromCharCode(117);
    b = b + String.fromCharCode(121);
    var i = 16;
    if (!(f == 128 || f == 192 || f == 256)) return "";
    d = Base64.decode(d);
    b = Utf8.encode(b);
    for (var n = f / 8,
        m = new Array(n), a = 0; a < n; a++) m[a] = isNaN(b.charCodeAt(a)) ? 0 : b.charCodeAt(a);
    var j = encrypt2.cipher(m, encrypt2.keyExpansion(m));
    j = j.concat(j.slice(0, n - 16));
    var g = new Array(8);
    ctrTxt = d.slice(0, 8);
    for (var a = 0; a < 8; a++) g[a] = ctrTxt.charCodeAt(a);
    for (var q = encrypt2.keyExpansion(j), l = Math.ceil((d.length - 8) / i), p = new Array(l), c = 0; c < l; c++) p[c] = d.slice(8 + c * i, 8 + c * i + i);
    d = p;
    for (var o = new Array(d.length), c = 0; c < l; c++) {
        for (var e = 0; e < 4; e++) g[15 - e] = c >>> e * 8 & 255;
        for (var e = 0; e < 4; e++) g[15 - e - 4] = (c + 1) / 4294967296 - 1 >>> e * 8 & 255;
        for (var r = encrypt2.cipher(g, q), h = new Array(d[c].length), a = 0; a < d[c].length; a++) {
            h[a] = r[a] ^ d[c].charCodeAt(a);
            h[a] = String.fromCharCode(h[a])
        }
        o[c] = h.join("")
    }
    var k = o.join("");
    k = Utf8.decode(k);
    return k
};
var Base64 = {};
Base64.code = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
Base64.encode = function (h, e) {
    e = typeof e == "undefined" ? false : e;
    var m, n, o, d, i, j, k, l, p = [],
        g = "",
        a,
        b,
        c,
        f = Base64.code;
    b = e ? h.encodeUTF8() : h;
    a = b.length % 3;
    if (a > 0) while (a++ < 3) {
        g += "=";
        b += "\0"
    }
    for (a = 0; a < b.length; a += 3) {
        m = b.charCodeAt(a);
        n = b.charCodeAt(a + 1);
        o = b.charCodeAt(a + 2);
        d = m << 16 | n << 8 | o;
        i = d >> 18 & 63;
        j = d >> 12 & 63;
        k = d >> 6 & 63;
        l = d & 63;
        p[a / 3] = f.charAt(i) + f.charAt(j) + f.charAt(k) + f.charAt(l)
    }
    c = p.join("");
    c = c.slice(0, c.length - g.length) + g;
    return c
};
Base64.decode = function (l, c) {
    c = typeof c == "undefined" ? false : c;
    var f, k, o, m, n, i, j, d, g = [],
        h,
        b,
        e = Base64.code;
    b = c ? l.decodeUTF8() : l;
    for (var a = 0; a < b.length; a += 4) {
        m = e.indexOf(b.charAt(a));
        n = e.indexOf(b.charAt(a + 1));
        i = e.indexOf(b.charAt(a + 2));
        j = e.indexOf(b.charAt(a + 3));
        d = m << 18 | n << 12 | i << 6 | j;
        f = d >>> 16 & 255;
        k = d >>> 8 & 255;
        o = d & 255;
        g[a / 4] = String.fromCharCode(f, k, o);
        if (j == 64) g[a / 4] = String.fromCharCode(f, k);
        if (i == 64) g[a / 4] = String.fromCharCode(f)
    }
    h = g.join("");
    return c ? h.decodeUTF8() : h
};
var Utf8 = {};
Utf8.encode = function (b) {
    var a = b.replace(/[\u0080-\u07ff]/g,
        function (b) {
            var a = b.charCodeAt(0);
            return String.fromCharCode(192 | a >> 6, 128 | a & 63)
        });
    a = a.replace(/[\u0800-\uffff]/g,
        function (b) {
            var a = b.charCodeAt(0);
            return String.fromCharCode(224 | a >> 12, 128 | a >> 6 & 63, 128 | a & 63)
        });
    return a
};
Utf8.decode = function (b) {
    var a = b.replace(/[\u00e0-\u00ef][\u0080-\u00bf][\u0080-\u00bf]/g,
        function (a) {
            var b = (a.charCodeAt(0) & 15) << 12 | (a.charCodeAt(1) & 63) << 6 | a.charCodeAt(2) & 63;
            return String.fromCharCode(b)
        });
    a = a.replace(/[\u00c0-\u00df][\u0080-\u00bf]/g,
        function (a) {
            var b = (a.charCodeAt(0) & 31) << 6 | a.charCodeAt(1) & 63;
            return String.fromCharCode(b)
        });
    return a
};
function getSsoUid() {
    return null == readCookie("uid2") || "" == readCookie("uid2") || null == readCookie("uid1") || "" == readCookie("uid1") ? "" : encrypt2.Ctr.decrypt(unescape(readCookie("uid2")), readCookie("uid1"))
}
function setSsoUid() {
    var c = (new Date).getTime(),
        a = "" + c;
    createCookie("uid1", a, null, "/");
    var b = escape(encrypt2.Ctr.encrypt(frm.PASSWORD1.value, a + "ceauy"));
    createCookie("uid2", b, null, "/");
    createCookie("LOGINID", document.frm.LOGINID.value, null, "/")
}
function ssoLogin(d, e, f, a) {
    if ("[object Function]" != Object.prototype.toString.call(a)) a = function () { };
    var b = showMsg("\u6b63\u5728\u5355\u70b9\u767b\u9646", -1),
        c = d + "/index_sso.jsp";
    jsonpRequest(c, {},
        function (d) {
            if ("CONFIRMERROR" == d.LOGINSTATE && null != d.ERRORID) {
                var g = stringToHex(encrypt(d.ERRORID, f));
                jsonpRequest(c, {
                    LOGINID: e,
                    UID: g
                },
                    function (c) {
                        hideMsg(b);
                        a(c)
                    })
            } else {
                hideMsg(b);
                a(d)
            }
        },
        b)
}
function jsonpRequest(c, g, e, f) {
    if ("[object Function]" != Object.prototype.toString.call(e)) e = function () { };
    if (null == window.fwJsonpCallbackId) window.fwJsonpCallbackId = 0;
    if (null == window.fwJsonpData) window.fwJsonpData = {};
    var d = document.createElement("script");
    d.onreadystatechange = function () {
        if ("complete" == this.readyState || "loaded" == this.readyState) {
            this.onreadystatechange = null;
            if (null == window.fwJsonpData["" + a]) {
                alert("\u670d\u52a1\u5668" + i(c) + "\u6ca1\u6709\u8fd4\u56de\u6570\u636e");
                f != null && hideMsg(f)
            } else e(window.fwJsonpData["" + a]);
            delete window.fwJsonpData["" + a]
        }
    };
    var b = "";
    for (var h in g) b += "&" + h + "=" + encodeURIComponent(g[h]);
    var a = ++window.fwJsonpCallbackId;
    b += "&callback=fwJsonpCallback" + a;
    b += "&t=" + (new Date).getTime();
    c = c + "?" + b.substring(1);
    window["fwJsonpCallback" + a] = function (b) {
        window.fwJsonpData["" + a] = b
    };
    d.src = c;
    document.getElementsByTagName("head")[0].appendChild(d);
    function i(b) {
        for (var a = 0,
            c = 0; c < 4; c++) a = b.indexOf("/", a + 1);
        return b.substring(0, a)
    }
}
function createCookie(h, a, e, f, d, g) {
    var c = "";
    if (e != null) {
        var b = new Date;
        b.setTime(b.getTime() + e);
        c = "; expires=" + b.toGMTString()
    }
    a = escape(a);
    document.cookie = h + "=" + a + c + (f ? "; path=" + f : "") + (d ? "; domain=" + d : "") + (g ? "; secure" : "")
}
function readCookie(e) {
    for (var c = e + "=",
        d = document.cookie.split(";"), b = 0; b < d.length; b++) {
        var a = d[b];
        while (a.charAt(0) == " ") a = a.substring(1, a.length);
        if (a.indexOf(c) == 0) return unescape(a.substring(c.length, a.length))
    }
    return null
}