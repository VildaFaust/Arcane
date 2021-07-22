const http = require("http");
const querystring = require("querystring");
const Cookies = require("cookies");

const post = (req, res, next) => {
    var data = querystring.stringify({
        Command: "AuthorizationHandler"
    });

    var options = {
        // host: '192.168.0.107',
        host: '127.0.0.1',
        port: 3001,
        path: '/request',
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Content-Length': Buffer.byteLength(data)
        }
    };

    var request = http.request(options, function(res)
    {
        res.setEncoding('utf8');
        res.on('data', function (chunk) {
            console.log("body: " + chunk);
        });
    });

    request.write(data);
    request.end();
}

const get = (req, res, next) => {
    var cookies = new Cookies(req, res);

    if (cookies.get('Login')){
        res.render("index");
    }
    else
    {
        res.render("login");
    }
}

module.exports = {post, get};